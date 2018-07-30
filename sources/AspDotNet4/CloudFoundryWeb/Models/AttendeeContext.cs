using Pivotal.Helper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CloudFoundryWeb.Models
{
    public class AttendeeContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public AttendeeContext() : base(ConnectionString)
        {
        }

        public static string ConnectionString
        {
            get
            {
                try
                {
                    var _connect = CFEnvironmentVariables.GetConfigurationConnectionString(ApplicationConfig.Configuration, "AttendeeContext");
                    if (!string.IsNullOrEmpty(_connect))
                    {
                        Console.WriteLine($"Using UPS: '{_connect}' for connection");
                        return _connect;
                    }
                }
                catch { }

                var _s = System.Configuration.ConfigurationManager.ConnectionStrings["AttendeeContext"].ConnectionString;
                Console.WriteLine($"Using web.config: '{_s}' for connection");

                return _s;
            }
        }

        public System.Data.Entity.DbSet<CloudFoundryWeb.Models.AttendeeModel> AttendeeModels { get; set; }
    }
}
