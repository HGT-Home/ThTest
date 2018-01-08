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
            return this.Entities.ToList();
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

        public virtual IList<T> Get(
            Expression<Func<T, bool>> expFilter = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> fnOrderBy = null, 
            int intPage = 1, 
            int intPageSize = 10)
        {
            try
            {
                IQueryable<T> query = this._dbContext.Set<T>();
                
                if (expFilter != null)
                {
                    query.Where(expFilter);
                }

                // Lấy các dữ liệu đa ngôn ngữ nếu như table đó có bảng đa ngôn ngữ.
                Type t = typeof(T);
                Type[] arrT = t.FindInterfaces((type, filter) =>
                    {
                        return type.FullName.Contains(filter.ToString());
                    },
                    typeof(ILanguageTranslation<>).FullName
                );

                if (arrT != null && arrT.Length > 0)
                {
                    foreach(var e in query)
                    {
                        this._dbContext.Entry(e).Collection(q => ((ILanguageTranslation<ITranslation>)q).Translations).Load();
                    }
                }

                if (fnOrderBy != null)
                {
                    return fnOrderBy(query).Skip((intPage - 1) * intPageSize).Take(intPageSize).ToList();
                }

                return query.Skip((intPage - 1) * intPageSize).Take(intPageSize).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
