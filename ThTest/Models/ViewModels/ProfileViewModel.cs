using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Th.Models;
using ThTest.Resources;

namespace ThTest.Models.ViewModels
{
    public class ProfileViewModel: ViewModelBase
    {
        public ProfileUserInformationViewModel UserInformation
        {
            get => this.GetValue<ProfileUserInformationViewModel>();
            set => this.SetValue(value);
        }

        public ProfilePasswordInformation PasswordInformation
        {
            get => this.GetValue<ProfilePasswordInformation>();
            set => this.SetValue(value);
        }

        public ProfileViewModel()
            : base()
        {
            this.UserInformation = new ProfileUserInformationViewModel();
            this.PasswordInformation = new ProfilePasswordInformation();
        }
    }
}
