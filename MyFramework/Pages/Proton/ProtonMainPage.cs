using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MyFramework.Pages
{
    public class ProtonMainPage : PageAbstraction
    {
        internal By newMessageButton = By.XPath("//*[@data-testid='sidebar:compose']");
        internal By toField = By.XPath("//*[@placeholder='Email address']");
        internal By subjectField = By.XPath("//*[@placeholder='Subject']");
        internal By newEmailContentFrameLocator = By.XPath("//*[@title='Email composer']");
        internal By messageField = By.CssSelector("div[contenteditable='true']");
        internal By sendMessageButton = By.XPath("//*[@data-testid='composer:send-button']");
        private By goToSettingOptionLocator = By.LinkText("Go to settings");
        internal By openSettingsMenuButton = By.XPath("//*[@title='Open settings menu']");

        public ProtonMainPage(IWebDriver driver) : base(driver) { }

        public void ToMainPage()
        {
            driver.Navigate().GoToUrl("https://mail.proton.me");
        }

        public void CreateNewMessage()
        {
            wait.Until(d => d.FindElement(newMessageButton).Displayed);
            driver.FindElement(newMessageButton).Click();
        }

        public void SendMessage(string emailTo, string subject, string message)
        {
            CreateNewMessage();

            wait.Until(d => d.FindElement(toField).Displayed);
            driver.FindElement(toField).SendKeys(emailTo);
            driver.FindElement(subjectField).SendKeys(subject);

            IWebElement newEmailContentFrame = driver.FindElement(newEmailContentFrameLocator);
            driver.SwitchTo().Frame(newEmailContentFrame);
            driver.FindElement(messageField).Clear();
            driver.FindElement(messageField).SendKeys(message);
            driver.SwitchTo().DefaultContent();

            driver.FindElement(sendMessageButton).Click();
            Thread.Sleep(1500);    //message doesnt sends immediately. fast switching to another action may cansel sending
        }

        public void OpenMessage(string messageSubject)
        {
            By emailLocator = By.XPath($"//*[@title='{messageSubject}']");
            wait.Until(d => d.FindElement(emailLocator).Displayed);
            driver.FindElement(emailLocator).Click();
        }

        public void GoToSetting()
        {
            wait.Until(d => d.FindElement(openSettingsMenuButton));
            driver.FindElement(openSettingsMenuButton).Click();

            wait.Until(d => d.FindElement(goToSettingOptionLocator).Displayed);
            driver.FindElement(goToSettingOptionLocator).Click();
        }
    }
}
