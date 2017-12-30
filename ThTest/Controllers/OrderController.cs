using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThTest.Models.ViewModels;
using Th.Data.Helper;
using Th.Models;
using ThTest.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThTest.Controllers
{
    public class OrderController : ThBaseController
    {
        private IThCountryRepository _repoCountry;
        private IThCityRepository _repoCity;
        private IThOrderRepository _repoOrder;
        private Cart _cart;

        public OrderController(LoginSessionInfo loginSessionInfo, IUnitOfWork unitOfWork, Cart cart)
            : base(loginSessionInfo, unitOfWork)
        {
            this._repoOrder = this.UnitOfWork.OrderRepo;
            this._repoCountry = this.UnitOfWork.CountryRepo;
            this._repoCity = this.UnitOfWork.CityRepo;
            this._cart = cart;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CheckOut() => this.View(new OrderViewModel
        {
            Countries = this._repoCountry.GetAll(),
            Cities = this._repoCity.GetAll()
        });

        [HttpPost]
        public async Task<IActionResult> CheckOut(OrderViewModel vmOrder)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    Order mdOrder = new Order
                    {
                        ShipAddress = vmOrder.ShipAddress,
                        OrderDate = DateTime.Now,
                        IsShipped = false,
                        CityId = vmOrder.CityId,
                        UserId = this.LoginSession.UserId,
                    };

                    mdOrder.OrderDetails = (from c in this._cart.Lines
                                            select new OrderDetail
                                            {
                                                OrderId = mdOrder.OrderId,
                                                ProductId = c.Product.Id,
                                                Quantity = c.Quantity,
                                                Price = c.Product.UnitPrice,
                                                SubTotal = c.Quantity * c.Product.UnitPrice,
                                            }).ToList();

                    this._repoOrder.Insert(mdOrder);
                    await this.UnitOfWork.SaveAsync();

                    this._cart.Clear(); // Clear all item(s) in cart.

                    return this.RedirectToAction(nameof(ProductController.GetProductByCategoryId), "Product", new { categoryId = 1, page = 1 });
                }

                return this.View(vmOrder);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public IActionResult List(int page) => this.View(this._repoOrder.GetOrderNotShip(page));

        [HttpPost]
        public async Task<IActionResult> MarkShipped(int orderId)
        {
            try
            {
                this._repoOrder.MarkShippedOrder(orderId);
                await this.UnitOfWork.SaveAsync();

                return this.RedirectToAction(nameof(GetOrderNotShip));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public IActionResult GetOrderNotShip(int page)
        {
            try
            {
                return this.View("OrderNotShip", new OrderNotShippedViewModel
                {
                    Orders = this._repoOrder.GetOrderNotShip(page),
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Order mdOrder = this._repoOrder.GetById(id);
                this._repoOrder.Delete(mdOrder);
                await this.UnitOfWork.SaveAsync();

                return this.RedirectToAction(nameof(GetOrderNotShip));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
