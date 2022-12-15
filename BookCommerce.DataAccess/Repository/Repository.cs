using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BookCommerce.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookCommerce.DataAccess.Repository
{
    public class Repository<T>:IRepository<T> where T: class
    {
        private readonly Konteksti _konteksti;
        internal DbSet<T> dbSet;
        public Repository(Konteksti konteksti)
        {
            _konteksti = konteksti;
            dbSet = _konteksti.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filteri)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filteri);
            return query.FirstOrDefault();
        }

        public void Add(T entiteti)
        {
            dbSet.Add(entiteti);
        }

        public void Remove(T entiteti)
        {
            dbSet.Remove(entiteti);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
