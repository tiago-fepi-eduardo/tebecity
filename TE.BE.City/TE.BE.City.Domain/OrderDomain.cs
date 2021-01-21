using System.Linq;
using System.Collections.Generic;
using TE.BE.City.Domain.Entity;
using TE.BE.City.Domain.Interfaces;

namespace TE.BE.City.Domain
{
    public class OrderDomain : IOrderDomain
    {
        public void ApplyBusinessRules(OrderEntity tokenEntity)
        {
            // Empty
        }
    }
}
