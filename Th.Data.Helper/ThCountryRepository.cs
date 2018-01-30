using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Th.Models;

namespace Th.Data.Helper
{
    public class ThCountryRepository : ThRepository<Country>, IThCountryRepository
    {
        public ThCountryRepository(ThDbContext dbContext)
            : base(dbContext)
        {

        }

        public override int Count()
        {
            return this.Entities.Count();
        }

        public override void Delete(Country mdDelete)
        {
            try
            {
                if (this._dbContext.Entry(mdDelete).State == EntityState.Detached)
                {
                    this._dbContext.Attach(mdDelete);
                }

                this._dbContext.Countries.Remove(mdDelete);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Insert(Country mdInsert)
        {
            try
            {
                this._dbContext.Countries.Add(mdInsert);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Update(Country mdUpdate)
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

        public Country Get(int cityId)
        {
            try
            {
                City city = this._dbContext.Cities.Include(c => c.Country).Where(c => c.Id == cityId).SingleOrDefault();

                return city.Country;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
