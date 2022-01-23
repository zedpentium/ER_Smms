using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using ER_Smms.Models;
using ER_Smms.Models.Services;
using ER_Smms.Data;
using ER_Smms.Models.Interfaces;


namespace ER_Smms
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment iWebHostEnvironment)
        {
            Configuration = configuration;
            Environment = iWebHostEnvironment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllersWithViews();

            services.AddDistributedMemoryCache();  // To use session state /ER

            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);



            services.AddSession(options =>  // To use session state /ER
            {
                options.Cookie.Name = ".ER_smms_data.Session";
                options.IdleTimeout = TimeSpan.FromSeconds(300);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });


            // -------- DBContexts etc start------- For MySQL server 8.0.27

            //var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));

            services.AddDbContext<AppDbContext>(options =>
                 //options.UseSqlServer(
                 //    Configuration.GetConnectionString("ProductIncConnection")));

                 options.UseSqlServer(
                     Configuration.GetConnectionString("Mssql_server"))
                     //, ServerVersion.AutoDetect(connectionString))
                // The following three options help with debugging, but should
                // be changed or removed for production.
                //.LogTo(Console.WriteLine, LogLevel.Information)
                //.EnableSensitiveDataLogging()
                //.EnableDetailedErrors()
            );

            services.AddDefaultIdentity<IdentityAppUser>(options => options.SignIn.RequireConfirmedAccount = false)
                         .AddRoles<IdentityRole>()
                         .AddRoleManager<RoleManager<IdentityRole>>()
                         .AddEntityFrameworkStores<AppDbContext>();


            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 0;
                options.Password.RequiredUniqueChars = 0;
            });

            services.AddScoped<IUserClaimsPrincipalFactory<IdentityAppUser>,
                UserClaimsPrincipalFactory<IdentityAppUser, IdentityRole>>();


            // DI Repos
            services.AddScoped<IPeopleRepo, DbPeopleRepo>();
            services.AddScoped<ICountryRepo, DbCountryRepo>();
            services.AddScoped<ICityRepo, DbCityRepo>();
            services.AddScoped<ILanguageRepo, DbLanguageRepo>();

            services.AddScoped<IHarbourRepo, DbHarbourRepo>();
            services.AddScoped<IPierRepo, DbPierRepo>();
            services.AddScoped<IBoatslipRepo, DbBoatslipRepo>();

            // DI Services
            services.AddScoped<IPeopleService, PeopleService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ILanguageService, LanguageService>();

            services.AddScoped<IHarbourService, HarbourService>();
            services.AddScoped<IPierService, PierService>();
            services.AddScoped<IBoatslipService, BoatslipService>();



            services.AddRazorPages();

            //services.ConfigureApplicationCookie(opts => // Custom Identity Access denied path /ER
            //{
            //    opts.AccessDeniedPath = "/Shared/_AccessDenied";
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseSession(); // To use session state /ER

            app.UseAuthentication();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();


                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Frontend}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                name: "Admin",
                pattern: "Admin/{id?}",
                defaults: new { controller = "Admin", action = "Index" });




                //endpoints.MapControllerRoute(
                //name: "AccessDenied",
                //pattern: "AccessDenied/{id?}",
                //defaults: new { controller = "Frontend", action = "AccessDenied" });

                //endpoints.MapControllerRoute(
                //name: "User",
                //pattern: "User/{id?}",
                //defaults: new { controller = "User", action = "Index" });

                //endpoints.MapControllerRoute(
                //name: "Country",
                //pattern: "Country/{id?}",
                //defaults: new { controller = "Country", action = "Index" });

                //endpoints.MapControllerRoute(
                //name: "City",
                //pattern: "City/{id?}",
                //defaults: new { controller = "City", action = "Index" });

                //endpoints.MapControllerRoute(
                //name: "Language",
                //pattern: "Language/{id?}",
                //defaults: new { controller = "Language", action = "Index" });

                //endpoints.MapControllerRoute(
                //name: "PersonDetails",
                //pattern: "Details/{id?}",
                //defaults: new { controller = "People", action = "PersonDetails" });

                //endpoints.MapControllerRoute(
                //name: "AddLanguages",
                //pattern: "AddLanguagesToPerson/{id?}",
                //defaults: new { controller = "People", action = "AddLanguageView" });


                //endpoints.MapControllerRoute(
                //name: "Edituserroles",
                //pattern: "UserRoles/{id?}",
                //defaults: new { controller = "Identity", action = "Index" });

                //endpoints.MapControllerRoute(
                //name: "CreateRoles",
                //pattern: "CreateRole/{id?}",
                //defaults: new { controller = "Identity", action = "Create" });

                //endpoints.MapControllerRoute(
                //name: "UpdateRoles",
                //pattern: "UpdateRole/{id?}",
                //defaults: new { controller = "Identity", action = "Update" });

                //endpoints.MapControllerRoute(
                //name: "CheckIfRolesExist",
                //pattern: "IsRolesEmpty/{id?}",
                //defaults: new { controller = "Identity", action = "IsRolesEmpty" });

                //endpoints.MapControllerRoute(
                //name: "Roles",
                //pattern: "Roles/{id?}",
                //defaults: new { controller = "Role", action = "Index" });




            });
        }
    }
}