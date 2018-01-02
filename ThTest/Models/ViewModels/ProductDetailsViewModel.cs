using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Th.Models;
using ThTest.Resources;

namespace ThTest.Models.ViewModels
{
    public class ProductDetailsViewModel: ViewModelBase
    {
        public Product Product
        {
            get => this.GetValue<Product>();

            set => this.SetValue(value);
        }
        
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "RangeQuantity")]
        public int Quantiy
        {
            get => this.GetValue<int>();

            set => this.SetValue(value);
        }

        public ProductDetailsViewModel()
            : base()
        {
            this.Quantiy = 1;
        }
    }
}
