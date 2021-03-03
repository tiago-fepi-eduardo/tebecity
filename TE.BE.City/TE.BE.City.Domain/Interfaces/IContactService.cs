using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TE.BE.City.Domain.Entity;

namespace TE.BE.City.Domain.Interfaces
{
    public interface IContactService
    {
        Task<bool> Post(ContactEntity request);
        Task<bool> Put(ContactEntity request);
        Task<bool> Delete(int id);
        Task<IEnumerable<ContactEntity>> GetAll();
        Task<ContactEntity> GetById(int id);
    }
}
