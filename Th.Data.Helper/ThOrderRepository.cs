using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Th.Models;

namespace Th.Data.Helper
{
    public class ThOrderRepository: ThRepository<Order>, IThOrderRepository, IDisposable
    {
        public ThOrderRepository(ThDbContext dbContext)
            : base(dbContext)
        {

        }

        public IList<Order> GetOrderNotShip(int page)
        {
            try
            {
                return this._dbContext.Orders
                    .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                    .ThenInclude(p => p.Translations)
                    .Include(o => o.User)
                    .ThenInclude(u => u.Customer)
                    .Where(o => o.IsShipped == false)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void MarkShippedOrder(int orderId)
        {
            try
            {
                Order mdOrder = this._dbContext.Orders
                    .FirstOrDefault(o => o.OrderId == orderId);

                if (mdOrder != null)
                {
                    mdOrder.IsShipped = true;
                    this._dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Order GetById(int id)
        {
            try
            {
                return this.Entities.SingleOrDefault(o => o.OrderId == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override int Count()
        {
            return this.Entities.Count();
        }

        public override void Delete(Order mdDelete)
        {
            try
            {
                if(this._dbContext.Entry(mdDelete).State == EntityState.Detached)
                {
                    this._dbContext.Attach(mdDelete);
                    this._dbContext.Orders.Remove(mdDelete);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Insert(Order mdInsert)
        {
            try
            {
                this._dbContext.Orders.Add(mdInsert);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Update(Order mdUpdate)
        {
            try
            {
                if (mdUpdate != null)
                {
                    this._dbContext.Attach(mdUpdate);
                    this._dbContext.Entry(mdUpdate).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<Order> GetTodayOrder()
        {
            try
            {
                return this.Entities
                    .Where(o => o.OrderDate.Date == DateTime.UtcNow.Date)
                    .Take(4)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Dispose()
        {
            if (this._dbContext != null)
            {
                this._dbContext.Dispose();
            }
        }
    }
}
