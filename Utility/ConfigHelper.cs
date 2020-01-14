using Microsoft.Extensions.Configuration;

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


        public static string GetConnectionValue(string key)
        {
            return Configuration.GetConnectionString(key);
        }
    }
}
