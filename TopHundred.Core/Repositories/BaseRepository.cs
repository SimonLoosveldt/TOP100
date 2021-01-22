using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TopHundred.Core.Entities;

namespace TopHundred.Core.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly TopContext _db;

        public BaseRepository(TopContext db)
        {
            _db = db;
        }

        public virtual void Add(T entity)
        {
            _db.Add(entity);
            _db.SaveChanges();
        }

        public virtual IQueryable<T> Search(Func<T, bool> predicate)
        {
            return _db.Set<T>().Where(predicate).AsQueryable();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _db.Set<T>();
        }

        public virtual T GetById(int id)
        {
            return _db.Find<T>(id);
        }

        public virtual void Remove(T entity)
        {
            _db.Remove(entity);
            _db.SaveChanges();
        }

        public virtual void Remove(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
            _db.SaveChanges();
        }
    }
}
