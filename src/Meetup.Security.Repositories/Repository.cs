using Meetup.Security.Entities;
using Meetup.Security.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Meetup.Security.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        protected readonly SecurityDbContext SecurityDbContext;

        public Repository(SecurityDbContext dbContext)
        {
            SecurityDbContext = dbContext;
        }

        public T GetByKey(object key)
        {
            return SecurityDbContext.Set<T>().Find(key);
        }

        public IEnumerable<T> List()
        {
            return SecurityDbContext.Set<T>().AsEnumerable();
        }

        public IEnumerable<T> List(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return SecurityDbContext.Set<T>().Where(predicate).AsEnumerable();
        }

        public void Add(T entity)
        {
            SecurityDbContext.Set<T>().Add(entity);
            SecurityDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            SecurityDbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            SecurityDbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            SecurityDbContext.Set<T>().Remove(entity);
            SecurityDbContext.SaveChanges();
        }
    }
}
