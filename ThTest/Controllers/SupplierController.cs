﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThTest.Models.ViewModels;
using Th.Models;
using Th.Data.Helper;
using Microsoft.Extensions.Localization;
using ThTest.Models;
using Microsoft.AspNetCore.Authorization;
using ThTest.Infrastructures;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThTest.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class SupplierController : ThBaseController
    {
        private IThSupplierRepository _repoSupplier;
        private readonly IStringLocalizer<SupplierController> _localizer;

        public SupplierController(LoginSessionInfo loginSessionInfo, IUnitOfWork unitOfWork, IStringLocalizer<SupplierController> localizer)
            : base(loginSessionInfo, unitOfWork)
        {
            this._repoSupplier = this.UnitOfWork.SupplierRepo;
            this._localizer = localizer;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Add()
        {
            return View("EditSupplier", new EditSupplierViewModel { Mode = ThAction.Add });
        }


        [HttpGet]
        public IActionResult Edit(string id)
        {
            this.TempData[nameof(Supplier.Id)] = id;

            Supplier mdSupplier = this.UnitOfWork.SupplierRepo.GetById(id);

            if (mdSupplier != null)
            {
                EditSupplierViewModel vmEditSupplier = mdSupplier.Map<EditSupplierViewModel>();
                vmEditSupplier.Mode = ThAction.Edit;

                this.View("EditSupplier", vmEditSupplier);
            }

            return this.NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Save(EditSupplierViewModel vmSupplier, string returnUrl)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    Supplier mdSupplier = new Supplier
                    {
                        Name = vmSupplier.Name,
                        Email = vmSupplier.Email,
                        Phone = vmSupplier.Phone,
                        Logo = string.Empty,
                    };

                    switch (vmSupplier.Mode)
                    {
                        case ThAction.Add:

                            // Create new id.
                            mdSupplier.Id = Guid.NewGuid().ToString();

                            // Add new supplier to database.
                            this._repoSupplier.Insert(mdSupplier);
                            break;
                        case ThAction.Edit:
                            if (this.TempData[nameof(Supplier.Id)] != null)
                            {
                                mdSupplier.Id = TempData[nameof(Supplier.Id)].ToString();
                            }

                            // Update data to database.
                            this._repoSupplier.Update(mdSupplier);
                            break;
                    }

                    await this.UnitOfWork.SaveAsync();

                    // Display successfull message.
                    this.TempData["Message"] = string.Format(this._localizer["Supplier {0} has been save."], vmSupplier.Name);

                    // Redirecto home.
                    return this.RedirectToAction(nameof(HomeController.IndexAdmin), "Home");
                }

                // If has an error, return to the EditSupplier view.
                return this.View("EditSupplier", vmSupplier);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            try
            {
                Supplier mdSupplier = this.UnitOfWork.SupplierRepo.GetById(id);
                if (mdSupplier != null)
                {
                    this.UnitOfWork.SupplierRepo.Delete(mdSupplier);

                    return this.LocalRedirect("/Home/IndexAdmin");
                }

                return this.NotFound();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<IActionResult> ShowSupplierDetails(string supplierId)
        {
            try
            {
                Supplier mdSupplier = await this.UnitOfWork.SupplierRepo.GetByIdAsync(supplierId);
                if (mdSupplier != null)
                {
                    return this.View("SupplierDetails", mdSupplier);
                }

                return this.NotFound();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public IActionResult ShowAllSupplier()
        {
            try
            {
                IList<Supplier> lstSupplier = this.UnitOfWork.SupplierRepo.GetAll();

                return this.View("AllSupplier", lstSupplier);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
