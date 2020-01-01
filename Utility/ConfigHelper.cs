using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utility
{
    public class ConfigHelper
    {
        public static IConfiguration Configuration { get; set; }

        static ConfigHelper()
        {
            Configuration = new ConfigurationBuilder()
                .AddInMemoryCollection()
                .AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }

        public static string GetValue(string key)
        {
            return Configuration[key];
        }
    }
}
