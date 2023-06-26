using Microsoft.Extensions.Logging;
using MyFramework.Model;
using NUnit.Framework;

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

                string sentMessage = Utils.StringUtils.GetRandomString(20);

                protonSteps.Login(protonValidUser);
                protonSteps.SendMessage("AliceTestAcc4587@gmail.com", 
                    $"IsReceivedEmailCompareToSentTest {Utils.StringUtils.GetRandomString(5)}", sentMessage);

                gmailSteps.Login(gmailValidUser);
                gmailSteps.WaitForNewMessage();
                gmailSteps.OpenMessage(1);
                string receivedMessage = gmailSteps.GetCurrentMessageText();                

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
