using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThTest.Models.ViewModels
{
    public class ProductSearchViewModel: ViewModelBase
    {
        public string SearchText
        {
            get => this.GetValue<string>();

            set => this.SetValue(value);
        }

        public string Category
        {
            get => this.GetValue<string>();

            set => this.SetValue(value);
        }

        public ProductSearchViewModel()
            : base()
        {

        }
    }
}
