using OpenQA.Selenium;

namespace MyFramework.Pages.Proton
{
    public class ProtonMessagePage : ProtonMainPage
    {
        private readonly IWebDriver driver;

        //need to switch to emailContentFrame before work with message content (receivedEmailContent)
        private By receivedEmailContent = By.XPath("//*[@dir='ltr']");
        private By emailContentFrameLocator = By.XPath("//iframe[@title='Email content']");

        public ProtonMessagePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public string GetMessageText()
        {
            wait.Until(d => d.FindElement(emailContentFrameLocator));
            IWebElement emailContentFrame = driver.FindElement(emailContentFrameLocator);
            driver.SwitchTo().Frame(driver.FindElement(emailContentFrameLocator));

            wait.Until(d => d.FindElement(receivedEmailContent).Displayed);
            var messageElement = driver.FindElement(receivedEmailContent);
            string receivedText = messageElement.Text;

            driver.SwitchTo().DefaultContent();
            return receivedText;
        }

    }
}
