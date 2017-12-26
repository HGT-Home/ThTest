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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThTest.Controllers
{
    public class AccountController : ThBaseController
    {
        private readonly UserManager<User> _userManager;

        private readonly SignInManager<User> _signInManager;

        private readonly RoleManager<Role> _roleMananger;

        private readonly IStringLocalizer _localizer;


        public AccountController(LoginSessionInfo loginSessionInfo, UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager, IStringLocalizer<AccountController> localizer)
            : base(loginSessionInfo)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleMananger = roleManager;
            this._localizer = localizer;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return this.View(new RegisterViewModel());
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
                        UserName = "Admin",
                        Email = "admin@gmail.com",
                        FullName = "Administrator",
                        DateOfBirth = DateTime.Now,
                    };

                    IdentityResult userAdminResult = await this._userManager.CreateAsync(adminUser, "Administrator10");
                    if (userAdminResult.Succeeded)
                    {
                        await this._userManager.AddToRoleAsync(adminUser, "Administrators");
                    }
                }
            }

            // Create regitation user.
            if (this.ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = vmRegister.Username,
                    Email = vmRegister.Email,
                    FullName = vmRegister.Fullname,
                    DateOfBirth = vmRegister.DateOfBirth
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

                        await this._userManager.AddToRoleAsync(user, "Users");

                        return this.RedirectToAction("Login", "Account");
                    }
                }
            }

            return this.View(vmRegister);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl,
            });
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel vmLogin)
        {
            if (this.ModelState.IsValid)
            {
                User user = await this._userManager.FindByNameAsync(vmLogin.Username);
                if (user != null)
                {
                    await this._signInManager.SignOutAsync();

                    var signInResult = await this._signInManager.PasswordSignInAsync(vmLogin.Username, vmLogin.Password, vmLogin.IsRememberMe, false);

                    if (signInResult.Succeeded)
                    {
                        // Set login session.
                        this.LoginSession.UserId = user.Id;
                        this.LoginSession.Username = user.UserName;
                        this.LoginSession.LoginDate = DateTime.UtcNow;
                        this.LoginSession.CustomerId = user.CustomerId;
                        this.LoginSession.CustomerName = user.FullName;
                        this.LoginSession.SaveSession();

                        StringBuilder sbRoles = new StringBuilder();
                        foreach (string role in await this._userManager.GetRolesAsync(user))
                        {
                            sbRoles.Append(role);
                            sbRoles.Append(";");
                        }

                        this.LoginSession.RoleNames = sbRoles.ToString();

                        if (user != null)
                        {
                            if (this._userManager.IsInRoleAsync(user, "Administrators").Result)
                            {
                                return this.RedirectToAction("IndexAdmin", "Home");
                            }
                        }

                        return this.Redirect(vmLogin?.ReturnUrl ?? "/Admin/Index");
                    }
                }

                this.ModelState.AddModelError(nameof(LoginViewModel.Password), this._localizer["Username or password are invalid."]);
            }

            return this.View(vmLogin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await this._signInManager.SignOutAsync();

            return this.RedirectToAction("Login", "Account");
        }

        public async Task<IActionResult> Profile()
        {
            return this.View(new ProfileViewModel());
        }
    }
}
