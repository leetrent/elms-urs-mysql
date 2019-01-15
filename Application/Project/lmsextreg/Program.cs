﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using lmsextreg.Data;
using lmsextreg.Constants;

namespace lmsextreg
{   
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        ////////////////////////////////////////////////////////////////////////////////
        // APPSETTINGS_DIRECTORY
        ////////////////////////////////////////////////////////////////////////////////
        //  1. see EnvironmentVariables.txt
        //  2. see lmsextreg.Constants.APPSETTINGS_FILE_NAME
        ////////////////////////////////////////////////////////////////////////////////
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.SetBasePath(Environment.GetEnvironmentVariable("APPSETTINGS_DIRECTORY"));
                    config.AddJsonFile(MiscConstants.APPSETTINGS_FILE_NAME, optional: false, reloadOnChange: true);
                })
                .UseStartup<Startup>();                
    }
}