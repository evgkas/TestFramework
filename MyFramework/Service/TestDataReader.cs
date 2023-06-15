using Microsoft.Extensions.Configuration;

namespace MyFramework.Service
{
    public class TestDataReader
    {
        private IConfiguration configuration;

        public TestDataReader()
        {
            var environment = Configuration.Configuration.GetEnvironmentName();

            configuration = new ConfigurationBuilder()
                .SetBasePath($"{AppContext.BaseDirectory}/resources")
                .AddJsonFile($"{environment}.json")
                .Build();
        }

        public string GetTestData(string key)
        {
            return configuration[key];
        }
    }
}
