using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Meetup.Security.Shared.Repositories
{
    public interface IRepository<T>
    {
        T GetByKey(object key);

        IEnumerable<T> List();

        IEnumerable<T> List(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
