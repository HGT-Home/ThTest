using Microsoft.AspNetCore.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Th.Models;

namespace ThTest.Models.ViewModels
{
    public class MainNavigationViewModel: ViewModelBase
    {
        public IList<Category> Categories
        {
            get => this.GetValue<IList<Category>>();

            set => this.SetValue(value);
        }


        public string CurrentLanguage
        {
            get => this.GetValue<string>();

            set => this.SetValue(value);
        }

        public string TwoLetterCurrentLanguage
        {
            get => this.GetValue<string>();

            set => this.SetValue(value);
        }

        public IList<CultureInfo> SupportedCultures
        {
            get => this.GetValue<IList<CultureInfo>>();

            set => this.SetValue(value);
        }

        public string CurrentMenu
        {
            get => this.GetValue<string>();

            set => this.SetValue(value);
        }

        public MainNavigationViewModel()
            : base()
        {
        }
    }
}
