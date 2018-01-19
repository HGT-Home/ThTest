using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThTest.Models.ViewModels
{
    public class CartListViewModel: ViewModelBase
    {
        public Cart Cart
        {
            get
            {
                return this.GetValue<Cart>();
            }

            set
            {
                this.SetValue(value);
            }
        }
    }
}
