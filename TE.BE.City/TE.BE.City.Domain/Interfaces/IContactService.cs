using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TE.BE.City.Domain.Entity;

namespace TE.BE.City.Domain.Interfaces
{
    public interface IContactService
    {
        Task<ContactEntity> Post(ContactEntity request);
        Task<ContactEntity> Put(ContactEntity request);
        Task<ContactEntity> Delete(int id);
        Task<IEnumerable<ContactEntity>> GetAll(int skip, int limit);
        Task<IEnumerable<ContactEntity>> GetClosed(bool closed, int skip, int limit);
        Task <IEnumerable<ContactEntity>> GetById(int id);
        Task<int> GetCount(bool? closed);
    }
}
