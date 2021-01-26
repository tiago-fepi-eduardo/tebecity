using System.Linq;
using System.Collections.Generic;
using TE.BE.City.Domain.Entity;
using TE.BE.City.Domain.Interfaces;
using System.Threading.Tasks;

namespace TE.BE.City.Domain
{
    public class OrderDomain : IOrderDomain
    {
        public Task ApplyBusinessRules(OrderEntity tokenEntity)
        {
            // Empty
            return Task.CompletedTask;
        }
    }
}
