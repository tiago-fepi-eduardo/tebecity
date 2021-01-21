using System;
using System.Collections.Generic;
using System.Text;
using TE.BE.City.Domain.Entity;

namespace TE.BE.City.Domain.Interfaces
{
    public interface IOrderDomain
    {
        void ApplyBusinessRules(OrderEntity tokenEntity);
    }
}
