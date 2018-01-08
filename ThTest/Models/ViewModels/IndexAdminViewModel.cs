using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Th.Models;

namespace ThTest.Models.ViewModels
{
    public class IndexAdminViewModel: ViewModelBase
    {
        public IList<Category> NewCategories
        {
            get => this.GetValue<IList<Category>>();

            set => this.SetValue(value);
        }

        public IList<Product> NewProducts
        {
            get => this.GetValue<IList<Product>>();

            set => this.SetValue(value);
        }

        public IList<Order> OrderNotShipped
        {
            get => this.GetValue<IList<Order>>();

            set => this.SetValue(value);
        }

        public IList<Supplier> Suppliers
        {
            get => this.GetValue<IList<Supplier>>();

            set => this.SetValue(value);
        }

        public IndexAdminViewModel()
            : base()
        {
            this.NewCategories = new List<Category>();
            this.NewProducts = new List<Product>();
            this.OrderNotShipped = new List<Order>();
        }
    }
}
