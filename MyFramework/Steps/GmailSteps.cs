using MyFramework.Model;
using MyFramework.Pages.Gmail;
using OpenQA.Selenium;

namespace MyFramework.Steps
{
    public class GmailSteps
    {
        private readonly IWebDriver driver;
        private GmailMainPage mainPage;
        private GmailLoginPage loginPage;
        private GmailMessagePage messagePage;

        public GmailSteps(IWebDriver driver)
        {
            this.driver = driver;            
            mainPage = new GmailMainPage(driver);
            loginPage = new GmailLoginPage(driver);
            messagePage = new GmailMessagePage(driver);
        }

        public void CloseBrowser()
        {
            Driver.DriverInstance.CloseBrowser();
        }

        public void Login(User user)
        {
            loginPage.ToMainPage();
            loginPage.EnterEmail(user.GetUsername());
            loginPage.EnterPassword(user.GetPassword());
            try
            {
                loginPage.EnterPassword(user.GetPassword());
            }
            catch (StaleElementReferenceException) { }
        }

        public bool IsLoginErrorDispalayed()
        {
            return loginPage.IsInvalidCredentialsErrorDisplayed();
        }

        public bool IsLoggedIn()
        {
            return loginPage.IsLoggedIn();
        }

        public void OpenMessage(int messageNumber)
        {
            mainPage.OpenMessage(messageNumber);
        }

        public string GetCurrentMessageText()
        {
            return messagePage.GetMessageText();
        }

        public void Refresh()
        {
            driver.Navigate().Refresh();
        }
    }
}
