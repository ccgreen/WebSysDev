using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebSysDev
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // create the WebHost object; the method is declared in the bottom
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                // get the service providers
                var services = scope.ServiceProvider;
                try
                {
                    var serviceProvider = services.GetRequiredService<IServiceProvider>();
                    // get the Config object for the appsettings.json file 
                    var configuration = services.GetRequiredService<IConfiguration>();
                    // pass the service proiders and the config object to CreateRoles()
                    Data.SeedRoles.CreateRoles(serviceProvider, configuration).Wait();

                }
                catch (Exception exception)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(exception, "An error occurred while creating roles");
                }
            }

            // start the web app
            host.Run();

            //this is the same as the host declaration and host.Run(); combined
            //CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
