﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TE.BE.City.Domain.Entity;

namespace TE.BE.City.Domain.Interfaces
{
    public interface IUserService
    {
        Task<UserEntity> Authenticate(string username, string password);       
        Task<UserEntity> Post(UserEntity request);
        Task<bool> Put(UserEntity request);
        Task<bool> Delete(int id);
        Task<IEnumerable<UserEntity>> GetAll();
        Task<UserEntity> GetById(int id);
    }
}
