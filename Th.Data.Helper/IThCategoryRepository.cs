using System;
using System.Collections.Generic;
using System.Text;
using Th.Models;

namespace Th.Data.Helper
{
    public interface IThCategoryRepository: IThRepository<Category>
    {
        IList<Category> GetAllCategoryFirstPageProduct();

        IList<Category> GetNewCategory(int intPage, int intPageSize);

        IList<Category> GetCategory(int intPage, int intPageSize);
    }
}
