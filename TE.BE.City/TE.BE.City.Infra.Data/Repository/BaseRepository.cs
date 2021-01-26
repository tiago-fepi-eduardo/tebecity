using TE.BE.City.Domain.Interfaces;
using TE.BE.City.Domain.Entity;
using TE.BE.City.Infra.CrossCutting;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace TE.BE.City.Infra.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly TEBECityContext _context;

        public BaseRepository(TEBECityContext context)
        {
            _context = context;
        }
        
        public async Task<bool> Insert(T obj)
        {
            _context.Set<T>().Add(obj);
            var result = _context.SaveChanges();
            if (result > 0)
                return true;
            else
                return false;
        }

        public async Task<bool> Delete(int id)
        {
            var entityToDelete = _context.Set<T>().FirstOrDefault(e => e.Id == id);
            if (entityToDelete != null)
            {
                _context.Set<T>().Remove(entityToDelete);
                var result = _context.SaveChanges();
                if (result > 0)
                    return true;
            }
            return false;
        }

        public async Task<bool> Edit(T entity)
        {
            var editedEntity = _context.Set<T>().FirstOrDefault(e => e.Id == entity.Id);
            
            _context.Entry(editedEntity).CurrentValues.SetValues(entity);

            var result = _context.SaveChanges();
            if (result > 0)
                return true;
            else
                return false;
        }

        public async Task<IEnumerable<T>> Select()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<T> SelectById(int id)
        {
            return _context.Set<T>().FirstOrDefault(e => e.Id == id);
        }

        public async Task<IEnumerable<T>> Filter(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }
    }
}
