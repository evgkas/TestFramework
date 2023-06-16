using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MyFramework.Pages.Gmail
{
    public class GmailLoginPage //: PageAbstraction
    {        
        private WebDriverWait wait;
        private IWebDriver driver;

        private By emailField = By.CssSelector("input[type='email']");
        private By passwordField = By.CssSelector("input[type='password']");
        private By nextButton = By.CssSelector("div[id='identifierNext']");
        private By signInButton = By.CssSelector("div[id='passwordNext']");
        private By errorElement = By.Id("yDmH0d");

        public GmailLoginPage(IWebDriver driver)  
        {
            this.driver = driver;            
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

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
