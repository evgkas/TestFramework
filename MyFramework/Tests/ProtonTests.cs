using Microsoft.Extensions.Logging;

namespace MyFramework.Tests
{
    public class ProtonTests : BaseTest
    {
        [Fact]
        public void IsNewNameCompareToSent()
        {
            try
            {
                logger.LogInformation("{TestName} started", nameof(IsNewNameCompareToSent));
                string sentName = "Bob";

                protonSteps.Login(protonValidUser);
                string actualName = protonSteps.GetCurrentName();

                Assert.Equal(sentName, actualName);                
            }
            catch (Exception)
            {
                ErrorScreenshot("IsNewNameCompareToSent");
                throw;
            }
        }
    }
}
