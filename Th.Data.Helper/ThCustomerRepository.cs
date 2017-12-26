using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Th.Models;

namespace Th.Data.Helper
{
    public class ThCustomerRepository : ThRepository<Customer>, IThCustomerRepository
    {
        public ThCustomerRepository(ThDbContext dbContext)
            : base(dbContext)
        {

        }

        public override int Count()
        {
            return this.Entities.Count();
        }

        public override void Delete(Customer mdDelete)
        {
            try
            {
                if (mdDelete != null)
                {
                    if (this._dbContext.Entry(mdDelete).State == EntityState.Detached)
                    {
                        this._dbContext.Attach(mdDelete);
                    }

                    this._dbContext.Customers.Remove(mdDelete);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Insert(Customer mdInsert)
        {
            try
            {
                if (mdInsert != null)
                {
                    this._dbContext.Customers.Add(mdInsert);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Update(Customer mdUpdate)
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
