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
            try
            {
                Category mdCategory = this.GetById(mdUpdate.Id);

                if (mdCategory != null)
                {
                    this._dbContext.Entry(mdCategory).CurrentValues.SetValues(mdUpdate);
                    foreach(CategoryTranslation ctr in mdUpdate.Translations)
                    {
                        CategoryTranslation mdCategoryTranslation = this._dbContext.CategoryTranslations
                            .Where(t => t.CategoryId == ctr.CategoryId
                                    && t.LanguageId == ctr.LanguageId
                                    && t.ColumnName == ctr.ColumnName)
                            .FirstOrDefault();

                        if (mdCategoryTranslation != null)
                        {
                            ctr.Id = mdCategoryTranslation.Id;
                            this._dbContext.Entry(mdCategoryTranslation).CurrentValues.SetValues(ctr);
                        }
                        else
                        {
                            this._dbContext.CategoryTranslations.Add(ctr);
                        }
                    }
                }
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
                // Get all categories.
                var query = from c
                            in this._dbContext.Categories
                            select c;
                IList<Category> lstAllCategory = query.ToList();

                foreach (Category c in lstAllCategory)
                {
                    this._dbContext.Entry(c)
                        .Collection(c1 => c1.Products);

                    c.Products = this._dbContext.Entry(c)
                        .Collection(c1 => c1.Products)
                        .Query()
                        .OrderByDescending(p => p.CreatedDate)
                        .Take(4)
                        .Include(p => p.Translations)
                        .ToList();
                }

                return lstAllCategory;
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
                return this._dbContext.Categories
                    .Include(c => c.Translations)
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
                return this._dbContext.Categories
                    .Include(c => c.Translations)
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

        public Category GetById(int id)
        {
            try
            {
                return this._dbContext.Categories
                    .Include(c => c.Translations)
                    .Where(c => c.Id == id)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                Category mdDelete = this.GetById(id);

                if (mdDelete != null)
                {
                    this.Delete(mdDelete);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override IList<Category> GetAll()
        {
            try
            {
                return (from c
                        in this._dbContext.Categories
                            .Include(c => c.Translations)
                        select c).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
