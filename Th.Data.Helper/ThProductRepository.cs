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
                mdInsert.CreatedDate = DateTime.Now;

                this._dbContext.Products.Add(mdInsert);
            }
        }

        public override void Update(Product mdUpdate)
        {
            try
            {
                Product mdProduct = this._dbContext.Products
                    .FirstOrDefault(p => p.Id == mdUpdate.Id);

                if (mdProduct != null)
                {
                    mdUpdate.UpdatedDate = DateTime.Now;
                    this._dbContext.Entry(mdProduct).CurrentValues.SetValues(mdUpdate);
                    foreach (ProductTranslation pt in mdUpdate.Translations)
                    {
                        ProductTranslation mdProductTranslation = this._dbContext.ProductTranslation
                            .Where(pt1 => pt1.ProductId == pt.ProductId 
                                && pt1.LanguageId == pt.LanguageId 
                                && pt1.ColumnName == pt.ColumnName)
                            .SingleOrDefault();

                        if (mdProductTranslation != null)
                        {
                            pt.Id = mdProductTranslation.Id;
                            this._dbContext.Entry(mdProductTranslation).CurrentValues.SetValues(pt);
                        }
                        else
                        {
                            this._dbContext.ProductTranslation.Add(pt);
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

        public IList<Product> Get(int page = 1, int pageSize = 10)
        {
            try
            {
                return this._dbContext.Products
                    .Include(p => p.Translations)
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
                    .Include(p => p.Translations)
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
                    .Include(p => p.Translations)
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

        public int CountProductByCategoryId(int categoryId = 0)
        {
            try
            {
                // Nếu cateogryId == 0 thì sẽ đếm tất cả các sản phẩm.
                return this.Entities
                    .Where(p => categoryId == 0 || p.CategoryId == categoryId)
                    .Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<Product> GetNewProductInCategory(int intCategoryId = 0, int intPage = 1, int intPagesize = 10)
        {
            try
            {
                var query = (from p
                             in this._dbContext.Products
                                .Include(p => p.Translations)
                                .Include(p => p.Category)
                             where intCategoryId == 0
                                 || p.CategoryId == intCategoryId
                             orderby p.CreatedDate
                             select p)
                            .Skip((intPage - 1) * intPagesize)
                            .Take(intPagesize);

                return query.ToList();
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
