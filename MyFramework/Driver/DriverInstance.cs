using MyFramework.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace MyFramework.Driver
{
    public class DriverInstance
    {
        private static IWebDriver driver;

        private DriverInstance() { }

        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                driver = CreateDriver();
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(10));
            }

            return driver;
        }

        private static IWebDriver CreateDriver()
        {
            IWebDriver driver;
            switch (Configuration.Configuration.ReadBrowserTypeFromConfig())
            {
                case BrowserType.EDGE:
                    driver = new EdgeDriver();
                    break;
                case BrowserType.CHROME:
                    driver = new ChromeDriver();
                    break;
                default:
                    driver = new FirefoxDriver();
                    break;
            }

            return driver;
        }

        public static void CloseBrowser()
        {
            driver.Quit();
            driver = null;
        }
    }
}
