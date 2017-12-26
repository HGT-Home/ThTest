using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Th.Models;

namespace ThTest.Models.ViewModels
{
    public class HomeIndexViewModel: ViewModelBase
    {
        public IList<Category> Categories
        {
            get => this.GetValue<IList<Category>>();

            set => this.SetValue(value);
        }

        public IList<Product> SlideProduct
        {
            get => this.GetValue<IList<Product>>();

            set => this.SetValue(value);
        }

        public HomeIndexViewModel()
            : base()
        {

        }
    }
}
