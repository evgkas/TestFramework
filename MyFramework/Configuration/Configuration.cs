using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace MyFramework.Configuration
{
    public class Configuration
    {
        public static IConfiguration InitConfiguration()
        {                      
            var configPath = Path.Combine(Environment.CurrentDirectory, "appConfig.json");

            var config = new ConfigurationBuilder()
               .AddJsonFile(configPath)
               .Build();
            return config;
        }

        public static BrowserType GetBrowserType()
        {
            string browser = TestContext.Parameters["browser"];

            switch (browser.ToUpper())
            {
                case "EDGE":
                    return BrowserType.EDGE;
                case "FIREFOX":
                    return BrowserType.FIREFOX;
                default:
                    return BrowserType.CHROME;
            }
        }

        public static string GetEnvironmentName()
        {
            string environment = TestContext.Parameters["environment"];

            if(environment == null || environment == "")
            {
                environment = "dev";
            }

            return environment;
        }
    }
}