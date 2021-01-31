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
        public OcorrencyEntity Ocorrency { get; set; }
    }
}
