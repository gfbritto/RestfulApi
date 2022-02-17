using Microsoft.EntityFrameworkCore;
using RestfulApi.Models.Base;
using RestfulApi.Repository.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace RestfulApi.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly RestfulApiDbContext _context;

        private DbSet<T> _dataSet;

        public GenericRepository(RestfulApiDbContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }

        public T Create(T item)
        {
            _dataSet.Add(item);
            _context.SaveChanges();
            return item;
        }

        public void Delete(long id)
        {
            var item = FindById(id);

            if (item != null)
            {
                _dataSet.Remove(item);
                _context.SaveChanges();
            }
        }

        public List<T> FindAll()
        {
            return _dataSet.ToList();
        }

        public T FindById(long id)
        {
            return _dataSet.SingleOrDefault(item => item.Id.Equals(id));
        }

        public T Update(T item)
        {
            var result = FindById(item.Id);

            if (result != null)
            {
                _context.Entry(result).CurrentValues.SetValues(item);
                _context.SaveChanges();
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
