using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Th.Models;

namespace ThTest.Models.ViewModels
{
    public class SearchResultViewModel: ViewModelBase
    {
        public string Keyword
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

        public IList<Product> Products
        {
            get
            {
                return this.GetValue<IList<Product>>();
            }
            set
            {
                this.SetValue(value);
            }
        }

        public PagingInfo PageInfo
        {
            get
            {
                return this.GetValue<PagingInfo>();
            }

            set
            {
                this.SetValue(value);
            }
        } 

        public SearchResultViewModel()
            : base()
        {
            
        }
    }
}
