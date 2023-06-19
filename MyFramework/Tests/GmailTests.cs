using Microsoft.Extensions.Logging;
using MyFramework.Model;
using NUnit.Framework;
using System;

namespace MyFramework.Tests
{
    [TestFixture]
    public class GmailTests : BaseTest
    {
        [TestCaseSource(nameof(GmailInvalidUsers))]
        public void LoginInvalidUsers_IsInvalidCredentialErrorDisplayedTrue(User user)
        {
            try
            {
                logger.LogInformation("{TestName} started", nameof(LoginInvalidUsers_IsInvalidCredentialErrorDisplayedTrue));
                gmailSteps.Login(user);
                Assert.True(gmailSteps.IsLoginErrorDispalayed());
            }
            catch (Exception)
            {
                ErrorScreenshot("GmailInvalidUsers");
                throw;
            }
        }

        [Test]
        public void CorrectUserData_IsLoggedInTrue()
        {
            try
            {
                logger.LogInformation("{TestName} started", nameof(CorrectUserData_IsLoggedInTrue));
                gmailSteps.Login(gmailValidUser);
                Assert.True(gmailSteps.IsLoggedIn());
            }
            catch (Exception)
            {
                ErrorScreenshot("CorrectUserData_IsLoggedInTrue");
                throw;
            }
        }

        [Test]
        public void IsReceivedEmailCompareToSent()
        {
            try
            {
                logger.LogInformation("{TestName} started", nameof(IsReceivedEmailCompareToSent));
                // Arrange
                string sentMessage = Utils.StringUtils.GetRandomString(20);

                // Act
                protonSteps.Login(protonValidUser);
                protonSteps.SendMessage("AliceTestAcc4587@gmail.com", "IsReceivedEmailCompareToSentTest", sentMessage);
                Thread.Sleep(30000); // time for receive mesage

                gmailSteps.Login(gmailValidUser);
                gmailSteps.Refresh();
                gmailSteps.OpenMessage(1);
                string receivedMessage = gmailSteps.GetCurrentMessageText();

                // Assert
                Assert.AreEqual(sentMessage, receivedMessage);
            }
            catch (Exception)
            {
                ErrorScreenshot("IsReceivedEmailCompareToSent");
                throw;
            }
        }
    }
}
