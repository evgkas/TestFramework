using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Pages
{
    public abstract class PageAbstraction
    {
        internal protected IWebDriver driver;
        internal protected WebDriverWait wait;

        public PageAbstraction(IWebDriver driver) 
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
    }
}
