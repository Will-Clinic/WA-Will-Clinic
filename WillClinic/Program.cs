﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WillClinic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    // Bring in the appsettings.json and environment variables to IConfiguration for DI
                    config.SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false)
                        .AddEnvironmentVariables();

                    // Build the configuration to bring in key vault configuration
                    var builtConfig = config.Build();

                    // Add access to Azure Key Vault to IConfiguration for DI within the application
                    config.AddAzureKeyVault(
                        $"https://{builtConfig["AzureKeyVault:VaultName"]}.vault.azure.net/",
                        builtConfig["AzureKeyVault:ClientId"],
                        builtConfig["AzureKeyVault:ClientSecret"]);
                })
                .UseStartup<Startup>()
                .Build();
    }
}
