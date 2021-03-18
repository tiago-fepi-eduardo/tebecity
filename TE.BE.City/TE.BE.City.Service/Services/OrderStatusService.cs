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
    public class OrderStatusService : IOrderStatusService
    {
        private readonly IRepository<OrderStatusEntity> _repository;

        public OrderStatusService(IRepository<OrderStatusEntity> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OrderStatusEntity>> GetAll(int skip, int limit)
        {
            var contactsEntity = new List<OrderStatusEntity>();

            try
            {
                IEnumerable<OrderStatusEntity> result;

                if (skip == 0 && limit == 0)
                    result = await _repository.Select();
                else
                    result = await _repository.SelectWithPagination(skip, limit);

                if (result != null)
                    return result;
                else
                {
                    var contactEntity = new OrderStatusEntity()
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

        public async Task<IEnumerable<OrderStatusEntity>> GetById(int id)
        {
            var contactsEntity = new List<OrderStatusEntity>();

            try
            {
                var result = await _repository.SelectById(id);

                if (result != null)
                    contactsEntity.Add(result);
                else
                {
                    var contactEntity = new OrderStatusEntity()
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

        public async Task<IEnumerable<OrderStatusEntity>> GetClosed(bool closed, int skip, int limit)
        {
            var contactsEntity = new List<OrderStatusEntity>();

            try
            {
                IEnumerable<OrderStatusEntity> result;

                if (skip == 0 && limit == 0)
                    result = await _repository.Filter(c => c.Closed == closed);
                else
                    result = await _repository.FilterWithPagination(c => c.Closed == closed, skip, limit);

                if (result != null)
                    return result;
                else
                {
                    var contactEntity = new OrderStatusEntity()
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
    }
}
