using OpenQA.Selenium;

namespace MyFramework.Pages.Gmail
{
    public class GmailMessagePage : GmailMainPage    //this page contains some elements (like menu) from main page 
    {
        private IWebDriver driver;
        private By replyButton = By.XPath("//*[@class='ams bkH']");
        private By messageContent = By.XPath("//*[@class='a3s aiL ']/div[1]");
        private By textField = By.XPath("//*[@role='textbox']");    //input text
        private By sendMessageButton = By.XPath("//*[@id=':fl']");

        public GmailMessagePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            //driver = Driver.DriverInstance.GetInstance();
        }

        public string GetMessageText()
        {
            wait.Until(d => d.FindElement(messageContent));
            return driver.FindElement(messageContent).Text;
        }

        public void ReplyToCurrentMessage(string replyText)
        {
            wait.Until(d => d.FindElement(replyButton).Displayed);
            driver.FindElement(replyButton).Click();

            wait.Until(d => d.FindElement(textField).Displayed);
            driver.FindElement(textField).SendKeys(replyText);
            driver.FindElement(sendMessageButton).Click();
            Thread.Sleep(1500);    //to be sure message has sent
        }
    }
}
