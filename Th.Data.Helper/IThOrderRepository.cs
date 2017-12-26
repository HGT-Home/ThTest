using System;
using System.Collections.Generic;
using System.Text;
using Th.Models;

namespace Th.Data.Helper
{
    public interface IThOrderRepository: IThRepository<Order>
    {
        IList<Order> GetOrderNotShip(int page);

        void MarkShippedOrder(int orderId);

        IList<Order> GetTodayOrder();

        Order GetById(int id);
    }
}
