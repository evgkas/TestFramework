using OpenQA.Selenium;

namespace MyFramework.Pages
{
    public class ProtonMainPage : PageAbstraction
    {
        private protected static By newMessageButton = By.XPath("//*[@data-testid='sidebar:compose']");
        private protected static By toField = By.XPath("//*[@placeholder='Email address']");
        private protected static By subjectField = By.XPath("//*[@placeholder='Subject']");
        private protected static By newEmailContentFrameLocator = By.XPath("//*[@title='Email composer']");
        private protected static By messageField = By.CssSelector("div[contenteditable='true']");
        private protected static By sendMessageButton = By.XPath("//*[@data-testid='composer:send-button']");
        private protected static By goToSettingOptionLocator = By.LinkText("Go to settings");
        private protected static By openSettingsMenuButton = By.XPath("//*[@title='Open settings menu']");

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
            Thread.Sleep(1500);    //message doesnt sends immediately. fast switching to another action may cancel sending
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
