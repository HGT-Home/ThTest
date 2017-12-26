using System;
using System.Collections.Generic;
using System.Text;
using Th.Models;

namespace Th.Data.Helper
{
    public interface IThCityRepository: IThRepository<City>
    {
        IList<City> GetCityByCountryId(int countryId);
    }
}
