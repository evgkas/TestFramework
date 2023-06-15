using MyFramework.Model;
using MyFramework.Pages.Gmail;
using OpenQA.Selenium;

namespace MyFramework.Steps
{
    public class GmailSteps : StepsAbstraction
    {
        private GmailMainPage mainPage;
        private GmailLoginPage loginPage;
        private GmailMessagePage messagePage;

        public GmailSteps()
        {
            InitBrowser();
            mainPage = new(driver);
            loginPage = new(driver);
            messagePage = new(driver);
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
