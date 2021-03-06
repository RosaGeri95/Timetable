﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace TimeTableASP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging((hostingContext, logging) =>
                {
                    // Remove the Debug provider (and other providers) and filter most
                    // of the remaining logging. Reducing the logging output makes it
                    // easier to see the log messages produced by the LoggerMessage
                    // pattern demonstrated in this sample app.
                    //
                    // Setting options.IncludeScopes is required in ASP.NET Core 2.0
                    // apps. Setting IncludeScopes via appsettings configuration files
                    // is a feature that's planned for the ASP.NET Core 2.1 release.
                    // See: https://github.com/aspnet/Logging/pull/706
                    logging.ClearProviders();
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddFilter("Microsoft.EntityFrameworkCore.Update", LogLevel.None);
                    logging.AddFilter("Microsoft.EntityFrameworkCore.Infrastructure", LogLevel.None);
                    logging.AddFilter("Microsoft.AspNetCore.Mvc.RedirectToRouteResult", LogLevel.None);
                    logging.AddFilter("Microsoft.AspNetCore.Mvc.RazorPages.Internal.PageActionInvoker", LogLevel.None);
                    logging.AddFilter("Microsoft.AspNetCore.StaticFiles.StaticFileMiddleware", LogLevel.None);
                    logging.AddConsole(options => options.IncludeScopes = true);
                })
                .Build();
    }
}
