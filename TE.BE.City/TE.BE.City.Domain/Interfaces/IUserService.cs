using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TE.BE.City.Domain.Entity;

namespace TE.BE.City.Domain.Interfaces
{
    public interface IUserService
    {
        Task<UserEntity> Authenticate(string username, string password);
        Task<IEnumerable<UserEntity>> GetAll();
    }
}
