using Microsoft.Extensions.Logging;
using MyFramework.Model;


namespace MyFramework.Tests
{
    public class GmailTests : BaseTest
    {

        [Theory]
        [MemberData(nameof(GmailInvalidUsers))]
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

        [Fact]
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

        [Fact]
        public void IsReceivedEmailCompareToSent()
        {
            try
            {
                logger.LogInformation("{TestName} started", nameof(IsReceivedEmailCompareToSent));
                //Arrange
                string sentMessage = Utils.StringUtils.GetRandomString(20);

                //Act
                protonSteps.Login(protonValidUser);
                protonSteps.SendMessage("AliceTestAcc4587@gmail.com", "IsReceivedEmailCompareToSentTest", sentMessage);
                Thread.Sleep(30000);    //time to receive message change

                gmailSteps.Login(gmailValidUser);
                gmailSteps.Refresh();
                gmailSteps.OpenMessage(1);
                string receivedMessage = gmailSteps.GetCurrentMessageText();

                //Assert
                Assert.Equal(sentMessage, receivedMessage);                
            }

            catch (Exception)
            {
                ErrorScreenshot("IsReceivedEmailCompareToSent");
                throw;
            }
        }
    }
}