using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Th.Data.Helper;
using ThTest.Models.ViewModels;

namespace ThTest.Components
{
    [ViewComponent(Name = "NavigationMenu")]
    public class NavigationMenuViewComponents: ViewComponent
    {
        private IThCategoryRepository _repoCategory;

        public NavigationMenuViewComponents(IThCategoryRepository repoCategory)
        {
            this._repoCategory = repoCategory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int categoryId)
        {
            return this.View(new NavigationMenuViewModel
            {
                Categories = this._repoCategory.GetAll(),
                CurrentCategoryId = categoryId,
            });
        }
    }
}
