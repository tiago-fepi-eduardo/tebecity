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

        public async Task<IEnumerable<ContactEntity>> GetAll()
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

        public async Task<IEnumerable<ContactEntity>> GetById(int id)
        {
            try
            {
                var contactsEntity = new List<ContactEntity>();
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
            try
            {
                return await _repository.Filter(c => c.Closed == closed);
            }
            catch (ExecptionHelper.ExceptionService ex)
            {
                throw new ExecptionHelper.ExceptionService(ex.Message);
            }
        }

        public async Task<bool> Post(ContactEntity request)
        {
            try
            {
                return await _repository.Insert(request);
            }
            catch (ExecptionHelper.ExceptionService ex)
            {
                throw new ExecptionHelper.ExceptionService(ex.Message);
            }
        }

        public async Task<bool> Put(ContactEntity request)
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
