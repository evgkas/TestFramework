using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;

namespace MyFramework.Service
{
    public static class Logger
    {
        private static ILoggerFactory loggerFactory;

        public static void ConfigureLogger()
        {
            loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddNLog(new NLogProviderOptions { CaptureMessageTemplates = true, CaptureMessageProperties = true })
                    .SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
            });

            LogManager.Setup().LoadConfigurationFromAppSettings();
        }

        public static ILogger<T> GetLogger<T>()
        {
            if (loggerFactory == null)
            {
                ConfigureLogger();
            }

            return loggerFactory.CreateLogger<T>();
        }
    }
}
