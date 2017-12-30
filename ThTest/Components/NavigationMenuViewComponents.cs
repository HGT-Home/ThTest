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
        private IUnitOfWork _unitOfWork;

        public NavigationMenuViewComponents(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync(int categoryId)
        {
            return this.View(new NavigationMenuViewModel
            {
                Categories = this._unitOfWork.CategoryRepo.GetAll(),
                CurrentCategoryId = categoryId,
            });
        }
    }
}
