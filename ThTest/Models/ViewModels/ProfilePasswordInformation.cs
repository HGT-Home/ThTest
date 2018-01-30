using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ThTest.Resources;

namespace ThTest.Models.ViewModels
{
    public class ProfilePasswordInformation: ViewModelBase
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = nameof(ShareResource.RequiredPassword))]
        [RegularExpression(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).*$", ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = nameof(ShareResource.PasswordInvalid))]
        public string Password
        {
            get => this.GetValue<string>();
            set => this.SetValue(value);
        }

        [DataType(DataType.Password)]
        [Required(ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = nameof(ShareResource.RequiredPassword))]
        [RegularExpression(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).*$", ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = nameof(ShareResource.PasswordInvalid))]
        public string NewPassword
        {
            get => this.GetValue<string>();
            set => this.SetValue(value);
        }

        [DataType(DataType.Password)]
        [Required(ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = nameof(ShareResource.RequiredConfirmPassword))]
        [Compare(nameof(NewPassword), ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = nameof(ShareResource.ConfirmPasswordNotMatch))]
        public string ConfirmPassword
        {
            get => this.GetValue<string>();
            set => this.SetValue(value);
        }

        [DataType(DataType.Password)]
        [Required(ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = nameof(ShareResource.RequiredPassword))]
        [RegularExpression(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).*$", ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = nameof(ShareResource.PasswordInvalid))]
        public string CurrentPassword
        {
            get => this.GetValue<string>();
            set => this.SetValue(value);
        }
    }
}
