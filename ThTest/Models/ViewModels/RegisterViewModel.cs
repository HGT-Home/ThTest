using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Th.Models;
using ThTest.Resources;

namespace ThTest.Models.ViewModels
{
    public class RegisterViewModel: ViewModelBase
    {
        //[Display(Name = "Username")]
        //[Required(ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "RequiredUsername")]
        //[RegularExpression(@"^[a-zA-Z0-9]+", ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "UserInvalid")]
        //[MaxLength(50, ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "MaxLengthUsername")]
        //public string Username
        //{
        //    get => this.GetValue<string>();

        //    set => this.SetValue(value);
        //}

        [DataType(DataType.Password)]
        [Required(ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "RequiredPassword")]
        [RegularExpression(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).*$", ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "PasswordInvalid")]
        public string Password
        {
            get => this.GetValue<string>();

            set => this.SetValue(value);
        }

        [DataType(DataType.Password)]
        [Required(ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "RequiredConfirmPassword")]
        [Compare("Password", ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "ConfirmPasswordNotMatch")]
        public string ConfirmPassword
        {
            get => this.GetValue<string>();

            set => this.SetValue(value);
        }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "RequiredEmail")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$|^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}", ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "EmailInvalid")]
        public string Email
        {
            get => this.GetValue<string>();

            set => this.SetValue(value);
        }

        [Required(ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "RequiredFullname")]
        public string Fullname
        {
            get => this.GetValue<string>();

            set => this.SetValue(value);
        }

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth
        {
            get => this.GetValue<DateTime>();

            set => this.SetValue(value);
        }

        [MaxLength(1024, ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "MaxLengthAddress")]
        public string Address
        {
            get => this.GetValue<string>();
            set => this.SetValue(value);
        }

        public int CountryId
        {
            get => this.GetValue<int>();
            set => this.SetValue(value);
        }

        public IList<Country> Countries
        {
            get => this.GetValue<IList<Country>>();
            set => this.SetValue(value);
        }

        public int CityId
        {
            get => this.GetValue<int>();
            set => this.SetValue(value);
        }

        public IList<City> Cities
        {
            get => this.GetValue<IList<City>>();
            set => this.SetValue(value);
        }
    }
}
