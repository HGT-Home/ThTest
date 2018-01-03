using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Th.Models;

namespace Th.Data.Helper
{
    public class ThProductStatusReposirtory : ThRepository<ProductStatus>, IThProductStatusRepository
    {
        public ThProductStatusReposirtory(ThDbContext dbContext) 
            : base(dbContext)
        {
        }

        public override int Count()
        {
            return this._dbContext.ProductStatuses.Count();
        }

        public override void Delete(ProductStatus mdDelete)
        {
            try
            {
                if (this._dbContext.Entry(mdDelete).State == EntityState.Detached)
                {
                    this._dbContext.Attach(mdDelete);
                }

                this._dbContext.ProductStatuses.Remove(mdDelete);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Insert(ProductStatus mdInsert)
        {
            try
            {
                if (mdInsert != null)
                {
                    this._dbContext.ProductStatuses.Add(mdInsert);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Update(ProductStatus mdUpdate)
        {
            try
            {
                if (mdUpdate != null)
                {
                    this._dbContext.Attach(mdUpdate);
                    this._dbContext.Entry(mdUpdate).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
