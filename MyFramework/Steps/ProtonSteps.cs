using MyFramework.Model;
using MyFramework.Pages;
using MyFramework.Pages.Proton;
using OpenQA.Selenium;

namespace MyFramework.Steps
{
    public class ProtonSteps
    {
        private readonly IWebDriver driver;
        private ProtonLoginPage loginPage;
        private ProtonMessagePage messagePage;
        private ProtonSettingsPage settingsPage;
        private ProtonMainPage mainPage;

        public ProtonSteps(IWebDriver driver)
        {
            this.driver = driver;          
            loginPage = new ProtonLoginPage(driver);
            messagePage = new ProtonMessagePage(driver);
            settingsPage = new ProtonSettingsPage(driver);
            mainPage = new ProtonMainPage(driver);
        }
      
        public void CloseBrowser()
        {
            Driver.DriverInstance.CloseBrowser();
        }

        public void Login(User user)
        {
            loginPage.ToMainPage();
            loginPage.EnterCredentials(user.GetUsername(), user.GetPassword());
        }

        public void SendMessage(string emailTo, string subject, string message)
        {
            mainPage.SendMessage(emailTo, subject, message);
        }

        public string GetCurrentMessageText()
        {
            return messagePage.GetMessageText();
        }

        public string GetCurrentName()
        {
            mainPage.GoToSetting();
            return settingsPage.GetCurrentName();
        }

        public void ChangeName(string newName)
        {
            mainPage.ToMainPage();
            mainPage.GoToSetting();
            settingsPage.ChangeName(newName);
        }
    }
}
