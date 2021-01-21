using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using TE.BE.City.Domain.Entity;
using TE.BE.City.Domain.Interfaces;
using TE.BE.City.Infra.CrossCutting;
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
        public bool Post(OrderEntity request)
        {
            try
            {
                var result = Validate(request);

                if (!result.IsValid)
                    throw new ExecptionHelper.ExceptionService(result.Errors[0].ToString());

                _serviceDomain.ApplyBusinessRules(request);

                return _repository.Insert(request);
            }
            catch (ExecptionHelper.ExceptionService ex)
            {
                throw new ExecptionHelper.ExceptionService(ex.Message);
            }
        }

        /// <summary>
        /// Get all itens
        /// </summary>
        public IEnumerable<OrderEntity> GetAll()
        {
            try
            {
                return _repository.Select();
            }
            catch (ExecptionHelper.ExceptionService ex)
            {
                throw new ExecptionHelper.ExceptionService(ex.Message);
            }
        }

        /// <summary>
        /// Get a item by id
        /// </summary>
        public OrderEntity GetById(int id)
        {
            try
            {
                return _repository.SelectById(id);
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
        public bool Put(OrderEntity request)
        {
            try
            {
                return _repository.Edit(request);
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
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        /// <summary>
        /// Validate entity item.
        /// </summary>
        /// <param name="obj"></param>
        private ValidationResult Validate(OrderEntity obj)
        {
            var validator = new ServiceValidator().Validate(obj);

            return validator;
        }
    }
}