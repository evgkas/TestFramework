using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Steps
{
    public abstract class StepsAbstraction
    {
        private protected readonly IWebDriver driver;        

        public StepsAbstraction(IWebDriver driver)
        {
            this.driver = driver;            
        }
    }
}
