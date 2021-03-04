using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TE.BE.City.Domain.Entity;
using TE.BE.City.Domain.Interfaces;
using TE.BE.City.Infra.CrossCutting;
using System.Linq;
using TE.BE.City.Infra.CrossCutting.Enum;

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
            try
            {
                var userDb = (await _repository.Filter(c => c.Username == username)).FirstOrDefault();

                if (userDb != null && await _serviceDomain.IsValidPassword(password, userDb.Password))
                    userDb.Token = await _serviceDomain.GenerateJWTToken(userDb);
                else
                {
                    userDb = new UserEntity();
                    userDb.Error = new ErrorDetail()
                    {
                        Code = (int)ErrorCode.UserNotIdentified,
                        Type = ErrorCode.UserNotIdentified.ToString(),
                        Message = ErrorCode.UserNotIdentified.GetDescription()
                    };
                }

                return userDb;
            }
            catch (ExecptionHelper.ExceptionService ex)
            {
                throw new ExecptionHelper.ExceptionService(ex.Message);
            }
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
