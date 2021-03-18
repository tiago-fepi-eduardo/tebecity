using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TE.BE.City.Domain.Interfaces;
using TE.BE.City.Presentation.Model.Response;

namespace TE.BE.City.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class OrderStatusController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IOrderStatusService _orderStatusService;

        public OrderStatusController(IOrderStatusService orderStatusService, IMapper mapper)
        {
            _orderStatusService = orderStatusService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all item.
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="limit"></param>
        [HttpGet]
        public async Task<OrderStatusSearchResponseModel> Get(int skip = 0, int limit = 50)
        {
            var orderStatusSearchResponseModel = new OrderStatusSearchResponseModel();
                       
            var ordertatusEntity = await _orderStatusService.GetAll(skip, limit);
            _mapper.Map(ordertatusEntity, orderStatusSearchResponseModel.OrderStatus);

            orderStatusSearchResponseModel.Page = skip / limit;
            orderStatusSearchResponseModel.Total = await _orderStatusService.GetCount(false);

            return orderStatusSearchResponseModel;
        }
    }
}
