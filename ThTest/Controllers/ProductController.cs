using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Th.Data.Helper;
using Th.Models;
using ThTest.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using ThTest.Models;
using ThTest.Infrastructures;
using ThTest.Models.Helpers;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThTest.Controllers
{
    public class ProductController : ThBaseController
    {
        private IUnitOfWork _unitOfWork;
        private IThProductRepository _repoProduct;
        private IThSupplierRepository _repoSupplier;
        private IThCategoryRepository _repoCategory;
        private readonly IStringLocalizer _localizer;
        private IPathProvider _pvdPath;
        private const int PAGESIZE = 10;

        public ProductController(
            LoginSessionInfo loginSessionInfo,
            IPathProvider pvdPath,
            IUnitOfWork unitOfWork,
            IStringLocalizer<ProductController> localizer)
            : base(loginSessionInfo)
        {
            this._pvdPath = pvdPath;

            // Repositories.
            this._unitOfWork = unitOfWork;
            this._repoProduct = this._unitOfWork.ProductRepo;
            this._repoSupplier = this._unitOfWork.SupplierRepo;
            this._repoCategory = this._unitOfWork.CategoryRepo;
            
            // Localization.
            this._localizer = localizer;
        }

        // GET: /<controller>/
        public IActionResult Index(int page)
        {
            IList<Product> lstProductList = this._repoProduct.Get(page, PAGESIZE);
            IList<Category> lstCategory = this._repoCategory.GetAll();

            ProductListViewModel vmProductList = new ProductListViewModel
            {
                CurrentCategory = 0,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PAGESIZE,
                    TotalItems = lstProductList.Count(),
                },
                Products = lstProductList,
                Categories = lstCategory
            };
            return this.View(vmProductList);

        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetProductByCategoryId(int categoryId, int page)
        {
            IList<Product> lstProductList = categoryId == 0 ? this._repoProduct.Get(page, PAGESIZE) : this._repoProduct.GetByCategoryId(categoryId, page, PAGESIZE);
            IList<Category> lstCategory = this._repoCategory.GetAll();

            ProductListViewModel vmProductList = new ProductListViewModel
            {
                CurrentCategory = categoryId,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PAGESIZE,
                    TotalItems = lstProductList.Count(),
                },
                Products = lstProductList,
                Categories = lstCategory
            };

            return this.View("ProductList", vmProductList);
        }

        [HttpGet]
        [Authorize(Roles = "Administrators")]
        public IActionResult Add()
        {
            EditProductViewModel vmEditProduct = new EditProductViewModel
            {
                Categories = this._repoCategory.GetAll().ToList(),
                Suppliers = this._repoSupplier.GetAll().ToList(),
                Image = "/imgs/no-image.png",
                Mode = ThAction.Add
            };

            return this.View("EditProduct", vmEditProduct);
        }

        [HttpGet]
        [Authorize(Roles = "Administrators")]
        public IActionResult Edit(int id)
        {
            Product mdProduct = this._repoProduct.GetById(id);
            EditProductViewModel vmEditProduct = mdProduct.Map<EditProductViewModel>();
            vmEditProduct.Categories = this._repoCategory.GetAll().ToList();
            vmEditProduct.Suppliers = this._repoSupplier.GetAll().ToList();
            vmEditProduct.Mode = ThAction.Edit;

            return this.View("EditProduct", vmEditProduct);
        }

        [HttpPost]
        [Authorize(Roles = "Administrators")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(EditProductViewModel editProductViewModel)
        {
            if (this.ModelState.IsValid)
            {
                Product p =  editProductViewModel.Map<Product>();

                IFormFile file = editProductViewModel.FileImage;

                if (file != null)
                {
                    p.Image = file.SaveImageFile(ImageFolder.Product, this._pvdPath);
                    p.ImageBinary = file.GetBytes();
                }

                if (editProductViewModel.Mode == ThAction.Edit)
                {
                    p.CreatedBy = p.UpdatedBy = this.User.Identity.Name;
                    p.CreatedDate = p.UpdatedDate = DateTime.Now;
                    this._repoProduct.Update(p);
                }
                else
                {
                    p.UpdatedBy = this.User.Identity.Name;
                    p.UpdatedDate = DateTime.Now;
                    this._repoProduct.Insert(p);
                }

                await this._unitOfWork.SaveAsync();
                this.TempData["Message"] = string.Format(this._localizer["Product {0} has been saved."], p.Name);

                return this.RedirectToAction("IndexAdmin", "Home");
            }

            return this.View("EditProduct", editProductViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Product mdProduct = this._repoProduct.Entities
                .Where(p => p.Id == id)
                .SingleOrDefault();

            if (mdProduct != null)
            {
                this._repoProduct.Delete(mdProduct);
                await this._unitOfWork.SaveAsync();

                this.TempData["Message"] = string.Format(this._localizer["Product {0} has been deleted."], mdProduct.Name);
                return this.RedirectToAction("Index", "Home");
            }

            return this.NotFound();
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return this.View("EditCategory", new EditCategoryViewModel() { Mode = ThAction.Add });
        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            Category mdCategory = this._repoCategory.GetById(id);
            if (mdCategory != null)
            {
                EditCategoryViewModel vmCategory = mdCategory.Map<EditCategoryViewModel>();

                return this.View("EditCategory", vmCategory);
            }

            return this.NotFound();
        }

        [HttpPost]
        public IActionResult DeleteCatgory(int categoryId)
        {
            try
            {
                if (categoryId != 0)
                {
                    this._repoCategory.Delete(categoryId);
                    this._unitOfWork.Save();
                }

                return this.RedirectToAction("ShowAllCategroy");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveCategory(EditCategoryViewModel vmEditCategory)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    Category c = vmEditCategory.Map<Category>();

                    // Upload file.
                    IFormFile file = vmEditCategory.FileImage;
                    if (file != null)
                    {
                        c.ImageBinary = file.GetBytes();
                        c.ImagePath = file.SaveImageFile(ImageFolder.Category, this._pvdPath);
                    }

                    switch (vmEditCategory.Mode)
                    {
                        case ThAction.Add:
                            c.CreatedBy = c.UpdatedBy = this.User.Identity.Name;
                            c.CreatedDate = c.UpdatedDate = DateTime.UtcNow;
                            this._repoCategory.Insert(c);
                            break;
                        case ThAction.Edit:
                            c.UpdatedBy = this.User.Identity.Name;
                            c.UpdatedDate = DateTime.UtcNow;
                            this._repoCategory.Update(c);
                            break;
                    }

                    await this._unitOfWork.SaveAsync();

                    this.TempData["Message"] = string.Format(this._localizer["Category {0} has been saved."], c.Name);

                    return this.RedirectToAction(nameof(HomeController.IndexAdmin), "Home");
                }

                return this.View(vmEditCategory);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ShowProductDetails(int productId)
        {
            try
            {
                ProductDetailsViewModel vmP = new ProductDetailsViewModel
                {
                    Product = this._repoProduct.GetById(productId)
                };

                return this.View("ProductDetails", vmP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Search(string keyword, int page = 1, int pagesize = PAGESIZE)
        {
            try
            {
                keyword = string.IsNullOrEmpty(keyword)? string.Empty: keyword.Trim();
                var query = this._repoProduct.Entities
                        .Where(p => p.Name.Contains(keyword) || p.Description.Contains(keyword))
                        .OrderBy(p => p.Name);

                SearchResultViewModel vmSearchResult = new SearchResultViewModel
                {
                    Keyword = keyword,
                    Products = query
                        .Skip((page - 1) * pagesize)
                        .Take(pagesize)
                        .ToList(),
                    PageInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = pagesize,
                        TotalItems = query.Count()
                    }
                };

                return this.View("SearchResult", vmSearchResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public IActionResult ShowAllCategory(int page=1, int pagesige = PAGESIZE)
        {
            try
            {
                return this.View("AllCategory", this._repoCategory.GetAll().ToList());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
