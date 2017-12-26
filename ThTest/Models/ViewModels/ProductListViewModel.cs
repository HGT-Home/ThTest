using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Th.Models;

namespace ThTest.Models.ViewModels
{
    public class ProductListViewModel: ViewModelBase
    {
        public IList<Product> Products
        {
            get => this.GetValue<IList<Product>>();

            set => this.SetValue(value);
        }

        public PagingInfo PagingInfo
        {
            get => this.GetValue<PagingInfo>();

            set => this.SetValue(value);
        }

        public int CurrentCategory
        {
            get => this.GetValue<int>();

            set => this.SetValue(value);
        }

        public IList<Category> Categories
        {
            get => this.GetValue<IList<Category>>();

            set => this.SetValue(value);
        }

        public ProductListViewModel()
            : base()
        {

        }
    }
}
