using Microsoft.Extensions.Configuration;

namespace MyFramework.Configuration
{
    public class Configuration
    {
        public static IConfiguration InitConfiguration()
        {                      
            var configPath = Path.Combine(Environment.CurrentDirectory, "xunit.runner.json");

            var config = new ConfigurationBuilder()
               .AddJsonFile(configPath)
               .Build();
            return config;
        }

        public static BrowserType GetBrowserType()
        {
            var config = InitConfiguration();
            switch (config["Browser"])
            {
                case "EDGE":
                    return BrowserType.EDGE;
                case "CHROME":
                    return BrowserType.CHROME;
                default:
                    return BrowserType.FIREFOX;
            }
        }

        public static string GetEnvironmentName()
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            return environment;
        }
    }
}