using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Th.Data.Helper;
using Th.Models;
using ThTest.Models.ViewModels;

namespace ThTest.Components
{
    [ViewComponent(Name = "MainNavigation")]
    public class MainNavigationViewComponent: ViewComponent
    {
        private IThCategoryRepository _repoCategory;

        public MainNavigationViewComponent(IThCategoryRepository repoCategory)
        {
            try
            {
                this._repoCategory = repoCategory;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public IViewComponentResult Invoke()
        {
            try
            {
                var requestCulture = this.HttpContext.Features.Get<IRequestCultureFeature>();
                var requestCultureProvider = requestCulture.Provider as CookieRequestCultureProvider;
                var requestAcceptLanguageProvice = requestCulture.Provider as AcceptLanguageHeaderRequestCultureProvider;
                MainNavigationViewModel vmMainNavigation = new MainNavigationViewModel
                {
                    Categories = this._repoCategory.GetAll(),
                    CurrentLanguage = requestCulture.RequestCulture.Culture.ToString(),
                    TwoLetterCurrentLanguage = requestCulture.RequestCulture.Culture.TwoLetterISOLanguageName,
                    SupportedCultures = requestCultureProvider != null ? requestCultureProvider.Options.SupportedUICultures : requestAcceptLanguageProvice.Options.SupportedUICultures,
                };

                return this.View(vmMainNavigation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
