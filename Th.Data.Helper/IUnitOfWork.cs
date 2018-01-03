using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Th.Data.Helper
{
    public interface IUnitOfWork: IDisposable
    {
        IThCityRepository CityRepo { get; }

        IThCategoryRepository CategoryRepo { get; }

        IThCountryRepository CountryRepo { get; }

        IThCustomerRepository CustomerRepo { get; }

        IThOrderRepository OrderRepo { get; }

        IThProductRepository ProductRepo { get; }

        IThSupplierRepository SupplierRepo { get; }

        IThLanguageRepository LanguageRepo { get; }

        IThProductStatusRepository ProductStatusRepo { get; }

        IThCompanyRepository CompanyRepo { get; }

        T GetRepository<T>() where T : class;

        int Save();

        Task<int> SaveAsync();

        void Rollback();
    }
}
