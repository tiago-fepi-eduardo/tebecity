using System;
using System.Collections.Generic;
using System.Text;

namespace TE.BE.City.Domain.Entity
{
    public class OcorrencyDetailEntity : BaseEntity
    {
        public string Description { get; set; }

        public OcorrencyEntity OcorrencyId { get; set; }
    }
}
