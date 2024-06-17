using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace ER_Smms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("sv-SE");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("sv-SE");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("sv-SE");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("sv-SE");


        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });



    }
}
