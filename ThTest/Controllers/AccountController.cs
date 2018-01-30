using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThTest.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Th.Models;
using Microsoft.Extensions.Localization;
using System.Security.Claims;
using ThTest.Models;
using System.Text;
using Th.Data.Helper;
using Microsoft.AspNetCore.Authentication;
using ThTest.Infrastructures;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThTest.Controllers
{
    public class AccountController: ThBaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleMananger;
        private readonly IStringLocalizer _localizer;

        public AccountController(
            LoginSessionInfo loginSessionInfo, 
            IUnitOfWork unitOfWork,
            UserManager<User> userManager, 
            SignInManager<User> signInManager, 
            RoleManager<Role> roleManager, 
            IStringLocalizer<AccountController> localizer)
            : base(loginSessionInfo, unitOfWork)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleMananger = roleManager;
            this._localizer = localizer;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return this.View(new RegisterViewModel {
                Cities = this.UnitOfWork.CityRepo.GetAll(),
                Countries = this.UnitOfWork.CountryRepo.GetAll(),
                SupportLanguages = this.UnitOfWork.LanguageRepo.GetAll(),
            });
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel vmRegister)
        {
            // Create default user.
            if (!this._roleMananger.RoleExistsAsync("Administrators").Result)
            {
                Role roleAdmin = new Role
                {
                    Name = "Administrators",
                    Description = "Administrator group."
                };

                IdentityResult roleCreateResult = await this._roleMananger.CreateAsync(roleAdmin);

                if (roleCreateResult.Succeeded)
                {
                    User adminUser = new User
                    {
                        UserName = "admin@gmail.com",
                        Email = "admin@gmail.com",
                        FullName = "Administrator",
                        DateOfBirth = DateTime.Now,
                    };

                    IdentityResult userAdminResult = await this._userManager.CreateAsync(adminUser, "Maradona10");
                    if (userAdminResult.Succeeded)
                    {
                        await this._userManager.AddToRoleAsync(adminUser, "Administrators");
                    }
                }
            }

            // Create regitation user.
            if (this.ModelState.IsValid)
            {
                User user = await this._userManager.FindByEmailAsync(vmRegister.Email);

                if (user == null)
                {
                    user = new User
                    {
                        UserName = vmRegister.Email,
                        Email = vmRegister.Email,
                        FullName = vmRegister.Fullname,
                        DateOfBirth = vmRegister.DateOfBirth ?? default(DateTime),
                    };

                    IdentityResult userResult = await this._userManager.CreateAsync(user, vmRegister.Password);

                    if (userResult.Succeeded)
                    {
                        if (!this._roleMananger.RoleExistsAsync("Users").Result)
                        {
                            Role role = new Role
                            {
                                Name = "Users",
                                Description = "Normal user.",
                            };

                            IdentityResult roleResult = await this._roleMananger.CreateAsync(role);

                            if (!roleResult.Succeeded)
                            {
                                this.ModelState.AddModelError(string.Empty, this._localizer["Error while creating role."]);

                                return this.View(vmRegister);
                            }
                        }

                        await this._userManager.AddToRoleAsync(user, "Users");

                        return this.RedirectToAction(nameof(Login));
                    }
                }
                else
                {
                    this.ModelState.AddModelError(nameof(RegisterViewModel.Email), this._localizer["Email has been existed."]);
                }
            }

            vmRegister.Cities = this.UnitOfWork.CityRepo.GetAll();
            vmRegister.Countries = this.UnitOfWork.CountryRepo.GetAll();
            vmRegister.SupportLanguages = this.UnitOfWork.LanguageRepo.GetAll();

            return this.View(vmRegister);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl,
                FacebookAppId = "170222766920220",
                FacebookAppSecret = "dac137fc1003d0ec5d079c54b6b95de8",
                LoginProviders = (await this._signInManager.GetExternalAuthenticationSchemesAsync()).ToList(),
            });
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel vmLogin)
        {
            if (this.ModelState.IsValid)
            {
                User user = await this._userManager.FindByEmailAsync(vmLogin.Email);
                if (user != null)
                {
                    await this._signInManager.SignOutAsync();

                    var signInResult = await this._signInManager.PasswordSignInAsync(vmLogin.Email, vmLogin.Password, vmLogin.IsRememberMe, false);

                    if (signInResult.Succeeded)
                    {
                        // Set login session.
                        this.LoginSession.UserId = user.Id;
                        this.LoginSession.Username = user.UserName;
                        this.LoginSession.Email = user.Email;
                        this.LoginSession.LoginDate = DateTime.UtcNow;
                        this.LoginSession.CustomerId = user.CustomerId;
                        this.LoginSession.CustomerName = user.FullName;
                        this.LoginSession.RoleNames = await this._userManager.GetRolesAsync(user);
                        this.LoginSession.SaveSession();

                        if (user != null)
                        {
                            if (await this._userManager.IsInRoleAsync(user, "Administrators"))
                            {
                                return this.RedirectToAction("IndexAdmin", "Home");
                            }
                        }

                        return this.RedirectToLocal(vmLogin.ReturnUrl);
                    }
                }

                this.ModelState.AddModelError(nameof(LoginViewModel.Password), this._localizer["Email or password are invalid."]);
            }

            vmLogin.LoginProviders = this._signInManager
                .GetExternalAuthenticationSchemesAsync()
                .Result?
                .ToList();

            return this.View(vmLogin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await this._signInManager.SignOutAsync();

            return this.RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            string email = this.User.Identity.Name;
            User user = await this._userManager.FindByEmailAsync(email);
            if (user != null)
            {
                ProfileViewModel vmProfile = new ProfileViewModel
                {
                    UserInformation = user.Map<ProfileUserInformationViewModel>()
                };

                if (await this._userManager.IsInRoleAsync(user, "Users"))
                {
                    Customer customer = this.UnitOfWork.CustomerRepo.Get(c => c.Id == user.CustomerId.Value).SingleOrDefault();

                    if (customer != null)
                    {
                        vmProfile.UserInformation.Address = customer.Address;
                        vmProfile.UserInformation.CityId = customer.CityId;

                        vmProfile.UserInformation.CountryId = this.UnitOfWork.CountryRepo.Get(customer.CityId).Id;
                    }
                }
                else if(await this._userManager.IsInRoleAsync(user, "Administrators"))
                {

                }

                vmProfile.UserInformation.Countries = this.UnitOfWork.CountryRepo.GetAll();
                vmProfile.UserInformation.Cities = this.UnitOfWork.CityRepo.GetAll();

                return this.View(vmProfile);
            }

            return this.NotFound();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        // string provider, string returnUrl = null
        public IActionResult ExternalLogin(string provider = null, string returnUrl = null)
        {
            try
            {
                string redirectUrl = this.Url.Action(nameof(ExternalLoginCallback), "Account", new { returnUrl });
                AuthenticationProperties properties = this._signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

                return this.Challenge(properties, provider);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl, string remoteError = null)
        {
            try
            {
                if (remoteError != null)
                {
                    this.RedirectToAction(nameof(Login));
                }

                ExternalLoginInfo info = await this._signInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return this.RedirectToAction(nameof(Login));
                }

                var result = await this._signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
                if (result.Succeeded)
                {
                    return this.RedirectToLocal(returnUrl);
                }

                if (result.IsLockedOut)
                {
                    return this.RedirectToAction(nameof(Login));
                }

                LoginViewModel vmLogin = new LoginViewModel
                {
                    Email = info.Principal.FindFirstValue(ClaimTypes.Email),
                    Password = "random-password",
                    ReturnUrl = returnUrl,
                };

                return this.View("ExternalLogin", vmLogin);
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExternalLoginConfirmation(LoginViewModel vmLogin, string returnUrl = null)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    ExternalLoginInfo info = await this._signInManager.GetExternalLoginInfoAsync();
                    if(info == null)
                    {
                        throw new ApplicationException("Error while loading external login information");
                    }

                    User user = new User
                    {
                        UserName = vmLogin.Email,
                        Email = vmLogin.Email,
                        FullName = info.Principal.FindFirstValue(ClaimTypes.Name),
                    };

                    var result = await this._userManager.CreateAsync(user);
                    if (result.Succeeded)
                    {
                        result = await this._userManager.AddLoginAsync(user, info);
                        if (result.Succeeded)
                        {
                            await this._signInManager.SignInAsync(user, isPersistent: false);
                        }

                        await this._userManager.AddToRoleAsync(user, "Users");

                        return this.RedirectToLocal(returnUrl);
                    }

                    foreach(var e in result.Errors)
                    {
                        this.ModelState.AddModelError(string.Empty, e.Description);
                    }
                }

                vmLogin.ReturnUrl = returnUrl;
                vmLogin.LoginProviders = (await this._signInManager.GetExternalAuthenticationSchemesAsync())?.ToList();
                return this.View(nameof(Login), vmLogin);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveProfile(ProfileViewModel vmProfile)
        {
            try
            {
                this.ModelState.Clear();

                this.TryValidateModel(vmProfile.UserInformation);
                if (this.ModelState.IsValid)
                {
                    User user = await this._userManager.FindByEmailAsync(vmProfile.UserInformation.Email);
                    if (user != null)
                    {
                        user.FullName = vmProfile.UserInformation.Fullname;
                        user.FirstName = vmProfile.UserInformation.FirstName;
                        user.LastName = vmProfile.UserInformation.LastName;
                        user.DateOfBirth = vmProfile.UserInformation.DateOfBirth ?? DateTime.Now;
                        user.Customer = this.UnitOfWork.CustomerRepo.Get(c => c.Id == user.CustomerId.Value).SingleOrDefault();
                        if (user.Customer == null)
                        {
                            user.Customer = new Customer
                            {
                                Address = vmProfile.UserInformation.Address,
                                CityId = vmProfile.UserInformation.CityId,
                            };
                        }

                        IdentityResult result = await this._userManager.UpdateAsync(user);

                        if (result.Succeeded)
                        {
                            return this.RedirectToLocal(vmProfile.ReturnUrl);
                        }
                    }
                }

                return this.NotFound();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ProfileViewModel vmProfile)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    User user = await this._userManager.FindByEmailAsync(this.User.Identity.Name);

                    if (user != null)
                    {
                        IdentityResult result = await this._userManager.ChangePasswordAsync(user, vmProfile.PasswordInformation.CurrentPassword, vmProfile.PasswordInformation.NewPassword);

                        if (result.Succeeded)
                        {
                            return this.RedirectToAction(nameof(Profile));
                        }
                        else
                        {
                            this.ModelState.AddModelError(nameof(ProfilePasswordInformation.ConfirmPassword), this._localizer["Error while change password."]);
                        }
                    }
                }

                return this.NotFound();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
