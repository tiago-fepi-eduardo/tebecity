using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TE.BE.City.Domain.Entity;
using TE.BE.City.Domain.Interfaces;
using TE.BE.City.Infra.CrossCutting;
using TE.BE.City.Infra.CrossCutting.Enum;
using TE.BE.City.Service.Validation;

namespace TE.BE.City.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<OrderEntity> _repository;
        private readonly IOrderDomain _serviceDomain;

        /// <summary>
        /// Iniciate my dependy injection
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="token"></param>
        public OrderService(IRepository<OrderEntity> repository, IOrderDomain serviceDomain)
        {
            _repository = repository;
            _serviceDomain = serviceDomain;
        }

        /// <summary>
        /// Insert new item on the database
        /// </summary>
        /// <param name="request"></param>
        public async Task<OrderEntity> Post(OrderEntity request)
        {
            try
            {
                var orderEntity = new OrderEntity();

                await _serviceDomain.ApplyBusinessRules(request);

                var result = await _repository.Insert(request);

                if (result)
                    return orderEntity;
                else
                {
                    orderEntity.Error = new ErrorDetail()
                    {
                        Code = (int) ErrorCode.CreateOrderFail,
                        Type = ErrorCode.CreateOrderFail.ToString(),
                        Message = ErrorCode.CreateOrderFail.GetDescription()
                    };
                    
                    return orderEntity;
                }
            }
            catch (ExecptionHelper.ExceptionService ex)
            {
                throw new ExecptionHelper.ExceptionService(ex.Message);
            }
        }

        /// <summary>
        /// Get all itens
        /// </summary>
        public async Task<IEnumerable<OrderEntity>> GetAll()
        {
            try
            {
                return await _repository.Select();
            }
            catch (ExecptionHelper.ExceptionService ex)
            {
                throw new ExecptionHelper.ExceptionService(ex.Message);
            }
        }

        /// <summary>
        /// Get a item by id
        /// </summary>
        public async Task<OrderEntity> GetById(int id)
        {
            try
            {
                return await _repository.SelectById(id);
            }
            catch (ExecptionHelper.ExceptionService ex)
            {
                throw new ExecptionHelper.ExceptionService(ex.Message);
            }
        }

        /// <summary>
        /// Update an item by entity
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<bool> Put(OrderEntity request)
        {
            try
            {
                return await _repository.Edit(request);
            }
            catch (ExecptionHelper.ExceptionService ex)
            {
                throw new ExecptionHelper.ExceptionService(ex.Message);
            }
        }

        /// <summary>
        /// Delete item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(int id)
        {
            try
            {
                return await _repository.Delete(id);
            }
            catch (ExecptionHelper.ExceptionService ex)
            {
                throw new ExecptionHelper.ExceptionService(ex.Message);
            }
        }

        /// <summary>
        /// Validate entity item.
        /// </summary>
        /// <param name="obj"></param>
        private ValidationResult Validate(OrderEntity obj)
        {
            var validator = new OrderValidator().Validate(obj);

            return validator;
        }
    }
}