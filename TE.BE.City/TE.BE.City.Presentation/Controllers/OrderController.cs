using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TE.BE.City.Domain.Entity;
using TE.BE.City.Domain.Interfaces;
using TE.BE.City.Presentation.Model.Request;
using TE.BE.City.Presentation.Model.Response;

namespace TE.BE.City.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class OrderController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        /// <summary>
        /// Dependency injection to access Service layer.
        /// </summary>
        /// <param name="Service"></param>
        public OrderController(IOrderService Service, IMapper mapper) : base()
        {
            _mapper = mapper;
            _orderService = Service;
        }

        /// <summary>
        /// Post new  location.
        /// </summary>
        /// <param name="request"></param>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]OrderRequestModel request)
        {
            try
            {
                var orderEntity = new OrderEntity();
                orderEntity.Latitude = request.Latitude;
                orderEntity.Longitude = request.Longitude;
                orderEntity.OrderStatusId = request.OrderStatusId;
                orderEntity.OcorrencyId = request.OcorrencyId;
                orderEntity.OcorrencyDetailId = request.OcorrencyDetailId;
                orderEntity.CreatedAt = DateTime.Now.ToUniversalTime();

                var result = await _orderService.Post(orderEntity);

                return Response(result.IsSuccess, result);
            }
            catch (Exception ex)
            {
                return Response(false, ex.Message);
            }
        }

        /// <summary>
        /// Get all item if id is null or 0. Get one item by id.
        /// </summary>
        /// <param name="id"></param>
        [HttpGet]
        public async Task<OrderSearchResponseModel> Get([FromBody] OrderSearchRequestModel request)
        {
            var orderSearchResponseModel = new OrderSearchResponseModel();
            var orderEntity = new OrderEntity();
            orderEntity.Id = request.Id;

            if (orderEntity.Id > 0)
            {
                var userEntity = await _orderService.GetById(orderEntity.Id);
                var orderResponseModel = new OrderResponseModel();
                _mapper.Map(userEntity, orderResponseModel);
                orderSearchResponseModel.Orders.Add(orderResponseModel);
            }
            else
            {
                orderEntity.OcorrencyId = request.OcorrencyId;
                orderEntity.OcorrencyDetailId = request.OcorrencyDetailId;
                orderEntity.OrderStatusId = request.OrderStatusId;
                orderEntity.StartDate = request.StartDate;
                orderEntity.EndDate = request.EndDate;

                var usersEntity = await _orderService.GetAll(orderEntity, request.Skip, request.Limit);
                _mapper.Map(usersEntity, orderSearchResponseModel.Orders);
            }

            int limit = request.Limit == 0 ? OrderSearchRequestModel.LIMIT : request.Limit;
            orderSearchResponseModel.Page = request.Skip / limit;
            orderSearchResponseModel.Total = await _orderService.GetCount(orderEntity);

            return orderSearchResponseModel;
        }

        /// <summary>
        /// Update one item.
        /// </summary>
        /// <param name="request"></param>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] OrderRequestModel request)
        {
            try
            {
                OrderEntity orderEntity = new OrderEntity();
                orderEntity.Id = request.Id;
                orderEntity.Latitude = request.Latitude;
                orderEntity.Longitude = request.Longitude;
                orderEntity.OcorrencyId = request.OcorrencyId;

                return Response(true, await _orderService.Put(orderEntity));
            }
            catch (Exception ex)
            {
                return Response(false, ex.Message);
            }
        }

        /// <summary>
        /// delete one item.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                return Response(true, await _orderService.Delete(id));
            }
            catch (Exception ex)
            {
                return Response(false, ex.Message);
            }
        }
    }
}
