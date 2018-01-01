using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Th.Models;
using System.Linq;
using System.Linq.Expressions;

namespace Th.Data.Helper
{
    public abstract class ThRepository<T> : IThRepository<T> where T : ThBaseModel
    {
        protected ThDbContext _dbContext;

        protected string CurrentLanguage { get; set; }

        public virtual IQueryable<T> Entities { get; }

        public ThRepository(ThDbContext dbContext)
        {
            this._dbContext = dbContext;
            this.Entities = this._dbContext.Set<T>();
        }

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

        public virtual IList<T> Get(Expression<Func<T, bool>> expFilter, Func<IQueryable<T>, IOrderedQueryable<T>> fnOrderBy)
        {
            try
            {
                IQueryable<T> query = this._dbContext.Set<T>();
                
                if (expFilter != null)
                {
                    query.Where(expFilter);
                }

                if (fnOrderBy != null)
                {
                    return fnOrderBy(query).ToList();
                }

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
