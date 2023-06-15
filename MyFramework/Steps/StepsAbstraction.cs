using OpenQA.Selenium;

namespace MyFramework.Steps
{
    public abstract class StepsAbstraction
    {
        internal IWebDriver driver;

        public void InitBrowser()
        {
            driver = Driver.DriverInstance.GetInstance();
        }

        public void CloseBrowser()
        {
            Driver.DriverInstance.CloseBrowser();
        }
    }
}
