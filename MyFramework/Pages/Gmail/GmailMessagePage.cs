using OpenQA.Selenium;

namespace MyFramework.Pages.Gmail
{
    public class GmailMessagePage : GmailMainPage    //this page contains some elements (like menu) from main page 
    {
        private static By replyButton = By.XPath("//*[@class='ams bkH']");
        private static By messageContent = By.XPath("//*[@class='a3s aiL ']/div[1]");
        private static By textField = By.XPath("//*[@role='textbox']");    //input text
        private static By sendMessageButton = By.XPath("//*[@id=':fl']");

        public GmailMessagePage(IWebDriver driver) : base(driver) { }

        public string GetMessageText()
        {
            wait.Until(d => d.FindElement(messageContent).Displayed);            
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
