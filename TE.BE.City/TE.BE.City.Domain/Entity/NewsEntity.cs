using System;
using System.Collections.Generic;
using System.Text;

namespace TE.BE.City.Domain.Entity
{
    public class NewsEntity : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Closed { get; set; }
    }
}
