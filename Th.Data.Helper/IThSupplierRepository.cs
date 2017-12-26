using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Th.Models;

namespace Th.Data.Helper
{
    public interface IThSupplierRepository : IThRepository<Supplier>
    {
        Task<Supplier> GetById(string id);
    }
}
