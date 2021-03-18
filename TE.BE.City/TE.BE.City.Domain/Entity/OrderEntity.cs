using System;
using System.Collections.Generic;
using System.Text;

namespace TE.BE.City.Domain.Entity
{
    public class OrderEntity : BaseEntity
    {
        public OrderEntity()
        {
            Ocorrency = new OcorrencyEntity();
            OrderStatus = new OrderStatusEntity();
        }

        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public int OcorrencyId { get; set; }
        public int OcorrencyDetailId { get; set; }
        public int OrderStatusId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public OcorrencyEntity Ocorrency { get; set; }
        public OrderStatusEntity OrderStatus { get; set; }
    }
}
