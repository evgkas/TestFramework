using OpenQA.Selenium;

namespace MyFramework.Pages.Proton
{
    public class ProtonSettingsPage : PageAbstraction
    {
        private By accountAndPasswordButtonLocator = By.XPath("//*[@title='Account and password']");
        private By accountNameLocator = By.XPath("//*[@class='text-ellipsis user-select mr-2']");
        private By editNameLocator = By.XPath("//*[@aria-label='Edit display name']");
        private By newNameFieldLocator = By.Id("displayName");
        private By submitButtonLocator = By.XPath("//*[@type='submit']");

        public ProtonSettingsPage(IWebDriver driver) : base(driver) { }

        public void GoToAccountAndPassword()
        {
            wait.Until(d => d.FindElement(accountAndPasswordButtonLocator).Displayed);
            driver.FindElement(accountAndPasswordButtonLocator).Click();
        }

        public void ChangeName(string newName)
        {
            GoToAccountAndPassword();

            wait.Until(d => d.FindElement(editNameLocator).Displayed);
            driver.FindElement(editNameLocator).Click();

            wait.Until(d => d.FindElement(newNameFieldLocator).Displayed);
            driver.FindElement(newNameFieldLocator).SendKeys(newName);

            driver.FindElement(submitButtonLocator).Click();
            Thread.Sleep(1500);    //to changes be confirmed
        }

        public string GetCurrentName()
        {
            GoToAccountAndPassword();
            wait.Until(d => d.FindElement(accountNameLocator));
            return driver.FindElement(accountNameLocator).Text;
        }

    }
}
