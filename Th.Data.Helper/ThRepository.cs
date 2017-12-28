using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Th.Models;
using System.Linq;

namespace Th.Data.Helper
{
    public abstract class ThRepository<T> : IThRepository<T> where T : ThBaseModel
    {
        protected ThDbContext _dbContext;

        public ThRepository(ThDbContext dbContext)
        {
            this._dbContext = dbContext;
            this.Entities = this._dbContext.Set<T>();
        }

        public virtual IQueryable<T> Entities { get; }

        public virtual IList<T> GetAll()
        {
            return this.Entities.ToList<T>();
        }

        public virtual T GetById<TKey>(params object[] keys)
        {
            T entity = (T)this._dbContext.Find(typeof(T), keys);
            return entity;
        }

        public abstract void Delete(T mdDelete);

        public abstract void Insert(T mdInsert);

        public abstract void Update(T mdUpdate);

        public abstract int Count();
    }
}
