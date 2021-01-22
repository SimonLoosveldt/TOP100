using System;
using System.Collections.Generic;
using System.Linq;

namespace TopHundred.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        T GetById(int id);

        IQueryable<T> GetAll();
        IQueryable<T> Search(Func<T, bool> predicate);

        void Remove(T enitity);
        void Remove(IEnumerable<T> entities);
    }
}
