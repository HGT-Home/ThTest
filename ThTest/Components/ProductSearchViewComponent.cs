using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThTest.Models.ViewModels;

namespace ThTest.Components
{
    [ViewComponent(Name = "ProductSearch")]
    public class ProductSearchViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return this.View(new ProductSearchViewModel());
        }
    }
}
