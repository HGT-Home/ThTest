using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Th.Models;

namespace Th.Data.Helper
{
    public class ThCategoryRepository : ThRepository<Category>, IThCategoryRepository, IDisposable
    {
        public ThCategoryRepository(ThDbContext dbContext)
            : base(dbContext)
        {
        }

        public override void Delete(Category mdDelete)
        {
            if (this._dbContext.Entry(mdDelete).State == EntityState.Detached)
            {
                this._dbContext.Attach(mdDelete);
            }

            this._dbContext.Categories.Remove(mdDelete);
        }

        public override void Insert(Category mdInsert)
        {
            this._dbContext.Categories.Add(mdInsert);
        }

        public override void Update(Category mdUpdate)
        {
            this._dbContext.Categories.Attach(mdUpdate);
            this._dbContext.Entry(mdUpdate).State = EntityState.Modified;
        }

        public override int Count()
        {
            return this.Entities.Count();
        }

        public void Dispose()
        {
            if (this._dbContext != null)
            {
                this._dbContext.Dispose();
            }
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await this._dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public IList<Category> GetAllCategoryFirstPageProduct()
        {
            try
            {
                return this.Entities
                    .Include(
                        c => c.Products.OrderBy(p => p.Id)
                        .Take(2)
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<Category> GetNewCategory(int intPage, int intPageSize)
        {
            try
            {
                return this.Entities
                    .OrderBy(c => c.CreatedDate)
                    .Skip((intPage - 1) * intPageSize)
                    .Take(intPageSize)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<Category> GetCategory(int intPage, int intPageSize)
        {
            try
            {
                return this.Entities
                    .OrderBy(c => c.Id)
                    .Skip((intPage - 1) * intPageSize)
                    .Take(intPageSize)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
