using System;
using System.Collections.Generic;
using System.Text;

namespace TE.BE.City.Domain.Entity
{
    public class OcorrencyEntity : BaseEntity
    {
        public OcorrencyEntity()
        {
            OcorrencyDetail = new OcorrencyDetailEntity();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool Closed { get; set; }
        public OcorrencyDetailEntity OcorrencyDetail { get; set; }
    }
}
