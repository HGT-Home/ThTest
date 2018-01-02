using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Th.Models;

namespace Th.Data.Helper
{
    public interface IThProductRepository: IThRepository<Product>
    {
        IList<Product> Get(int page = 1, int pageSize = 10);

        Product GetById(int id);

        IList<Product> GetByCategoryId(int categoryId, int page = 1, int pageSize = 10);

        int CountProductByCategoryId(int categoryId = 0);

        IList<Product> GetNewProductInCategory(int intCategoryId = 0, int intPage = 1, int intPagesize = 10);

        (IList<Product> products, int totalItem) Search(string keyword, Func<IQueryable<Product>, IOrderedQueryable<Product>> fnOrderBy = null, int intPage = 1, int intPageSize = 10);
    }
}
