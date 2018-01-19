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
using ThTest.Infrastructures.FacebookApi;
using System.Diagnostics;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThTest.Controllers
{
    public class HomeController : ThBaseController
    {
        private IThProductRepository _repoProduct;
        private IThCategoryRepository _repoCategory;
        private IThOrderRepository _repoOrder;

        private IFacebookService _facebookService;

        private const int PAGESIZE = 2;

        public HomeController(
            LoginSessionInfo loginSessionInfo, 
            IUnitOfWork unitOfWork,
            IFacebookService facebookService)
            : base(loginSessionInfo, unitOfWork)
        {
            this._repoCategory = this.UnitOfWork.CategoryRepo;
            this._repoProduct = this.UnitOfWork.ProductRepo;
            this._repoOrder = this.UnitOfWork.OrderRepo;

            this._facebookService = facebookService;
        }

        [AllowAnonymous]
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            HomeIndexViewModel vmHomeIndex = new HomeIndexViewModel
            {
                Categories = this._repoCategory.GetAllCategoryFirstPageProduct()
            };

            string appSecret = "dac137fc1003d0ec5d079c54b6b95de8";
            string appId = "170222766920220";
            string accessToken = await this._facebookService.GetAccessToken(appId, appSecret);
            var result = await this._facebookService.GetUserAsync(accessToken);

            Debug.WriteLine("Facebook user information");
            Debug.WriteLine("-------------------------------------------------------------------------");
            Debug.WriteLine($"Name = {result.Name}");

            Debug.WriteLine("-------------------------------------------------------------------------");

            return this.View(vmHomeIndex);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ContactUs()
        {
            Company mdCompany = this.UnitOfWork.CompanyRepo
                .GetAll()
                .FirstOrDefault();
            
            if (mdCompany != null)
            {
               return this.View(mdCompany);
            }

            return this.NotFound();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult AboutUs()
        {
            return this.View();
        }

        [Authorize(Roles = "Administrators")]
        public IActionResult IndexAdmin()
        {
            IndexAdminViewModel vmIndexAdmin = new IndexAdminViewModel
            {
                NewCategories = this._repoCategory.Get(fnOrderBy: f => f.OrderByDescending(s => s.CreatedDate), intPageSize: 4),
                NewProducts = this._repoProduct.Get(fnOrderBy: f => f.OrderByDescending(p => p.CreatedDate), intPageSize: 4),
                OrderNotShipped = this._repoOrder.GetOrderNotShip(1),
                Suppliers = this.UnitOfWork.SupplierRepo.Get(fnOrderBy: f => f.OrderByDescending(s => s.CreatedDate), intPageSize: 4),
            };

            return View(vmIndexAdmin);
        }
    }
}
