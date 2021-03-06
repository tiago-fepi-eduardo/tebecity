﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TE.BE.City.Domain.Entity;

namespace TE.BE.City.Domain.Interfaces
{
    public interface IOrderService
    {
        Task<OrderEntity> Post(OrderEntity request);
        Task<bool> Put(OrderEntity request);
        Task<bool> Delete(int id);
        Task<IEnumerable<OrderEntity>> GetAll(OrderEntity request, int skip, int limit);
        Task<OrderEntity> GetById(int id);
        Task<int> GetCount(OrderEntity request);
    }
}
