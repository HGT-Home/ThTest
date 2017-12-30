using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThTest.Models;
using Th.Data.Helper;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThTest.Controllers
{
    public class CustomerController : ThBaseController
    {
        private IThCustomerRepository _repoCustomer;

        public CustomerController(LoginSessionInfo loginSessionInfo, IUnitOfWork unitOfWork)
            : base(loginSessionInfo, unitOfWork)
        {
            // Initialize Repository.
            this._repoCustomer = this.UnitOfWork.CustomerRepo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
