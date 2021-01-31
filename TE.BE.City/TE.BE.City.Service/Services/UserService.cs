using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TE.BE.City.Domain.Entity;
using TE.BE.City.Domain.Interfaces;
using TE.BE.City.Infra.CrossCutting;

namespace TE.BE.City.Service.Services
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> _repository;
        private IUserDomain _serviceDomain;

        public UserService(IRepository<UserEntity> repository, IUserDomain serviceDomain)
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

        public async Task<bool> Delete(int id)
        {
            try
            {
                return await _repository.Delete(id);
            }
            catch (ExecptionHelper.ExceptionService ex)
            {
                throw new ExecptionHelper.ExceptionService(ex.Message);
            }
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            try
            {
                return await _repository.Select();
            }
            catch (ExecptionHelper.ExceptionService ex)
            {
                throw new ExecptionHelper.ExceptionService(ex.Message);
            }
        }

        public async Task<UserEntity> GetById(int id)
        {
            try
            {
                return await _repository.SelectById(id);
            }
            catch (ExecptionHelper.ExceptionService ex)
            {
                throw new ExecptionHelper.ExceptionService(ex.Message);
            }
        }

        public async Task<bool> Post(UserEntity request)
        {
            request.Password = await _serviceDomain.Encrypt(request.Password);

            return await _repository.Insert(request);
        }

        public async Task<bool> Put(UserEntity request)
        {
            try
            {
                return await _repository.Edit(request);
            }
            catch (ExecptionHelper.ExceptionService ex)
            {
                throw new ExecptionHelper.ExceptionService(ex.Message);
            }
        }
    }
}
