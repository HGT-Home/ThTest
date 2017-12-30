using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Th.Models;

namespace ThTest.Models.ViewModels
{
    public class ProductDetailsViewModel: ViewModelBase
    {
        public Product Product
        {
            get => this.GetValue<Product>();

            set => this.SetValue(value);
        }

        public int Quantiy
        {
            get => this.GetValue<int>();

            set => this.SetValue(value);
        }

        public ProductDetailsViewModel()
            : base()
        {
            this.Quantiy = 0;
        }
    }
}
