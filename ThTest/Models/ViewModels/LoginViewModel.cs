using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ThTest.Resources;

namespace ThTest.Models.ViewModels
{
    public class LoginViewModel: ViewModelBase
    {
        [Required(ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "RequiredUsername")]
        [StringLength(50)]
        [Display(Name = "Username")]
        public string Username
        {
            get => this.GetValue<string>();

            set => this.SetValue(value);
        }

        [Required(ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "RequiredPassword")]
        [StringLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [UIHint("password")]
        public string Password
        {
            get => this.GetValue<string>();

            set => this.SetValue(value);
        }

        public bool IsRememberMe
        {
            get => this.GetValue<bool>();

            set => this.SetValue(value);
        }

        public string ReturnUrl
        {
            get => this.GetValue<string>();

            set => this.SetValue(value);
        }

        public LoginViewModel()
            : base()
        {
            this.ReturnUrl = "/";
        }
    }
}
