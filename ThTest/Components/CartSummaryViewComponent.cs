using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThTest.Models;

namespace ThTest.Components
{
    [ViewComponent(Name = "CartSummary")]
    public class CartSummaryViewComponent: ViewComponent
    {
        private Cart _cart;

        public CartSummaryViewComponent(Cart cart)
        {
            this._cart = cart;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return this.View(this._cart);
        }
    }
}
