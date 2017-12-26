using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThTest.Models.ViewModels
{
    public class CartListViewModel: ViewModelBase
    {
        public string ReturnUrl
        {
            get
            {
                return this.GetValue<string>();
            }

            set
            {
                this.SetValue(value);
            }
        }

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
