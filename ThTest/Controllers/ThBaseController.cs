using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using ThTest.Models;
using Th.Data.Helper;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThTest.Controllers
{
    [Authorize]
    public class ThBaseController : Controller
    {
        protected LoginSessionInfo LoginSession { get; set; }

        protected IUnitOfWork UnitOfWork { get; set; }

        public ThBaseController(LoginSessionInfo loginSessionInfo, IUnitOfWork unitOfWork)
        {
            //var cultureFeature = this.HttpContext.Features.Get<IRequestCultureFeature>();

            //if (cultureFeature != null)
            //{
            //    CookieRequestCultureProvider cookiePrvider = cultureFeature.Provider as CookieRequestCultureProvider;

            //    if (cookiePrvider == null)
            //    {
            //        this.Response.Cookies.Append(
            //            CookieRequestCultureProvider.DefaultCookieName,
            //            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cultureFeature.RequestCulture.Culture.ToString())),
            //            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            //            );
            //    }
            //}

            this.LoginSession = loginSessionInfo;

            // UnitOfWork Initialization.
            this.UnitOfWork = unitOfWork;
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> SetLanguage(string rdoLanguages, string returnUrl)
        {
            this.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName, 
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(rdoLanguages)), 
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });

            return this.LocalRedirect(this.Url.IsLocalUrl(returnUrl)? returnUrl: "/");
        }
    }
}
