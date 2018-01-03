using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Th.Data.Helper
{
    public class UnitOfWork: IUnitOfWork
    {
        private bool disposed = false;

        private Dictionary<Type, object> _dicRepositories = new Dictionary<Type, object>();

        protected ThDbContext DbContext { get; }

        public IThCityRepository CityRepo
        {
            get
            {
                return this.GetRepository<ThCityRepository>();
            }
        }

        public IThCategoryRepository CategoryRepo
        {
            get
            {
                return this.GetRepository<ThCategoryRepository>();
            }
        }

        public IThCountryRepository CountryRepo
        {
            get
            {
                return this.GetRepository<ThCountryRepository>();
            }
        }

        public IThCustomerRepository CustomerRepo
        {
            get
            {
                return this.GetRepository<ThCustomerRepository>();
            }
        }

        public IThOrderRepository OrderRepo
        {
            get
            {
                return this.GetRepository<ThOrderRepository>();
            }
        }

        public IThProductRepository ProductRepo
        {
            get
            {
                return this.GetRepository<ThProductRepository>();
            }
        }

        public IThSupplierRepository SupplierRepo
        {
            get
            {
                return this.GetRepository<ThSupplierRepository>();
            }
        }

        public IThLanguageRepository LanguageRepo
        {
            get
            {
                return this.GetRepository<ThLanguageRepository>();
            }
        }

        public IThProductStatusRepository ProductStatusRepo
        {
            get
            {
                return this.GetRepository<ThProductStatusReposirtory>();
            }
        }

        public IThCompanyRepository CompanyRepo
        {
            get
            {
                return this.GetRepository<ThCompanyRepository>();
            }
        }

        public UnitOfWork(ThDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public T GetRepository<T>() where T : class
        {
            try
            {
                Type tRepo = typeof(T);

                if (this._dicRepositories.ContainsKey(tRepo))
                {
                    return (T)this._dicRepositories[tRepo];
                }
                else
                {
                    T repo = (T)Activator.CreateInstance(tRepo, this.DbContext);
                    this._dicRepositories[tRepo] = repo;

                    return repo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public virtual int Save()
        {
            try
            {
                return this.DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public virtual Task<int> SaveAsync()
        {
            try
            {
                return this.DbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Rollback()
        {
            try
            {
                this.DbContext
                .ChangeTracker
                .Entries()
                .ToList()
                .ForEach(e => e.Reload());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                if (this.DbContext != null)
                {
                    this.DbContext.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
