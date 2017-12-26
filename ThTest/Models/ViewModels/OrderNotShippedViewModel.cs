using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Th.Models;

namespace ThTest.Models.ViewModels
{
    public class OrderNotShippedViewModel: ViewModelBase
    {
        public IList<Order> Orders
        {
            get => this.GetValue<IList<Order>>();

            set => this.SetValue(value);
        }

        public OrderNotShippedViewModel()
            : base()
        {

        }
    }
}
