using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TE.BE.City.Domain.Entity;

namespace TE.BE.City.Domain.Interfaces
{
    public interface INewsService
    {
        Task<IEnumerable<NewsEntity>> GetAll(int skip, int limit);
        Task<IEnumerable<NewsEntity>> GetClosed(bool closed, int skip, int limit);
        Task<IEnumerable<NewsEntity>> GetById(int id);
        Task<int> GetCount(bool? closed);
    }
}
