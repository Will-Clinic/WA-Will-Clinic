using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WillClinic.Data;

namespace WillClinic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = BuildWebHost(args);

            // Attempt to seed any tables which require seed data, such as the Library table
            using (IServiceScope scope = host.Services.CreateScope())
            {
                IServiceProvider services = scope.ServiceProvider;

                try
                {
                    SeedLibraries.Initialize(services);
                }
                catch
                {
                    services.GetService<ILogger>().LogCritical("Could not seed database!");
                    throw;
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                    .UseStartup<Startup>()
                    .Build();

        //public static IWebHost BuildWebHost(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        // Configure IConfiguration for DI throughout the app. Note that any keys contained in
        //        // Azure Key Vault will be available using key/value pair access on IConfiguration objects.
        //        .ConfigureAppConfiguration((context, config) =>
        //        {
        //            // Bring in the appsettings.json and environment variables to IConfiguration for DI
        //            config.SetBasePath(Directory.GetCurrentDirectory())
        //                .AddJsonFile("appsettings.json", optional: false)
        //                .AddEnvironmentVariables();

        //            // Build the configuration to bring in key vault configuration
        //            var builtConfig = config.Build();

        //            // Add access to Azure Key Vault to IConfiguration for DI within the application.
        //            // Note that the the VaultName, ClientId, and ClientSecret keys must exist under
        //            // the AzureKeyVault object within the appsettings.json file in order to configure
        //            // access to the key vault, and this will throw an exception if your computer is
        //            // not connected to the internet.
        //            //config.AddAzureKeyVault(
        //            //    $"https://{builtConfig["AzureKeyVault:VaultName"]}.vault.azure.net/",
        //            //    builtConfig["AzureKeyVault:ClientId"],
        //            //    builtConfig["AzureKeyVault:ClientSecret"]);
        //        })

        //        .ConfigureLogging((context, logging) =>
        //        {
        //            logging.AddConfiguration(context.Configuration.GetSection("Logging"));
        //            logging.AddConsole();
        //            logging.AddDebug();
        //        })
        //        .UseStartup<Startup>()
        //        .Build();
    }
}
