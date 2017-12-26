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
        private IUnitOfWork _unitOfWork;

        public CityController(LoginSessionInfo loginSessionInfo, IUnitOfWork unitOfWork)
            : base(loginSessionInfo)
        {
            this._unitOfWork = unitOfWork;
        }

        public IActionResult GetCityByCountryId(int countryId)
        {
            return new JsonResult(this._unitOfWork.CityRepo.GetCityByCountryId(countryId));
        }
    }
}
