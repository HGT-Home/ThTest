using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Th.Data.Helper;
using ThTest.Models;

namespace ThTest.Controllers
{
    public class CityController: ThBaseController
    {

        public CityController(LoginSessionInfo loginSessionInfo, IUnitOfWork unitOfWork)
            : base(loginSessionInfo, unitOfWork)
        {
        }

        public IActionResult GetCityByCountryId(int countryId)
        {
            return new JsonResult(this.UnitOfWork.CityRepo.GetCityByCountryId(countryId));
        }
    }
}
