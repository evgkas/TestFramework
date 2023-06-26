using OpenQA.Selenium;

namespace MyFramework.Steps
{
    public abstract class StepsAbstraction
    {
        private protected IWebDriver driver;

        public StepsAbstraction(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
