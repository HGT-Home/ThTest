﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ThTest.Resources;

namespace ThTest.Models.ViewModels
{
    public class ProfileViewModel: ViewModelBase
    {
        [Display(Name = "Username")]
        [Required(ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "RequiredUsername")]
        [RegularExpression(@"^[a-zA-Z0-9]+", ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "UserInvalid")]
        [MaxLength(30, ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "MaxLengthUsername")]
        public string Username
        {
            get => this.GetValue<string>();

            set => this.SetValue(value);
        }

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
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "EmailInvalid")]
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
        public DateTime DateOfBirth
        {
            get => this.GetValue<DateTime>();

            set => this.SetValue(value);
        }

        public ProfileViewModel()
            : base()
        {

        }
    }
}
