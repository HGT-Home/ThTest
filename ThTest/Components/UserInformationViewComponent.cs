using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThTest.Models.ViewModels;

namespace ThTest.Components
{
    [ViewComponent(Name = "UserInformation")]
    public class UserInformationViewComponent: ViewComponent
    {
        public UserInformationViewComponent()
        {

        }

        public IViewComponentResult Invoke()
        {
            return this.View(new LoginViewModel());
        }
    }
}
