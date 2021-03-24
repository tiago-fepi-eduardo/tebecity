using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using TE.BE.City.Domain.Entity;
using TE.BE.City.Domain.Interfaces;
using TE.BE.City.Infra.CrossCutting;
using TE.BE.City.Infra.CrossCutting.Enum;
using TE.BE.City.Service.Validation;
using System.Linq.Expressions;
using LinqKit;

namespace TE.BE.City.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<OrderEntity> _orderRepository;
        private readonly IRepository<OcorrencyEntity> _ocorrencyRepository;
        private readonly IRepository<OcorrencyDetailEntity> _ocorrencyDetailRepository;
        private readonly IRepository<OrderStatusEntity> _orderStatusRepository;
        private readonly IOrderDomain _serviceDomain;

        /// <summary>
        /// Iniciate my dependy injection
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="token"></param>
        public OrderService(IOrderDomain serviceDomain,
            IRepository<OrderEntity> orderRepository,
            IRepository<OcorrencyEntity> ocorrencyRepository,
            IRepository<OcorrencyDetailEntity> ocorrencyDetailRepository,
            IRepository<OrderStatusEntity> orderStatusRepository)
        {
            _orderRepository = orderRepository;
            _ocorrencyRepository = ocorrencyRepository;
            _ocorrencyDetailRepository = ocorrencyDetailRepository;
            _orderStatusRepository = orderStatusRepository;
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

                var result = await _orderRepository.Insert(request);

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
        public async Task<IEnumerable<OrderEntity>> GetAll(OrderEntity request, int skip, int limit)
        {
            var ordersEntity = new List<OrderEntity>();

            try
            {
                IEnumerable<OrderEntity> result;

                // apply filter
                var predicate = PredicateBuilder.New<OrderEntity>(true);

                if (request.Id > 0)
                    predicate.And(model => model.Id == request.Id);
                if (request.OcorrencyId > 0)
                    predicate.And(model => model.OcorrencyId == request.OcorrencyId);
                if (request.OcorrencyDetailId > 0)
                    predicate.And(model => model.OcorrencyDetailId == request.OcorrencyDetailId);
                if (request.OrderStatusId > 0)
                    predicate.And(model => model.OrderStatusId == request.OrderStatusId);
                if (request.StartDate > DateTime.MinValue)
                    predicate.And(model => model.CreatedAt.Date >= request.StartDate.Date);
                if (request.EndDate > DateTime.MinValue)
                    predicate.And(model => model.CreatedAt.Date <= request.EndDate.Date);

                // get order
                if (skip == 0 && limit == 0)
                    result = await _orderRepository.Filter(predicate);
                else
                    result = await _orderRepository.FilterWithPagination(predicate, skip, limit);

                if (result != null)
                {
                    // get ocorrency
                    foreach (var item in result.ToList())
                        item.Ocorrency = await _ocorrencyRepository.SelectById(item.OcorrencyId);

                    // get ocorrency detail
                    foreach (var item in result.ToList())
                        item.Ocorrency.OcorrencyDetail = await _ocorrencyDetailRepository.SelectById(item.OcorrencyDetailId);

                    // get order status
                    foreach (var item in result.ToList())
                        item.OrderStatus = await _orderStatusRepository.SelectById(item.OrderStatusId);

                    return result;
                }
                else
                {
                    var orderEntity = new OrderEntity()
                    {
                        Error = new ErrorDetail()
                        {
                            Code = (int)ErrorCode.SearchHasNoResult,
                            Type = ErrorCode.SearchHasNoResult.ToString(),
                            Message = ErrorCode.SearchHasNoResult.GetDescription()
                        }
                    };
                    ordersEntity.Add(orderEntity);
                }

                return ordersEntity;
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
                var result = await _orderRepository.SelectById(id);

                if (result != null)
                {
                    // get ocorrency
                    result.Ocorrency = await _ocorrencyRepository.SelectById(result.OcorrencyId);

                    // get ocorrency detail
                    result.Ocorrency.OcorrencyDetail = await _ocorrencyDetailRepository.SelectById(result.OcorrencyDetailId);

                    // get order status
                    result.OrderStatus = await _orderStatusRepository.SelectById(result.OrderStatusId);

                    return result;
                }
                else
                {
                    var orderEntity = new OrderEntity()
                    {
                        Error = new ErrorDetail()
                        {
                            Code = (int)ErrorCode.SearchHasNoResult,
                            Type = ErrorCode.SearchHasNoResult.ToString(),
                            Message = ErrorCode.SearchHasNoResult.GetDescription()
                        }
                    };
                    return orderEntity;
                }
            }
            catch (ExecptionHelper.ExceptionService ex)
            {
                throw new ExecptionHelper.ExceptionService(ex.Message);
            }
        }

        public async Task<int> GetCount(OrderEntity request)
        {
            try
            {
                var predicate = PredicateBuilder.New<OrderEntity>(true);

                if (request.Id > 0)
                    predicate.And(model => model.Id == request.Id);                
                if (request.OcorrencyId > 0)
                    predicate.And(model => model.OcorrencyId == request.OcorrencyId);
                if (request.OcorrencyDetailId > 0)
                    predicate.And(model => model.OcorrencyDetailId == request.OcorrencyDetailId);
                if (request.OrderStatusId > 0)
                    predicate.And(model => model.OrderStatusId == request.OrderStatusId);
                if (request.StartDate > DateTime.MinValue)
                    predicate.And(model => model.CreatedAt.Date >= request.StartDate.Date);
                if (request.EndDate > DateTime.MinValue)
                    predicate.And(model => model.CreatedAt.Date <= request.EndDate.Date);

                var result = await _orderRepository.Filter(predicate);
                return result.Count();
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
                return await _orderRepository.Edit(request);
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
                return await _orderRepository.Delete(id);
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