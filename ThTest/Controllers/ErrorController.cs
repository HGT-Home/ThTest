using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ThTest.Models;
using Th.Data.Helper;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThTest.Controllers
{
    public class ErrorController : ThBaseController
    {
        public ErrorController(LoginSessionInfo loginSessionInfo, IUnitOfWork unitOfWork) 
            : base(loginSessionInfo, unitOfWork)
        {
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Error()
        {
            return this.View();
        }
    }
}
