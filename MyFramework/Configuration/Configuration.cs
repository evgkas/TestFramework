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

        public static BrowserType ReadBrowserTypeFromConfig()
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
            var config = InitConfiguration();
            return config["Environment"];
        }
    }
}