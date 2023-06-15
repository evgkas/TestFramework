using Microsoft.Extensions.Logging;
using MyFramework.Model;
using MyFramework.Service;
using NLog.Extensions.Logging;

namespace MyFramework.Tests
{
    public abstract class BaseTest : IDisposable
    {
        internal static Steps.GmailSteps gmailSteps = new();
        internal static Steps.ProtonSteps protonSteps = new();
        internal User gmailValidUser;
        internal User protonValidUser;
        protected static ILogger<BaseTest> logger;
        private string testScreenshotDirectory = "screenshots";

        public BaseTest()
        {
            gmailSteps.InitBrowser();
            gmailValidUser = UserCreator.withGmailCredentials();
            protonValidUser = UserCreator.withProtonCredentials();

            logger = Logger.GetLogger<BaseTest>();

            //if (!Directory.Exists(testScreenshotDirectory))
            //{
            //    Directory.CreateDirectory(testScreenshotDirectory);
            //}
        }

        public void Dispose()
        {
            gmailSteps.CloseBrowser();
        }

        public static IEnumerable<object[]> GmailInvalidUsers()
        {
            yield return new object[] { UserCreator.withInvalidLogin() };
            yield return new object[] { UserCreator.withEmptyUsername() };
            yield return new object[] { UserCreator.gmailWithInvalidPassword() };
            yield return new object[] { UserCreator.gmailWithEmptyPassword() };
        }

        public void ErrorScreenshot(string testName)
        {
            logger.LogError("{TestName} - Test failed", testName);
            Utils.Screenshoter.Capture(gmailSteps.driver, testScreenshotDirectory, $"{testName}_Fail");
        }
    }
}
