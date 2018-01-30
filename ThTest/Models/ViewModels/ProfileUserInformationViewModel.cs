using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Th.Models;
using ThTest.Resources;

namespace ThTest.Models.ViewModels
{
    public class ProfileUserInformationViewModel: ViewModelBase
    {
        [MaxLength(256, ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = nameof(ShareResource.MaxLengthFullname))]
        [Required(ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = nameof(ShareResource.RequiredFullname))]
        public string Fullname
        {
            get => this.GetValue<string>();
            set => this.SetValue(value);
        }

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth
        {
            get => this.GetValue<DateTime?>();
            set => this.SetValue(value);
        }

        public string Address
        {
            get => this.GetValue<string>();
            set => this.SetValue(value);
        }

        [MaxLength(256, ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = nameof(ShareResource.MaxLengthLastName))]
        public string LastName
        {
            get => this.GetValue<string>();
            set => this.SetValue(value);
        }

        [MaxLength(256, ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = nameof(ShareResource.MaxLengthFirstName))]
        public string FirstName
        {
            get => this.GetValue<string>();
            set => this.SetValue(value);
        }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = nameof(ShareResource.RequiredEmail))]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$|^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}", ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "EmailInvalid")]
        public string Email
        {
            get => this.GetValue<string>();
            set => this.SetValue(value);
        }

        public int CountryId
        {
            get => this.GetValue<int>();
            set => this.SetValue(value);
        }

        public int CityId
        {
            get => this.GetValue<int>();
            set => this.SetValue(value);
        }

        public IList<Country> Countries
        {
            get => this.GetValue<IList<Country>>();
            set => this.SetValue(value);
        }

        public IList<City> Cities
        {
            get => this.GetValue<IList<City>>();
            set => this.SetValue(value);
        }

    }
}
