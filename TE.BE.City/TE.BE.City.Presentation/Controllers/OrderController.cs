using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TE.BE.City.Domain.Entity;
using TE.BE.City.Domain.Interfaces;
using TE.BE.City.Presentation.Model;

namespace TE.BE.City.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class OrderController : BaseController
    {
        private readonly IOrderService _service;

        /// <summary>
        /// Dependency injection to access Service layer.
        /// </summary>
        /// <param name="Service"></param>
        public OrderController(IOrderService Service) : base()
        {
            _service = Service;
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
                OrderEntity orderEntity = new OrderEntity();
                orderEntity.Latitude = request.Latitude;
                orderEntity.Longitude = request.Longitude;
                orderEntity.OcorrencyId = request.OcorrencyId;

                return Response(true, await _service.Post(orderEntity));
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
        public async Task<ActionResult> Get(int id = 0)
        {
            try
            {
                if (id > 0)
                    return Response(true, await _service.GetById(id));
                else
                    return Response(true, await _service.GetAll());
            }
            catch (Exception ex)
            {
                return Response(false, ex.Message);
            }
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

                return Response(true, await _service.Put(orderEntity));
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
                return Response(true, await _service.Delete(id));
            }
            catch (Exception ex)
            {
                return Response(false, ex.Message);
            }
        }
    }
}
