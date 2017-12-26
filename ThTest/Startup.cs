using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Th.Data.Helper;
using Th.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Th.Configuration;
using Microsoft.Extensions.Options;
using ThTest.Resources;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Routing;
using ThTest.Models;

namespace ThTest
{
    public class Startup
    {
        private IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            this.Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
                .Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.Configure<ThConfiguration>(this.Configuration.GetSection("ThConfiguration"));

            //services.AddDbContext<ThDbContext>(option => option.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddDbContext<ThDbContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Th.Data.Helper")));

            // Authentication setting.
            services.AddIdentity<User, Role>().AddEntityFrameworkStores<ThDbContext>().AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                // Password Setting.
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                // Lockout Setting.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User Setting.
                options.User.RequireUniqueEmail = true;
            });

            // Use cookie authentication.
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(120);
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            // Use Dependency Injection to create the Repository and order services.
            //services.AddTransient<IThRepository<Product>, ThProductRepository>();
            //services.AddTransient<IThRepository<Category>, ThCategoryRepository>();
            //services.AddTransient<IThRepository<Supplier>, ThSupplierRepository>();
            //services.AddScoped(typeof(IThRepository<>), typeof(ThRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IThCountryRepository, ThCountryRepository>();
            services.AddTransient<IThCityRepository, ThCityRepository>();
            services.AddTransient<IThCategoryRepository, ThCategoryRepository>();
            services.AddTransient<IThProductRepository, ThProductRepository>();
            services.AddTransient<IThSupplierRepository, ThSupplierRepository>();
            services.AddTransient<IThOrderRepository, ThOrderRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            

            // Customer implement service and use DI to create the instance.
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddScoped<LoginSessionInfo>(sp => LoginSessionInfo.GetLoginSessionInfo(sp));

            // Loacalize setting.
            services.AddLocalization(options =>
            {
                options.ResourcesPath = "Resources";
            });

            services.AddMvc()
                .AddViewLocalization(
                    LanguageViewLocationExpanderFormat.Suffix, 
                    options => 
                    {
                        options.ResourcesPath = "Resources";
                    })
                .AddDataAnnotationsLocalization(options => 
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) => factory.Create(typeof(ShareResource));
                });

            //services.AddMemoryCache();
            services.AddDistributedMemoryCache();
            services.AddSession(options => 
            {
                options.IdleTimeout = TimeSpan.FromDays(1);
                options.Cookie.HttpOnly = true;
            });

            //services.Configure<RouteOptions>(options =>
            //{
            //    options.ConstraintMap.Add("lang", typeof(LanguageRouteConstraint));
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IOptions<ThConfiguration> thConfiguration)
        {
            loggerFactory.AddConsole(this.Configuration.GetSection("Logging"));

            ThConfiguration thConfig = thConfiguration.Value;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStatusCodePages();
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = (context) =>
                {
                    context.Context.Response.Headers["Cache-Control"] = thConfig.StaticFilesHeaders.CacheControl;
                    context.Context.Response.Headers["Pragma"] = thConfig.StaticFilesHeaders.Pragma;
                    context.Context.Response.Headers["Expires"] = thConfig.StaticFilesHeaders.Expires;
                }
            });
            app.UseSession();
            app.UseAuthentication();

            // Localize
            IList<CultureInfo> lstSupportCurlture = (from c in thConfig.Cultures
                                                     select new CultureInfo(c.Name)
                                                     ).ToList();

            string strDefaultLang = thConfig.Cultures.FirstOrDefault(c => c.IsDefault).Name;

            RequestLocalizationOptions localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(culture: strDefaultLang, uiCulture: strDefaultLang),
                SupportedCultures = lstSupportCurlture,
                SupportedUICultures = lstSupportCurlture
            };

            //RouteDataRequestCultureProvider requestProvider = new RouteDataRequestCultureProvider()
            //{
            //    Options = localizationOptions
            //};

            //localizationOptions.RequestCultureProviders.Insert(0, requestProvider);

            //var cookieProvider = localizationOptions.RequestCultureProviders
            //    .OfType<CookieRequestCultureProvider>()
            //    .First();

            //// Set the new cookie name
            //cookieProvider.CookieName = "UserCulture";

            app.UseRequestLocalization(localizationOptions);

            //app.UseRequestLocalization(new RequestLocalizationOptions
            //{
            //    DefaultRequestCulture = new RequestCulture(strDefaultLang),
            //    SupportedCultures = lstSupportCurlture,
            //    SupportedUICultures = lstSupportCurlture,
            //});

            app.UseMvc(options =>
            {
                //options.MapRoute(
                //    name: "product",
                //    template: "{categoryId:int}/Page{page:int}",
                //    defaults: new { controller = "Product", action = "GetProductByCategoryId" });

                //options.MapRoute(
                //    name: "product1",
                //    template: "{categoryId:int}",
                //    defaults: new { controller = "Product", action = "GetProductByCategoryId", page = 1 });

                options.MapRoute(
                   name: "default",
                   template: "{controller=Home}/{action=Index}/{id?}");

                //options.MapRoute(
                //    name: "default",
                //    template: "{controller=Home}/{action=Index}/{id?}");

                //options.MapRoute(
                //    name: "default",
                //    template: "{*catchall}",
                //    defaults: new { lang = "en-US", controller = "ThBase", action = "RedirectToDefaultLanguage"});
            });
        }
    }
}
