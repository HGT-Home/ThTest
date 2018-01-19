using Microsoft.AspNetCore.Authentication;
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
        //[Required(ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "RequiredUsername")]
        //[StringLength(50)]
        //[Display(Name = "Username")]
        //public string Username
        //{
        //    get => this.GetValue<string>();
        //    set => this.SetValue(value);
        //}

        [Required(ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "RequiredEmail")]
        [StringLength(256, ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "MaxLengthEmail")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$|^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}", ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "EmailInvalid")]
        public string Email
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

        public string FacebookAppId
        {
            get => this.GetValue<string>();
            set => this.SetValue(value);
        }

        public string FacebookAppSecret
        {
            get => this.GetValue<string>();
            set => this.SetValue(value);
        }

        public string FullName
        {
            get => this.GetValue<string>();
            set => this.SetValue(value);
        }

        public IList<AuthenticationScheme> LoginProviders
        {
            get => this.GetValue<IList<AuthenticationScheme>>();
            set => this.SetValue(value);
        }

        public LoginViewModel()
            : base()
        {
            this.ReturnUrl = "/";
        }
    }
}
