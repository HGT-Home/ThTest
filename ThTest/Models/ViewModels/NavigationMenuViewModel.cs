using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Th.Models;

namespace ThTest.Models.ViewModels
{
    public class NavigationMenuViewModel: ViewModelBase
    {
        public int CurrentCategoryId
        {
            get => this.GetValue<int>();

            set => this.SetValue(value);
        }

        public IList<Category> Categories
        {
            get => this.GetValue<IList<Category>>();

            set => this.SetValue(value);
        }

        public NavigationMenuViewModel()
            : base()
        {
        }
    }
}
