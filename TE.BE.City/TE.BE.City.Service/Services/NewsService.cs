using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TE.BE.City.Domain.Entity;
using TE.BE.City.Domain.Interfaces;
using TE.BE.City.Infra.CrossCutting;
using System.Linq;
using TE.BE.City.Infra.CrossCutting.Enum;

namespace TE.BE.City.Service.Services
{
    public class NewsService : INewsService
    {
        private readonly IRepository<NewsEntity> _repository;

        public NewsService(IRepository<NewsEntity> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<NewsEntity>> GetAll(int skip, int limit)
        {
            var newsEntity = new List<NewsEntity>();

            try
            {
                IEnumerable<NewsEntity> result;

                if (skip == 0 && limit == 0)
                    result = await _repository.Select();
                else
                    result = await _repository.SelectWithPagination(skip, limit);

                if (result != null)
                    return result;
                else
                {
                    var contactEntity = new NewsEntity()
                    {
                        Error = new ErrorDetail()
                        {
                            Code = (int)ErrorCode.SearchHasNoResult,
                            Type = ErrorCode.SearchHasNoResult.ToString(),
                            Message = ErrorCode.SearchHasNoResult.GetDescription()
                        }
                    };
                    newsEntity.Add(contactEntity);
                }

                return newsEntity;
            }
            catch (ExecptionHelper.ExceptionService ex)
            {
                throw new ExecptionHelper.ExceptionService(ex.Message);
            }
        }

        public async Task<IEnumerable<NewsEntity>> GetById(int id)
        {
            var newsEntity = new List<NewsEntity>();

            try
            {
                var result = await _repository.SelectById(id);

                if (result != null)
                    newsEntity.Add(result);
                else
                {
                    var contactEntity = new NewsEntity()
                    {
                        Error = new ErrorDetail()
                        {
                            Code = (int)ErrorCode.SearchHasNoResult,
                            Type = ErrorCode.SearchHasNoResult.ToString(),
                            Message = ErrorCode.SearchHasNoResult.GetDescription()
                        }
                    };
                    newsEntity.Add(contactEntity);
                }

                return newsEntity;
            }
            catch (ExecptionHelper.ExceptionService ex)
            {
                throw new ExecptionHelper.ExceptionService(ex.Message);
            }
        }

        public async Task<IEnumerable<NewsEntity>> GetClosed(bool closed, int skip, int limit)
        {
            var newsEntity = new List<NewsEntity>();

            try
            {
                IEnumerable<NewsEntity> result;

                if (skip == 0 && limit == 0)
                    result = await _repository.Filter(c => c.Closed == closed);
                else
                    result = await _repository.FilterWithPagination(c => c.Closed == closed, skip, limit);

                if (result != null)
                    return result;
                else
                {
                    var contactEntity = new NewsEntity()
                    {
                        Error = new ErrorDetail()
                        {
                            Code = (int)ErrorCode.SearchHasNoResult,
                            Type = ErrorCode.SearchHasNoResult.ToString(),
                            Message = ErrorCode.SearchHasNoResult.GetDescription()
                        }
                    };
                    newsEntity.Add(contactEntity);
                }

                return newsEntity;
            }
            catch (ExecptionHelper.ExceptionService ex)
            {
                throw new ExecptionHelper.ExceptionService(ex.Message);
            }
        }

        public async Task<int> GetCount(bool? closed)
        {
            try
            {
                if (closed != null)
                {
                    var result = await _repository.Filter(c => c.Closed == closed);
                    return result.Count();
                }
                else
                    return await _repository.SelectCount();
            }
            catch (ExecptionHelper.ExceptionService ex)
            {
                throw new ExecptionHelper.ExceptionService(ex.Message);
            }
        }
    }
}
