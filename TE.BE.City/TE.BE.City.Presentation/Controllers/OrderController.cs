using Microsoft.AspNetCore.Mvc;
using System;
using TE.BE.City.Domain.Entity;
using TE.BE.City.Domain.Interfaces;
using TE.BE.City.Presentation.Model;

namespace TE.BE.City.Presentation.Controllers
{
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
        public ActionResult Post([FromBody]OrderRequestModel request)
        {
            try
            {
                OrderEntity orderEntity = new OrderEntity();
                orderEntity.Latitude = request.Latitude;
                orderEntity.Longitude = request.Longitude;
                orderEntity.OcorrencyId = request.OcorrencyId;

                return Response(true, _service.Post(orderEntity));
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
        public ActionResult Get(int id = 0)
        {
            try
            {
                if (id > 0)
                    return Response(true, _service.GetById(id));
                else
                    return Response(true, _service.GetAll());
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
        public ActionResult Put([FromBody] OrderRequestModel request)
        {
            try
            {
                OrderEntity orderEntity = new OrderEntity();
                orderEntity.Id = request.Id;
                orderEntity.Latitude = request.Latitude;
                orderEntity.Longitude = request.Longitude;
                orderEntity.OcorrencyId = request.OcorrencyId;

                return Response(true, _service.Put(orderEntity));
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
        public ActionResult Delete(int id)
        {
            try
            {
                return Response(true, _service.Delete(id));
            }
            catch (Exception ex)
            {
                return Response(false, ex.Message);
            }
        }
    }
}
