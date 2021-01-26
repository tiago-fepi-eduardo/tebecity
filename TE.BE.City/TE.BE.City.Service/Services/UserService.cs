using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TE.BE.City.Domain.Entity;
using TE.BE.City.Domain.Interfaces;

namespace TE.BE.City.Service.Services
{
    public class UserService : IUserService
    {
        private IRepository<OrderEntity> _repository;
        private IUserDomain _serviceDomain;

        public UserService(IRepository<OrderEntity> repository, IUserDomain serviceDomain)
        {
            _repository = repository;
            _serviceDomain = serviceDomain;
        }
        public async Task<UserEntity> Authenticate(string username, string password)
        {
            // validate to db.
            var user = new UserEntity()
            {
                Id = 1,
                FirstName = "Joe",
                LastName = "Ramone",
                Username = "r",
                Password = "123"
            };
            
            // generate token to access
            user.Token = await _serviceDomain.GenerateJWTToken(user);
            
            return user;
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
