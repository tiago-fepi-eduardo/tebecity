using FluentValidation;
using System;
using System.Collections.Generic;
using TE.BE.City.Domain.Entity;

namespace TE.BE.City.Domain.Interfaces
{
    public interface IOrderService
    {
        bool Post(OrderEntity request);
        bool Put(OrderEntity request);
        bool Delete(int id);
        IEnumerable<OrderEntity> GetAll();
        OrderEntity GetById(int id);
    }
}
