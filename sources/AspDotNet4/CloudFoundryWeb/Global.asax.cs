﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CloudFoundryWeb
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var _env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (string.IsNullOrEmpty(_env))
                _env = "development";

            ApplicationConfig.Configure(_env);
            ApplicationConfig.ConfigureLogging();

            ManagementConfig.ConfigureManagementActuators(
                ApplicationConfig.Configuration,
                ApplicationConfig.LoggerProvider,
                GlobalConfiguration.Configuration.Services.GetApiExplorer(),
                ApplicationConfig.LoggerFactory);

            ManagementConfig.Start();
        }
        protected void Application_Stop()
        {
            ManagementConfig.Stop();
        }
    }
}
