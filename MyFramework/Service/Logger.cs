using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            //NLogBuilder.ConfigureNLog("nlog.config"); //take attention to path of config - устарело
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
