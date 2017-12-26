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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThTest.Controllers
{
    public class HomeController : ThBaseController
    {
        private IUnitOfWork _unitOfWork;
        private IThProductRepository _repoProduct;
        private IThCategoryRepository _repoCategory;
        private IThOrderRepository _repoOrder;

        private const int PAGESIZE = 2;

        public HomeController(LoginSessionInfo loginSessionInfo, IUnitOfWork unitOfWork)
            : base(loginSessionInfo)
        {
            this._unitOfWork = unitOfWork;
            this._repoCategory = this._unitOfWork.CategoryRepo;
            this._repoProduct = this._unitOfWork.ProductRepo;
            this._repoOrder = this._unitOfWork.OrderRepo;
        }

        [AllowAnonymous]
        // GET: /<controller>/
        public IActionResult Index()
        {
            HomeIndexViewModel vmHomeIndex = new HomeIndexViewModel
            {
                Categories = (from c in
                                 this._repoCategory.Entities

                              select new Category
                              {
                                  Name = c.Name,
                                  CreatedBy = c.CreatedBy,
                                  CreatedDate = c.CreatedDate,
                                  Description = c.Description,
                                  Id = c.Id,
                                  ImageBinary = c.ImageBinary,
                                  ImagePath = c.ImagePath,
                                  NameVn = c.NameVn,
                                  UpdatedBy = c.UpdatedBy,
                                  UpdatedDate = c.UpdatedDate,
                                  Products = c.Products.OrderByDescending(p => p.Id).Take(4).ToList()
                              }).ToList()
                             
            };

            return this.View(vmHomeIndex);

            //page = page == 0 ? 1 : page;

            //return View(new ProductListViewModel
            //{
            //    Products = this._repoProduct.Get(page, PAGESIZE),
            //    Categories = this._repoCategory.GetAll(),
            //    PagingInfo = new PagingInfo
            //    {
            //        CurrentPage = page,
            //        ItemsPerPage = PAGESIZE,
            //        TotalItems = this._repoProduct.Count()
            //    }
            //});
        }

        [Authorize(Roles = "Administrators")]
        public IActionResult IndexAdmin()
        {
            IndexAdminViewModel vmIndexAdmin = new IndexAdminViewModel
            {
                NewCategories = this._repoCategory.GetNewCategory(1, 4),
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
