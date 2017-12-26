using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Th.Models;
using System.Linq;

namespace Th.Data.Helper
{
    public class ThProductRepository : ThRepository<Product>, IThProductRepository, IDisposable
    {

        public ThProductRepository(ThDbContext dbContext)
            : base(dbContext)
        {
        }

        public override void Delete(Product mdDelete)
        {
            if (this._dbContext.Entry(mdDelete).State == EntityState.Detached)
            {
                this._dbContext.Attach(mdDelete);
            }

            this._dbContext.Products.Remove(mdDelete);
        }

        public override void Insert(Product mdInsert)
        {
            if (mdInsert != null)
            {
                this._dbContext.Products.Add(mdInsert);
            }
        }

        public override void Update(Product mdUpdate)
        {
            Product mdProduct = this._dbContext.Products.FirstOrDefault(p => p.Id == mdUpdate.Id);
            if (mdUpdate != null)
            {
                this._dbContext.Attach(mdUpdate);
                this._dbContext.Entry(mdUpdate).State = EntityState.Modified;
            }
        }

        public override int Count()
        {
            return this.Entities.Count();
        }

        public IList<Product> Get(int page = 1, int pageSize = 10)
        {
            try
            {
                if (page == 0)
                {
                    return this.GetAll();
                }

                return this._dbContext.Products
                    .OrderBy(p => p.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Product GetById(int id)
        {
            try
            {
                return this._dbContext.Products
                    .FirstOrDefault(p => p.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<Product> GetByCategoryId(int categoryId, int page = 1, int pageSize = 10)
        {
            try
            {
                return this._dbContext.Products
                    .Where(p => p.CategoryId == categoryId)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Dispose()
        {
            if (this._dbContext != null)
            {
                this._dbContext.Dispose();
            }
        }
    }
}
