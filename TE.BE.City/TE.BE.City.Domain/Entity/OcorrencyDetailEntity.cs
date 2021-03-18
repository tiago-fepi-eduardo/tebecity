using System;
using System.Collections.Generic;
using System.Text;

namespace TE.BE.City.Domain.Entity
{
    public class OcorrencyDetailEntity : BaseEntity
    {
        public string Description { get; set; }
        public int OcorrencyId { get; set; }
        public bool Closed { get; set; }
    }
}
