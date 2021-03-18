using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TE.BE.City.Domain.Entity;

namespace TE.BE.City.Domain.Interfaces
{
    public interface IOrderStatusService
    {
        Task<IEnumerable<OrderStatusEntity>> GetAll(int skip, int limit);
        Task<IEnumerable<OrderStatusEntity>> GetClosed(bool closed, int skip, int limit);
        Task<IEnumerable<OrderStatusEntity>> GetById(int id);
    }
}
