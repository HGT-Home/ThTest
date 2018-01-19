using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Th.Models;
using ThTest.Models.ViewModels;

namespace ThTest.Components
{
    [ViewComponent(Name = "UserInformation")]
    public class UserInformationViewComponent: ViewComponent
    {
        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;

        public UserInformationViewComponent(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            LoginViewModel vmLogin = new LoginViewModel();

            if (this._signInManager.IsSignedIn(this.UserClaimsPrincipal))
            {
                User user = await this._userManager.GetUserAsync(this.UserClaimsPrincipal);

                if (user != null)
                {
                    vmLogin.FullName = user.FullName;
                }
            }

            return this.View(vmLogin);
        }
    }
}
