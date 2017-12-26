using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThTest.Models.ViewModels
{
    public class PagingInfo : ViewModelBase
    {
        public int TotalItems
        {
            get => this.GetValue<int>();

            set => this.SetValue(value);
        }

        public int ItemsPerPage
        {
            get => this.GetValue<int>();

            set => this.SetValue(value);
        }

        public int CurrentPage
        {
            get => this.GetValue<int>();

            set => this.SetValue(value);
        }

        public int TotalPages => (int)Math.Ceiling((decimal)this.TotalItems / this.ItemsPerPage);

        public PagingInfo()
            : base()
        {

        }
    }
}
