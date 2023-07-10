using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureAPICRUD
{
    public static class ConfigurationReader
    {
        private static IConfigurationRoot configuration;

        static ConfigurationReader()
        {
            var builder = new ConfigurationBuilder()
         .SetBasePath(Environment.CurrentDirectory)
         .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

            configuration = builder.Build();
        }

        public static string GetConnectionString()
        {
            return configuration.GetConnectionString("DevConnection");
        }
    }
}
