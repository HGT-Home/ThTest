using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Th.Data.Helper;
using Th.Models;
using ThTest.Models.ViewModels;
using ThTest.Infrastructures;
using ThTest.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThTest.Controllers
{
    public class CartController : ThBaseController
    {
        private IStringLocalizer<CartController> _localizer;
        //private IThProductRepository _repoProduct;

        private IUnitOfWork _unitOfWork;

        private Cart _cart;

        public CartController(LoginSessionInfo loginSessionInfo, IUnitOfWork unitOfWork, Cart cartService, IStringLocalizer<CartController> localizer)
            : base(loginSessionInfo)
        {
            this._unitOfWork = unitOfWork;

            this._localizer = localizer;
            this._cart = cartService;
        }

        [AllowAnonymous]
        // GET: /<controller>/
        public IActionResult Index(string returnUrl)
        {
            return View(new CartListViewModel
            {
                Cart = this._cart,
                ReturnUrl = this.Url.IsLocalUrl(returnUrl)? returnUrl: "/",
            });
        }

        [AllowAnonymous]
        [HttpPost]
        public RedirectToActionResult AddToCart(int id, string returnUrl)
        {
            Product mdProduct = this._unitOfWork.ProductRepo.GetById(id);
            if (mdProduct != null)
            {
                this._cart.AddItem(mdProduct, 1);
            }

            return this.RedirectToAction("Index", new { returnUrl });
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToActionResult RemoveFromCart(int id, string returnUrl)
        {
            Product mdProduct = this._unitOfWork.ProductRepo.GetById(id);

            if (mdProduct != null)
            {
                this._cart.RemoveLine(mdProduct);
            }

            return this.RedirectToAction("Index", new { returnUrl });
        }
    }
}
