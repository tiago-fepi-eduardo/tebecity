using System;
using System.Collections.Generic;
using System.Text;

namespace TE.BE.City.Domain.Entity
{
    public class ContactEntity : BaseEntity
    {
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
    }
}
