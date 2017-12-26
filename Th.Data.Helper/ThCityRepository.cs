using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Th.Models;

namespace Th.Data.Helper
{
    public class ThCityRepository : ThRepository<City>, IThCityRepository
    {
        public ThCityRepository(ThDbContext dbContext)
            : base(dbContext)
        {

        }

        public IList<City> GetCityByCountryId(int countryId)
        {
            try
            {
                return this.Entities.Where(c => c.CountryId == countryId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override int Count()
        {
            return this.Entities.Count();
        }

        public override void Delete(City mdDelete)
        {
            try
            {
                if (this._dbContext.Entry(mdDelete).State == EntityState.Detached)
                {
                    this._dbContext.Attach(mdDelete);
                }

                this._dbContext.Cities.Remove(mdDelete);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public override void Insert(City mdInsert)
        {
            try
            {
                this._dbContext.Cities.Add(mdInsert);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Update(City mdUpdate)
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
