using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Th.Models;
using ThTest.Resources;

namespace ThTest.Models.ViewModels
{
    public class OrderViewModel: ViewModelBase
    {
        [BindNever]
        public int OrderId
        {
            get => this.GetValue<int>();

            set => this.SetValue(value);
        }

        [BindNever]
        public ICollection<CartLine> Lines
        {
            get => this.GetValue<ICollection<CartLine>>();

            set => this.SetValue(value);
        }

        [Required(ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "OrderViewModelRequiredName")]
        public string Name
        {
            get => this.GetValue<string>();

            set => this.SetValue(value);
        }

        public string ShipAddress
        {
            get => this.GetValue<string>();

            set => this.SetValue(value);
        }

        [Required(ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "OrderViewModelRequiredCity")]
        public int CityId
        {
            get => this.GetValue<int>();

            set => this.SetValue(value);
        }

        public string State
        {
            get => this.GetValue<string>();

            set => this.SetValue(value);
        }

        public string Zip
        {
            get => this.GetValue<string>();

            set => this.SetValue(value);
        }

        public int CountryId
        {
            get => this.GetValue<int>();

            set => this.SetValue(value);
        }

        public bool GiftWrap
        {
            get => this.GetValue<bool>();

            set => this.SetValue(value);
        }

        public IList<City> Cities
        {
            get => this.GetValue<IList<City>>();

            set => this.SetValue(value);
        }

        public IList<Country> Countries
        {
            get => this.GetValue<IList<Country>>();

            set => this.SetValue(value);
        }

        public OrderViewModel()
            : base()
        {

        }
    }
}
