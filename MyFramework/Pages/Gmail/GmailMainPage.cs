using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MyFramework.Pages.Gmail
{
    public class GmailMainPage : PageAbstraction
    {
        private By emailList = By.CssSelector("tr.zA");
        private By unreadMessagesLocator = By.CssSelector("span.bqe");

        public GmailMainPage(IWebDriver driver) : base(driver) { }

        public bool IsLoggedIn()
        {
            try
            {
                return driver.Url.Contains("https://mail.google.com/mail/");
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public void OpenMessage(int messageNumber)
        {
            wait.Until(d => d.FindElement(emailList).Displayed);
            var emails = driver.FindElements(emailList);

            if (messageNumber >= 1 && messageNumber <= emails.Count)
            {
                var emailToOpen = emails[messageNumber - 1];
                emailToOpen.Click();
            }
            else
            {
                Console.WriteLine("Wrong messageNumber");
            }
        }

        public string GetSenderOfUnreadMessage(int messageNumber)   //return null if message not find
        {
            //check sender from main page / not open message
            string? senderEmail = null;
            try
            {
                wait.Until(d => d.FindElement(unreadMessagesLocator));
                var unreadMessages = driver.FindElements(unreadMessagesLocator);

                if (unreadMessages != null)
                {
                    var currentMessage = unreadMessages[messageNumber - 1];

                    //moving on html tree to find element contains senderEmail
                    var parentElement = currentMessage.FindElement(By.XPath(".."));
                    var senderElement = parentElement.FindElement(By.CssSelector("span.zF"));

                    senderEmail = senderElement.GetAttribute("email");
                    return senderEmail;
                }
            }
            catch (WebDriverTimeoutException) { }
            return senderEmail;
        }

        public bool IsThereUnreadMessage()
        {
            try
            {
                wait.Until(d => d.FindElement(unreadMessagesLocator));
                return true;
            }
            catch (WebDriverTimeoutException) 
            {
                return false;
            }
        }       
    }
}
