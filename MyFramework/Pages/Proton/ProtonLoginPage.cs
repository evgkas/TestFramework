using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MyFramework.Pages.Proton
{
    public class ProtonLoginPage : PageAbstraction
    {
        private By emailField = By.CssSelector("#username");
        private By passwordField = By.CssSelector("#password");
        private By submitButton = By.XPath("//*[@type='submit']");

        public ProtonLoginPage(IWebDriver driver) : base(driver) { }

        public void ToMainPage()
        {
            driver.Navigate().GoToUrl("https://mail.proton.me");
        }

        public void EnterCredentials(string email, string password)
        {
            wait.Until(d => d.FindElement(emailField).Displayed);
            driver.FindElement(emailField).SendKeys(email);
            driver.FindElement(passwordField).SendKeys(password);
            driver.FindElement(submitButton).Click();
        }

        public bool IsLoggedIn()
        {
            try
            {
                wait.Until(d => d.Url.Contains("https://mail.proton.me/u"));
            }
            catch (WebDriverTimeoutException) { }

            return driver.Url.Contains("https://mail.proton.me/u");
        }
    }
}
