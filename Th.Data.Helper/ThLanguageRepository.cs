using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Th.Models;

namespace Th.Data.Helper
{
    public class ThLanguageRepository: ThRepository<Language>, IThLanguageRepository
    {
        public ThLanguageRepository(ThDbContext dbContext)
            : base(dbContext)
        {

        }

        public override void Delete(Language mdDelete)
        {
            if (this._dbContext.Entry(mdDelete).State == EntityState.Detached)
            {
                this._dbContext.Attach(mdDelete);
            }

            this._dbContext.Languages.Remove(mdDelete);
        }

        public override void Insert(Language mdInsert)
        {
            if (mdInsert != null)
            {
                this._dbContext.Languages.Add(mdInsert);
            }
        }

        public override void Update(Language mdUpdate)
        {
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

    }
}
