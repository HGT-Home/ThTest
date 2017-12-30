using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ThTest.Infrastructures
{
    public class LanguageMiddleware
    {
        private RequestDelegate _nextDelegate;

        public LanguageMiddleware(RequestDelegate nexDelegate)
        {
            this._nextDelegate = nexDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            foreach(var h in httpContext.Request.Headers)
            {
                Debug.WriteLine($"{h.Key} = {h.Value}");
            }

            Debug.WriteLine($"Culture Languege: {httpContext.Request.Cookies[CookieRequestCultureProvider.DefaultCookieName]}");

            Debug.WriteLine("---------------------------------------------------");
            Debug.WriteLine("Features: ");
            Debug.WriteLine("---------------------------------------------------");
            foreach (var f in httpContext.Features)
            {
                Debug.WriteLine($"{f.Key} = {f.Value}");
            }

            Debug.WriteLine("---------------------------------------------------");
            Debug.WriteLine("Culture Information: ");
            Debug.WriteLine("---------------------------------------------------");
            Debug.WriteLine($"Current Culture: {CultureInfo.CurrentCulture.Name}");
            Debug.WriteLine($"UI Culture: {CultureInfo.CurrentUICulture.Name}");
            Debug.WriteLine("---------------------------------------------------");

            await this._nextDelegate.Invoke(httpContext);
        }
    }
}
