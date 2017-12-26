using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Th.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Th.Data.Helper
{
    public class ThSupplierRepository : ThRepository<Supplier>, IThSupplierRepository, IDisposable
    {
        public ThSupplierRepository(ThDbContext dbContext)
            : base(dbContext)
        {
        }

        public override void Delete(Supplier mdDelete)
        {
            if (this._dbContext.Entry(mdDelete).State == EntityState.Detached)
            {
                this._dbContext.Attach(mdDelete);
            }

            this._dbContext.Suppliers.Remove(mdDelete);
        }

        public override void Insert(Supplier mdInsert)
        {
            if (mdInsert != null)
            {
                this._dbContext.Suppliers.Add(mdInsert);
            }
        }

        public override void Update(Supplier mdUpdate)
        {
            Supplier mdSupplier = this._dbContext.Suppliers.FirstOrDefault(s => s.Id == mdUpdate.Id);
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

        public async Task<Supplier> GetById(string id)
        {
            return await this._dbContext.Suppliers
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public void Dispose()
        {
            if (this._dbContext != null)
            {
                this._dbContext.Dispose();
            }
        }
    }
}
