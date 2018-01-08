using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Th.Models;

namespace Th.Data.Helper
{
    public interface IThSupplierRepository : IThRepository<Supplier>
    {
        Supplier GetById(string id);

        Task<Supplier> GetByIdAsync(string id);
    }
}
