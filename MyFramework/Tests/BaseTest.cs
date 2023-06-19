using Microsoft.Extensions.Logging;
using MyFramework.Model;
using MyFramework.Service;
using NLog.Extensions.Logging;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;

namespace MyFramework.Tests
{
    public abstract class BaseTest
    {
        private protected IWebDriver driver;
        internal static Steps.GmailSteps gmailSteps;
        internal static Steps.ProtonSteps protonSteps;
        internal User gmailValidUser;
        internal User protonValidUser;
        protected static ILogger<BaseTest> logger;
        private string testScreenshotDirectory = "screenshots";

        [SetUp]
        public void BaseSetUp()
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
        public void BaseTearDown()
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
