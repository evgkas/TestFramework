using OpenQA.Selenium;

namespace MyFramework.Pages.Gmail
{
    public class GmailLoginPage : PageAbstraction
    {
        private static By emailField = By.CssSelector("input[type='email']");
        private static By passwordField = By.CssSelector("input[type='password']");
        private static By nextButton = By.CssSelector("div[id='identifierNext']");
        private static By signInButton = By.CssSelector("div[id='passwordNext']");
        private static By errorElement = By.Id("yDmH0d");

        public GmailLoginPage(IWebDriver driver) : base(driver) { }

        public void ToMainPage()
        {
            driver.Navigate().GoToUrl("https://www.gmail.com");
        }

        public void EnterEmail(string email)
        {
            wait.Until(d => d.FindElement(emailField));
            driver.FindElement(emailField).SendKeys(email);
            driver.FindElement(nextButton).Click();
        }

        public void EnterPassword(string password)
        {
            try
            {
                wait.Until(d => d.FindElement(passwordField).Displayed);
                driver.FindElement(passwordField).SendKeys(password);
                driver.FindElement(signInButton).Click();
            }
            catch (WebDriverTimeoutException) { }
        }

        public bool IsLoggedIn()
        {
            try
            {
                wait.Until(d => d.Url.Contains("https://mail.google.com/mail/"));
            }
            catch (WebDriverTimeoutException) { }

            return driver.Url.Contains("https://mail.google.com/mail/");
        }

        public bool IsInvalidCredentialsErrorDisplayed()
        {
            try
            {
                return driver.FindElement(errorElement).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
