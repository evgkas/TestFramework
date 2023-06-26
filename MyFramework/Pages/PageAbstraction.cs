using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MyFramework.Pages
{
    public abstract class PageAbstraction
    {
        private protected IWebDriver driver;
        private protected WebDriverWait wait;

        public PageAbstraction(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
    }
}
