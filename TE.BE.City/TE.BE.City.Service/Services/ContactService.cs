using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TE.BE.City.Domain.Entity;
using TE.BE.City.Domain.Interfaces;
using TE.BE.City.Infra.CrossCutting;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TE.BE.City.Infra.CrossCutting.Enum;

namespace TE.BE.City.Service.Services
{
    public class ContactService : IContactService
    {
        private readonly IRepository<ContactEntity> _repository;
        
        public ContactService(IRepository<ContactEntity> repository)
        {
            _repository = repository;
        }
        
        public async Task<ContactEntity> Delete(int id)
        {
            var contactEntity = new ContactEntity();

            try
            {
                var result = await _repository.Delete(id);
                if (result)
                    return contactEntity;
                else
                {
                    contactEntity.Error = new ErrorDetail()
                    {
                        Code = (int)ErrorCode.SearchHasNoResult,
                        Type = ErrorCode.SearchHasNoResult.ToString(),
                        Message = ErrorCode.SearchHasNoResult.GetDescription()
                    };
                }

                return contactEntity;
            }
            catch (ExecptionHelper.ExceptionService ex)
            {
                throw new ExecptionHelper.ExceptionService(ex.Message);
            }
        }

        public async Task<IEnumerable<ContactEntity>> GetAll()
        {
            var contactsEntity = new List<ContactEntity>();

            try
            {
                var result = await _repository.Select();

                if (result != null)
                    return result;
                else
                {
                    var contactEntity = new ContactEntity()
                    {
                        Error = new ErrorDetail()
                        {
                            Code = (int)ErrorCode.SearchHasNoResult,
                            Type = ErrorCode.SearchHasNoResult.ToString(),
                            Message = ErrorCode.SearchHasNoResult.GetDescription()
                        }
                    };
                    contactsEntity.Add(contactEntity);
                }

                return contactsEntity;
            }
            catch (ExecptionHelper.ExceptionService ex)
            {
                throw new ExecptionHelper.ExceptionService(ex.Message);
            }
        }

        public async Task<IEnumerable<ContactEntity>> GetById(int id)
        {
            var contactsEntity = new List<ContactEntity>();

            try
            {
                var result =  await _repository.SelectById(id);

                if(result != null)
                    contactsEntity.Add(result);
                else
                {
                    var contactEntity = new ContactEntity()
                    {
                        Error = new ErrorDetail()
                        {
                            Code = (int)ErrorCode.SearchHasNoResult,
                            Type = ErrorCode.SearchHasNoResult.ToString(),
                            Message = ErrorCode.SearchHasNoResult.GetDescription()
                        }
                    };
                    contactsEntity.Add(contactEntity);
                }

                return contactsEntity;
            }
            catch (ExecptionHelper.ExceptionService ex)
            {
                throw new ExecptionHelper.ExceptionService(ex.Message);
            }
        }

        public async Task<IEnumerable<ContactEntity>> GetClosed(bool closed)
        {
            var contactsEntity = new List<ContactEntity>();

            try
            {
                var result = await _repository.Filter(c => c.Closed == closed);

                if (result != null)
                    return result;
                else
                {
                    var contactEntity = new ContactEntity()
                    {
                        Error = new ErrorDetail()
                        {
                            Code = (int)ErrorCode.SearchHasNoResult,
                            Type = ErrorCode.SearchHasNoResult.ToString(),
                            Message = ErrorCode.SearchHasNoResult.GetDescription()
                        }
                    };
                    contactsEntity.Add(contactEntity);
                }

                return contactsEntity;
            }
            catch (ExecptionHelper.ExceptionService ex)
            {
                throw new ExecptionHelper.ExceptionService(ex.Message);
            }
        }

        public async Task<ContactEntity> Post(ContactEntity request)
        {
            var contactEntity = new ContactEntity();

            try
            {
                var result = await _repository.Insert(request);

                if (result)
                    return contactEntity;
                else
                {
                    contactEntity.Error = new ErrorDetail()
                    {
                        Code = (int)ErrorCode.InsertContactFail,
                        Type = ErrorCode.InsertContactFail.ToString(),
                        Message = ErrorCode.InsertContactFail.GetDescription()
                    };
                }

                return contactEntity;
            }
            catch (ExecptionHelper.ExceptionService ex)
            {
                throw new ExecptionHelper.ExceptionService(ex.Message);
            }
        }

        public async Task<ContactEntity> Put(ContactEntity request)
        {
            var contactEntity = new ContactEntity();

            try
            {
                contactEntity = await _repository.SelectById(request.Id);
                contactEntity.Closed = request.Closed;
                contactEntity.CreatedAt = request.CreatedAt;

                var result = await _repository.Edit(contactEntity);

                if (result)
                    return contactEntity;
                else
                {
                    contactEntity.Error = new ErrorDetail()
                    {
                        Code = (int)ErrorCode.InsertContactFail,
                        Type = ErrorCode.InsertContactFail.ToString(),
                        Message = ErrorCode.InsertContactFail.GetDescription()
                    };
                }

                return contactEntity;
            }
            catch (ExecptionHelper.ExceptionService ex)
            {
                throw new ExecptionHelper.ExceptionService(ex.Message);
            }
        }
    }
}
