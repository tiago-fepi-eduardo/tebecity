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
    public class OcorrencyService : IOcorrencyService
    {
        private readonly IRepository<OcorrencyEntity> _repository;

        public OcorrencyService(IRepository<OcorrencyEntity> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OcorrencyEntity>> GetAll(int skip, int limit)
        {
            var contactsEntity = new List<OcorrencyEntity>();

            try
            {
                IEnumerable<OcorrencyEntity> result;

                if (skip == 0 && limit == 0)
                    result = await _repository.Select();
                else
                    result = await _repository.SelectWithPagination(skip, limit);

                if (result != null)
                    return result;
                else
                {
                    var contactEntity = new OcorrencyEntity()
                    {
                        Error = new ErrorDetail()
                        {
                            Code = (int)ErrorCode.SearchHasNoResult,
                            Type = ErrorCode.SearchHasNoResult.ToString(),
                            Message = ErrorCode.SearchHasNoResult.GetDescription()
                        }
                    };
                    contactsEntity.Add(contactEntity);
                }

                return contactsEntity;
            }
            catch (ExecptionHelper.ExceptionService ex)
            {
                throw new ExecptionHelper.ExceptionService(ex.Message);
            }
        }

        public async Task<IEnumerable<OcorrencyEntity>> GetById(int id)
        {
            var contactsEntity = new List<OcorrencyEntity>();

            try
            {
                var result = await _repository.SelectById(id);

                if (result != null)
                    contactsEntity.Add(result);
                else
                {
                    var contactEntity = new OcorrencyEntity()
                    {
                        Error = new ErrorDetail()
                        {
                            Code = (int)ErrorCode.SearchHasNoResult,
                            Type = ErrorCode.SearchHasNoResult.ToString(),
                            Message = ErrorCode.SearchHasNoResult.GetDescription()
                        }
                    };
                    contactsEntity.Add(contactEntity);
                }

                return contactsEntity;
            }
            catch (ExecptionHelper.ExceptionService ex)
            {
                throw new ExecptionHelper.ExceptionService(ex.Message);
            }
        }

        public async Task<IEnumerable<OcorrencyEntity>> GetClosed(bool closed, int skip, int limit)
        {
            var contactsEntity = new List<OcorrencyEntity>();

            try
            {
                IEnumerable<OcorrencyEntity> result;

                if (skip == 0 && limit == 0)
                    result = await _repository.Filter(c => c.Closed == closed);
                else
                    result = await _repository.FilterWithPagination(c => c.Closed == closed, skip, limit);

                if (result != null)
                    return result;
                else
                {
                    var contactEntity = new OcorrencyEntity()
                    {
                        Error = new ErrorDetail()
                        {
                            Code = (int)ErrorCode.SearchHasNoResult,
                            Type = ErrorCode.SearchHasNoResult.ToString(),
                            Message = ErrorCode.SearchHasNoResult.GetDescription()
                        }
                    };
                    contactsEntity.Add(contactEntity);
                }

                return contactsEntity;
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
