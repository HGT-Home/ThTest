using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Th.Models;

namespace Th.Data.Helper
{
    public interface IThRepository<T> where T : ThBaseModel
    {
        IList<T> GetAll();

        void Insert(T mdInsert);

        void Update(T mdUpdate);

        void Delete(T mdDelete);

        IQueryable<T> Entities { get; }

        int Count();
    }
}
