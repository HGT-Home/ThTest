using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Th.Configuration;

namespace ThTest.Models.Helpers
{
    public class LocalizationPipeline
    {
        public void Configure(IApplicationBuilder app, IOptions<ThConfiguration> thConfiguration)
        {
            // Localize
            ThConfiguration thConfig = thConfiguration.Value;

            IList<CultureInfo> lstSupportCurlture = new List<CultureInfo>();
            foreach (ThCulture cul in thConfig.Cultures)
            {
                lstSupportCurlture.Add(new CultureInfo(cul.Name));
            }

            string strDefaultLang = thConfig.Cultures.FirstOrDefault(c => c.IsDefault).Name;

            RequestLocalizationOptions localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(culture: strDefaultLang, uiCulture: strDefaultLang),
                SupportedCultures = lstSupportCurlture,
                SupportedUICultures = lstSupportCurlture
            };

            RouteDataRequestCultureProvider requestProvider = new RouteDataRequestCultureProvider()
            {
                Options = localizationOptions
            };

            localizationOptions.RequestCultureProviders = new[] { requestProvider };

            app.UseRequestLocalization(localizationOptions);
        }
    }
}
