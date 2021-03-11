using System;
using System.Collections.Generic;
using System.Text;

namespace TE.BE.City.Domain.Entity
{
    public class OrderEntity : BaseEntity
    {
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public int OcorrencyId { get; set; }
        public int OcorrencyDetailId { get; set; }
        public int OrderStatusId { get; set; }
        public OcorrencyEntity Ocorrency { get; set; }
        public OrderStatusEntity OrderStatus { get; set; }
    }
}
