using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TopHundred.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        T GetById(int id);

        IEnumerable<T> GetAll();
        IEnumerable<T> Search(Expression<Func<T, bool>> predicate);

        void Remove(T enitity);
        void Remove(IEnumerable<T> entities);
    }
}
