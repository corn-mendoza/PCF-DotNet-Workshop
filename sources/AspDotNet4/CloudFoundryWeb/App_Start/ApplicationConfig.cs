using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Pivotal.Helper;
using Steeltoe.Extensions.Configuration.CloudFoundry;
using Steeltoe.Extensions.Logging;
using System;
using System.Configuration;
using System.IO;
using System.Linq;

namespace CloudFoundryWeb
{
    public class ApplicationConfig
    {
        public static IConfigurationRoot Configuration { get; set; }
        public static ILoggerFactory LoggerFactory { get; set; }
        public static ILoggerProvider LoggerProvider { get; set; }

        public static void Configure(string environment)
        {

            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .SetBasePath(GetContentRoot())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddEnvironmentVariables()
                .AddCloudFoundry();

            Configuration = builder.Build();

        }

        private static void UpdateConnectionStrings()
        {
            var _se = ConfigurationManager.ConnectionStrings;
            for (int _i = 0; _i < ConfigurationManager.ConnectionStrings.Count; _i++)
            {
                ConnectionStringSettings _item = (ConnectionStringSettings)_se[_i];
                var _t = CFEnvironmentVariables.GetConfigurationConnectionString(Configuration, _item.Name);

                Console.WriteLine($"*** Processing connection string: {_item.Name}");

                if (!string.IsNullOrEmpty(_t))
                {
                    Console.WriteLine($"*** Updating connection string {_item.ConnectionString} with {_t}");

                    var c = new ConnectionStringSettings(_item.Name, _t);

                    _se.Remove(_item);
                    _se.Add(c);
                    //_item.ConnectionString = _t;
                }

                Console.WriteLine($"*** Using connection string: {_item.ConnectionString}");

            }
        }

        public static void ConfigureLogging()
        {
            LoggerProvider = new DynamicLoggerProvider(new ConsoleLoggerSettings().FromConfiguration(Configuration));
            LoggerFactory = new LoggerFactory();
            LoggerFactory.AddProvider(LoggerProvider);
        }

        public static string GetContentRoot()
        {
            var basePath = (string)AppDomain.CurrentDomain.GetData("APP_CONTEXT_BASE_DIRECTORY") ??
               AppDomain.CurrentDomain.BaseDirectory;
            return Path.GetFullPath(basePath);
        }
    }
}