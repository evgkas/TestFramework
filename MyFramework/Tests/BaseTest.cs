using Microsoft.Extensions.Logging;
using MyFramework.Model;
using MyFramework.Service;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MyFramework.Tests
{
    public abstract class BaseTest
    {
        private protected IWebDriver driver;
        private protected static Steps.GmailSteps gmailSteps;
        private protected static Steps.ProtonSteps protonSteps;
        private protected static User gmailValidUser;
        private protected static User protonValidUser;
        private protected static ILogger<BaseTest> logger;
        private string testScreenshotDirectory = "screenshots";

        [SetUp]
        public void SetUp()
        {
            driver = Driver.DriverInstance.GetInstance();
            gmailSteps = new Steps.GmailSteps(driver);
            protonSteps = new Steps.ProtonSteps(driver);

            gmailValidUser = UserCreator.withGmailCredentials();
            protonValidUser = UserCreator.withProtonCredentials();

            logger = Logger.GetLogger<BaseTest>();

            if (!Directory.Exists(testScreenshotDirectory))
            {
                Directory.CreateDirectory(testScreenshotDirectory);
            }
        }

        [TearDown]
        public void TearDown()
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
            Utils.Screenshoter.Capture(testScreenshotDirectory, $"{testName}_Fail");
        }
    }
}
