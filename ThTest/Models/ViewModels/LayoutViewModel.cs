using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThTest.Models.ViewModels
{
    public class LayoutViewModel: ViewModelBase
    {
        public string CurrentLanguage
        {
            get => this.GetValue<string>();

            set => this.SetValue(value);
        }
    }
}
