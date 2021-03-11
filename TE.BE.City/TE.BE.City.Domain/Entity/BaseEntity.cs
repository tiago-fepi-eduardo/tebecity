using System;
using System.Collections.Generic;
using System.Text;
using TE.BE.City.Infra.CrossCutting;

namespace TE.BE.City.Domain.Entity
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public ErrorDetail Error { get; set; }

        public bool IsSuccess
        {
            get
            {
                if (Error == null)
                    return true;
                else
                    return false;
            }
        }
    }
}
