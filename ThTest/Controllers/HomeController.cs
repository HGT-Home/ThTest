using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Th.Data.Helper;
using Th.Models;
using Microsoft.AspNetCore.Authorization;
using ThTest.Models.ViewModels;
using ThTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Web.Helpers;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThTest.Controllers
{
    public class HomeController : ThBaseController
    {
        private IThProductRepository _repoProduct;
        private IThCategoryRepository _repoCategory;
        private IThOrderRepository _repoOrder;

        private const int PAGESIZE = 2;

        public HomeController(LoginSessionInfo loginSessionInfo, IUnitOfWork unitOfWork)
            : base(loginSessionInfo, unitOfWork)
        {
            this._repoCategory = this.UnitOfWork.CategoryRepo;
            this._repoProduct = this.UnitOfWork.ProductRepo;
            this._repoOrder = this.UnitOfWork.OrderRepo;
        }

        [AllowAnonymous]
        // GET: /<controller>/
        public IActionResult Index()
        {
            HomeIndexViewModel vmHomeIndex = new HomeIndexViewModel
            {
                Categories = this._repoCategory.GetAllCategoryFirstPageProduct()
            };

            return this.View(vmHomeIndex);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ContactUs()
        {
            Company mdCompany = this.UnitOfWork.CompanyRepo.GetAll().FirstOrDefault();
            
            if (mdCompany != null)
            {
               return this.View(mdCompany);
            }

            return this.NotFound();
        }

        [Authorize(Roles = "Administrators")]
        public IActionResult IndexAdmin()
        {
            IndexAdminViewModel vmIndexAdmin = new IndexAdminViewModel
            {
                NewCategories = this._repoCategory.GetNewCategory(1, 4),
                NewProducts = this._repoProduct.GetNewProductInCategory(0, 1, 4),
                OrderNotShipped = this._repoOrder.GetOrderNotShip(1),
            };

            return View(vmIndexAdmin);
        }

        //public IActionResult GetProductByCategory(int categoryId, int page)
        //{
        //    IList<Product> lstProductList = this._repoProduct.GetByCategoryId(categoryId, page, PAGESIZE);

        //    ProductListViewModel vmProductList = new ProductListViewModel
        //    {
        //        CurrentCategory = categoryId,
        //        PagingInfo = new PagingInfo
        //        {
        //            CurrentPage = page,
        //            ItemsPerPage = PAGESIZE,
        //            TotalItems = lstProductList.Count(),
        //        },
        //        Products = lstProductList,
        //        Categories = this._repoCategory.GetAll()
        //    };

        //    return this.View("Index", vmProductList);
        //}
    }
}
