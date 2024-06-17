using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ER_Smms.Data;
using ER_Smms.Models;
using ER_Smms.Models.Services;
using ER_Smms.Models.Interfaces;
using ER_Smms.Models.Repositories;
using ER_Smms.Models.ViewModels;
using ER_Smms.Models.ViewModels.Admin;
using ER_Smms.Extensions;
using NLog;
using ER_Smms.Blappserv.Interfaces;
using ER_Smms.Blappserv.ViewModels;
using ER_Smms.Blappserv.Services;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.StaticFiles;


//using LoggerService;

namespace ER_Smms
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment iWebHostEnvironment)
        {
            //LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            //LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
            Environment = iWebHostEnvironment;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddSingleton(new HttpClient { BaseAddress = new Uri(HostEnvironment.BaseAddress) });

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>
            //ILoggerManager, LoggerManager > ();

            //ClassInstance = new
            //services.AddSingleton<Startup>();
            //services.AddSingleton<IHttpContextAccessor>(s => s.HttpContextAccessor<Startup>());
            //services.AddSingleton<ILoggerManager>(s => s.LoggerManager<Startup>());
            services.AddSingleton<ILoggerManager, LoggerManager>();

            // --- Serverside Blazor
            services.AddRazorPages();

            services.AddServerSideBlazor(options =>
            {
                options.DetailedErrors = true;
                //options.DisconnectedCircuitMaxRetained = 100;
                //options.DisconnectedCircuitRetentionPeriod = TimeSpan.FromMinutes(3);
                //options.JSInteropDefaultCallTimeout = TimeSpan.FromMinutes(1);
                //options.MaxBufferedUnacknowledgedRenderBatches = 10;
                //.AddHubOptions(options =>
                // {
                //     options.ClientTimeoutInterval = TimeSpan.FromSeconds(60);
                //     options.EnableDetailedErrors = true;
                //     options.HandshakeTimeout = TimeSpan.FromSeconds(10);
                //     options.KeepAliveInterval = TimeSpan.FromSeconds(10);
                //     options.MaximumParallelInvocationsPerClient = 1;
                //     options.MaximumReceiveMessageSize = 32 * 1024;
                //     options.StreamBufferCapacity = 10;
                // });
            });
            services.Configure<RazorPagesOptions>(options => options.RootDirectory = "/Blappserv/Pages");

            services.AddControllersWithViews();

            services.AddDistributedMemoryCache();  // To use session state /ER

            services.AddSession(options =>  // To use session state /ER
            {
                options.Cookie.Name = ".ER_smms_data.Session";
                options.IdleTimeout = TimeSpan.FromSeconds(300);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);



            services.AddDatabaseDeveloperPageExceptionFilter();


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

            services.AddDefaultIdentity<IdentityAppUser>(options => {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+/ "; })
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
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 0;
            });

            services.AddScoped<IUserClaimsPrincipalFactory<IdentityAppUser>,
                UserClaimsPrincipalFactory<IdentityAppUser, IdentityRole>>();


            // DI Repos
            services.AddScoped<IHarbourRepo, DbHarbourRepo>();
            services.AddScoped<IPierRepo, DbPierRepo>();
            services.AddScoped<IBoatslipRepo, DbBoatslipRepo>();
            services.AddScoped<IMooringTypeRepo, DbMooringTypeRepo>();
            services.AddScoped<IBoatDataRepo, DbBoatDataRepo>();
            services.AddScoped<IWinterstoreSpotRepo, DbWinterstoreSpotRepo>();
            services.AddScoped<IServiceTypeRepo, DbServiceTypeRepo>();
            services.AddScoped<IServiceApplicationRepo, DbServiceApplicationRepo>();
            services.AddScoped<IServiceHistoryRepo, DbServiceHistoryRepo>();
            services.AddScoped<IApplicantRepo, DbApplicantRepo>();

            // DI Services
            services.AddScoped<IHarbourService, HarbourService>();
            services.AddScoped<IPierService, PierService>();
            services.AddScoped<IBoatslipService, BoatslipService>();
            services.AddScoped<IMooringTypeService, MooringTypeService>();
            services.AddScoped<IBoatDataService, BoatDataService>();
            services.AddScoped<IWinterstoreSpotService, WinterstoreSpotService>();
            services.AddScoped<IServiceTypeService, ServiceTypeService>();
            services.AddScoped<IServiceApplicationService, ServiceApplicationService>();
            services.AddScoped<IServiceHistoryService, ServiceHistoryService>();
            services.AddScoped<IApplicantService, ApplicantService>();

            // Viewmodel DI för Blazor Server
            services.AddScoped<IBEditBoatslipViewModel, BEditBoatslipViewModel>();
            services.AddScoped<IBManageCustomerViewModel, BManageCustomerViewModel>();
            services.AddScoped<ManageCustomerService>();
            services.AddScoped<BlazorAdminController>();



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
                //app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();

                app.UseDeveloperExceptionPage();

                //app.UseBrowserLink();
            }
            else
            {
                //app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UsePathBase("/bapp/"); this is allready set in Blazor _Host.cshtml
            //app.UsePathBase("/");
            //app.UsePathBase("/blappserv/");

            //app.MapWhen(ctx => !ctx.Request.Path
            //    .StartsWithSegments("/_framework/blazor.server.js"),
            //        subApp => subApp.UseStaticFiles());

            //var provider = new FileExtensionContentTypeProvider();
            //provider.Mappings["{EXTENSION}"] = "{CONTENT TYPE}";

            //app.UseStaticFiles(new StaticFileOptions { ContentTypeProvider = provider });

            app.UseWebSockets();

            app.ConfigureCustomExceptionMiddleware();  // My own custom Global errorhandling Eric R

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            //app.UseStaticFiles("/Blappserv");

            app.UseSession(); // To use session state /ER

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();





            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Frontend}/{action=Index}/{id?}");


                endpoints.MapControllerRoute(
                name: "Admin",
                pattern: "Admin/{id?}",
                defaults: new { controller = "Admin", action = "Index" });

                endpoints.MapControllerRoute(
                name: "Welcome",
                pattern: "Welcome/{id?}",
                defaults: new { controller = "Frontend", action = "Welcome" });



                endpoints.MapBlazorHub();
                //endpoints.MapRazorPages();
                //endpoints.MapFallbackToPage("/blappserv/{*clientroutes:nonfile}", "/_Host");
                endpoints.MapFallbackToPage("/blappserv/{*page}", "/_Host");
                //endpoints.MapFallbackToPage("/_Host");
                //endpoints.MapFallbackToPage("/blappserv", "/_Host");


                //endpoints.MapControllerRoute(
                //name: "AccessDenied",
                //pattern: "AccessDenied/{id?}",
                //defaults: new { controller = "Frontend", action = "AccessDenied" });

                //endpoints.MapControllerRoute(
                //name: "User",
                //pattern: "User/{id?}",
                //defaults: new { controller = "User", action = "Index" });



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