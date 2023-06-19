using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;

namespace MyFramework.Tests
{
    [TestFixture]
    public class ProtonTests : BaseTest
    {
        [Test]
        public void IsNewNameCompareToSent()
        {
            try
            {
                logger.LogInformation("{TestName} started", nameof(IsNewNameCompareToSent));
                string sentName = "Bob";

                protonSteps.Login(protonValidUser);
                string actualName = protonSteps.GetCurrentName();

                Assert.AreEqual(sentName, actualName);
            }
            catch (Exception)
            {
                ErrorScreenshot("IsNewNameCompareToSent");
                throw;
            }
        }
    }
}
