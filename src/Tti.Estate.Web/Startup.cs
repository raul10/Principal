using AutoMapper;
using Localization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using System.Collections.Generic;
using System.Globalization;
using Tti.Estate.Business;
using Tti.Estate.Data;
using Tti.Estate.Data.Entities;
using Tti.Estate.Infrastructure;
using Tti.Estate.Infrastructure.Services;
using Tti.Estate.Web.Services;

namespace Tti.Estate.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // Configure InMemoryDatabase
        //private void ConfigureInMemoryDatabase(IServiceCollection services)
        //{
        //    services.AddDbContext<AppDbContext>(options =>
        //        options.UseInMemoryDatabase("Estate"));
        //}

        //Configure SQL Server Database
        private void ConfigureSqlDatabase(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(c =>
                c.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
           //  ConfigureInMemoryDatabase(services);  
            ConfigureSqlDatabase(services);
            ConfigureServices(services);
        }

        public void ConfigureStagingServices(IServiceCollection services)
        {
            ConfigureSqlDatabase(services);
            //ConfigureInMemoryDatabase(services);
            ConfigureServices(services);
        }

        public void ConfigureProductionServices(IServiceCollection services)
        {
            ConfigureSqlDatabase(services);
            //ConfigureInMemoryDatabase(services);
            ConfigureServices(services);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {               
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new List<CultureInfo>
                    {
                        new CultureInfo("en-US"),
                        new CultureInfo("es-CR"),
                    };

                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });
            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();

            services.AddAuthorization(ConfigureAuthorization);

            services.AddAutoMapper();

            services.AddLocalization(options => options.ResourcesPath = "Resources");         
            
            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            })
             .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
            .AddDataAnnotationsLocalization(options => {
                options.DataAnnotationLocalizerProvider = (type, factory) =>
                    factory.Create(typeof(SharedResource));
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            .AddMvcLocalization();

            services.AddHttpContextAccessor();

            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddSingleton(_ => CloudStorageAccount.Parse(Configuration.GetConnectionString("StorageAccount")));

            services.AddRepositories();
            services.AddInfrastructure();
            services.AddBusiness();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment() || env.IsStaging())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithRedirects("~/Home/StatusCode");
            var supportedCultures = new[]
              {
                    new CultureInfo("ru"),
                    new CultureInfo("en-US"),
                        
                };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,
                // UI strings that we have localized.
                SupportedUICultures = supportedCultures
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
         
            app.UseRequestLocalization();
            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void ConfigureAuthorization(AuthorizationOptions options)
        {
            options.AddPolicy(PolicyConstants.UserManagement, policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireRole(UserRole.Manager.ToString());
            });
            options.AddPolicy(PolicyConstants.TransactionApproval, policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireRole(UserRole.Manager.ToString());
            });
        }
    }
}
