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
using System.Threading;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThTest.Controllers
{
    public class ProductController : ThBaseController
    {
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
            : base(loginSessionInfo, unitOfWork)
        {
            this._pvdPath = pvdPath;

            // Repositories.
            this._repoProduct = this.UnitOfWork.ProductRepo;
            this._repoSupplier = this.UnitOfWork.SupplierRepo;
            this._repoCategory = this.UnitOfWork.CategoryRepo;
            
            // Localization.
            this._localizer = localizer;
        }

        // GET: /<controller>/
        public IActionResult Index(int page = 1)
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
                Categories = lstCategory,
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
                    TotalItems = this._repoProduct.CountProductByCategoryId(categoryId),
                },
                Products = lstProductList,
                Categories = lstCategory,
                SupportLanguages = this.UnitOfWork.LanguageRepo.GetAll()
            };

            return this.View("ProductList", vmProductList);
        }

        [HttpGet]
        [Authorize(Roles = "Administrators")]
        public IActionResult Add()
        {
            EditProductViewModel vmEditProduct = new EditProductViewModel
            {
                Categories = this._repoCategory.GetAll(),
                Suppliers = this._repoSupplier.GetAll(),
                ImagePath = "imgs/no-image.png",
                Mode = ThAction.Add,
                SupportLanguages = this.UnitOfWork.LanguageRepo.GetAll(),
                ProductStatuses = this.UnitOfWork.ProductStatusRepo.GetAll(),
            };

            vmEditProduct.Translations = (from l in vmEditProduct.SupportLanguages
                                          select new ProductTranslationViewModel
                                          {
                                              LanguageId = l.LanguageId,
                                              LanguageName = l.Name,
                                              Description = string.Empty,
                                              Name = string.Empty,
                                          }).ToList();

            return this.View("EditProduct", vmEditProduct);
        }

        [HttpGet]
        [Authorize(Roles = "Administrators")]
        public IActionResult Edit(int id)
        {
            Product mdProduct = this._repoProduct.GetById(id);
            EditProductViewModel vmEditProduct = mdProduct.Map<EditProductViewModel>();
            vmEditProduct.Categories = this._repoCategory.GetAll();
            vmEditProduct.Suppliers = this._repoSupplier.GetAll();
            vmEditProduct.SupportLanguages = this.UnitOfWork.LanguageRepo.GetAll();
            vmEditProduct.ProductStatuses = this.UnitOfWork.ProductStatusRepo.GetAll();
            vmEditProduct.Mode = ThAction.Edit;
            vmEditProduct.Translations = (from l in vmEditProduct.SupportLanguages
                                          select new ProductTranslationViewModel
                                          {
                                              LanguageId = l.LanguageId,
                                              LanguageName = l.Name,
                                              Description = mdProduct.GetLanguageText(l.LanguageId, nameof(Product.Description)),
                                              Name = mdProduct.GetLanguageText(l.LanguageId, nameof(Product.Name)),
                                          }).ToList();

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
                    p.ImagePath = file.SaveImageFile(ImageFolder.Product, this._pvdPath);
                    p.ImageBinary = file.GetBytes();
                }

                // Create translation for product name and description.
                if (editProductViewModel.Translations != null && editProductViewModel.Translations.Count > 0)
                {
                    p.Translations = new List<ProductTranslation>();
                    foreach(ProductTranslationViewModel vmPt in editProductViewModel.Translations)
                    {
                        ProductTranslation ptName = new ProductTranslation
                        {
                            ColumnName = nameof(Product.Name),
                            LanguageId = vmPt.LanguageId,
                            Value = vmPt.Name,
                            ProductId = p.Id
                        };

                        ProductTranslation ptDescription = new ProductTranslation
                        {
                            ColumnName = nameof(Product.Description),
                            LanguageId = vmPt.LanguageId,
                            Value = vmPt.Description,
                            ProductId = p.Id,
                        };

                        p.Translations.Add(ptName);
                        p.Translations.Add(ptDescription);
                    }
                }

                if (editProductViewModel.Mode == ThAction.Edit)
                {
                    p.UpdatedBy = this.User.Identity.Name;
                    p.UpdatedDate = DateTime.Now;
                    this._repoProduct.Update(p);
                }
                else
                {
                    p.CreatedBy = p.UpdatedBy = this.User.Identity.Name;
                    p.CreatedDate = p.UpdatedDate = DateTime.Now;
                    this._repoProduct.Insert(p);
                }

                await this.UnitOfWork.SaveAsync();
                this.TempData["Message"] = string.Format(this._localizer["Product {0} has been saved."], p.Name);

                return this.RedirectToAction("IndexAdmin", "Home");
            }

            editProductViewModel.SupportLanguages = this.UnitOfWork.LanguageRepo.GetAll();

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
                await this.UnitOfWork.SaveAsync();

                this.TempData["Message"] = string.Format(this._localizer["Product {0} has been deleted."], mdProduct.Name);
                return this.RedirectToAction("Index", "Home");
            }

            return this.NotFound();
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            EditCategoryViewModel vmEditCategory = new EditCategoryViewModel
            {
                Mode = ThAction.Edit,
                SupportLanguages = this.UnitOfWork.LanguageRepo.GetAll(),
                CurrentLanguage = Thread.CurrentThread.CurrentCulture.Name,
            };

            vmEditCategory.Translations = (from l
                                           in vmEditCategory.SupportLanguages
                                           select new CategoryTranslationViewModel
                                           {
                                               LanguageId = l.LanguageId,
                                               LanguageName = l.Name,
                                               Name = string.Empty,
                                               Description = string.Empty,
                                           }).ToList();

            return this.View("EditCategory", new EditCategoryViewModel() { Mode = ThAction.Add });
        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            Category mdCategory = this._repoCategory.GetById(id);
            if (mdCategory != null)
            {
                EditCategoryViewModel vmCategory = mdCategory.Map<EditCategoryViewModel>();
                vmCategory.Mode = ThAction.Edit;
                vmCategory.CurrentLanguage = Thread.CurrentThread.CurrentCulture.Name;
                vmCategory.SupportLanguages = this.UnitOfWork.LanguageRepo.GetAll();

                vmCategory.Translations = (from l
                                           in vmCategory.SupportLanguages
                                           select new CategoryTranslationViewModel
                                           {
                                               LanguageId = l.LanguageId,
                                               LanguageName = l.Name,
                                               Name = mdCategory.GetLanguageText(l.LanguageId, nameof(Category.Name)),
                                               Description = mdCategory.GetLanguageText(l.LanguageId, nameof(Category.Description)),
                                           }).ToList();

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
                    this.UnitOfWork.Save();
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

                    if (vmEditCategory.Translations != null  && vmEditCategory.Translations.Count > 0)
                    {
                        c.Translations = new List<CategoryTranslation>();

                        foreach (CategoryTranslationViewModel vmCt in vmEditCategory.Translations)
                        {
                            CategoryTranslation ctName = new CategoryTranslation
                            {
                                ColumnName = nameof(Category.Name),
                                LanguageId = vmCt.LanguageId,
                                CategoryId = c.Id,
                                Value = vmCt.Name,
                            };

                            CategoryTranslation ctDescription = new CategoryTranslation
                            {
                                ColumnName = nameof(Category.Description),
                                LanguageId = vmCt.LanguageId,
                                CategoryId = c.Id,
                                Value = vmCt.Description,
                            };

                            c.Translations.Add(ctName);
                            c.Translations.Add(ctDescription);
                        }
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

                    await this.UnitOfWork.SaveAsync();

                    this.TempData["Message"] = string.Format(this._localizer["Category {0} has been saved."], c.Name);

                    return this.RedirectToAction(nameof(HomeController.IndexAdmin), "Home");
                }

                vmEditCategory.SupportLanguages = this.UnitOfWork.LanguageRepo.GetAll();

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
                // Tăng giá trị xem sản phẩm.
                Product p = this._repoProduct.GetById(productId);

                if (p != null)
                {
                    p.ViewCount++;
                    
                    this._repoProduct.Update(p);
                    this.UnitOfWork.Save();

                    ProductDetailsViewModel vmP = new ProductDetailsViewModel
                    {
                        Product = p
                    };

                    vmP.Product.Category = this._repoCategory.GetById(p.CategoryId);
                    return this.View("ProductDetails", vmP);
                }

                return this.NotFound();
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

                (IList<Product> products, int totalItem) = this.UnitOfWork.ProductRepo.Search(keyword, null, 1);

                SearchResultViewModel vmSearchResult = new SearchResultViewModel
                {
                    Keyword = keyword,
                    Products = products,
                    PageInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = pagesize,
                        TotalItems = totalItem
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
