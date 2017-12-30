using System;
using System.Collections.Generic;
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
    }
}
