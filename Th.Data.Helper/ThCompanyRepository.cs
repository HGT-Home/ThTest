using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Th.Models;

namespace Th.Data.Helper
{
    public class ThCompanyRepository : ThRepository<Company>, IThCompanyRepository
    {
        public ThCompanyRepository(ThDbContext dbContext) 
            : base(dbContext)
        {
        }

        public override int Count()
        {
            try
            {
                return this._dbContext.Companies.Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Delete(Company mdDelete)
        {
            try
            {
                if (this._dbContext.Entry(mdDelete).State == EntityState.Detached)
                {
                    this._dbContext.Attach(mdDelete);
                }

                this._dbContext.Remove(mdDelete);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Insert(Company mdInsert)
        {
            try
            {
                this._dbContext.Companies.Add(mdInsert);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Update(Company mdUpdate)
        {
            try
            {
                Company mdCompany = this._dbContext.Companies.Where(c => c.Id == mdUpdate.Id).SingleOrDefault();
                if (mdCompany != null)
                {
                    this._dbContext.Entry(mdCompany).CurrentValues.SetValues(mdUpdate);
                    this._dbContext.Entry(mdCompany).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
