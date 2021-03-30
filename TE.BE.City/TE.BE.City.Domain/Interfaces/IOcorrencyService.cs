using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TE.BE.City.Domain.Entity;

namespace TE.BE.City.Domain.Interfaces
{
    public interface IOcorrencyService
    {
        Task<IEnumerable<OcorrencyEntity>> GetAll(bool closed, int skip, int limit);
        Task<IEnumerable<OcorrencyEntity>> GetById(int id);
        Task<int> GetCount(bool? closed);
    }
}
