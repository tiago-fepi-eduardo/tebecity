using TE.BE.City.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE.BE.City.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        bool Insert(T request);

        bool Delete(int id);

        bool Edit(T entity);

        IEnumerable<T> Select();

        T SelectById(int id);

        IEnumerable<T> Filter(Func<T, bool> predicate);
    }
}
