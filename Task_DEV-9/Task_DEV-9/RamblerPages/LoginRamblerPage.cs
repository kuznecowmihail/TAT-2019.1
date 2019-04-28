using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Task_DEV_9
{
    /// <summary>
    /// Class login to rambler account.
    /// </summary>
    public class LoginRamblerPage
    {
        IWebDriver Driver { get; }
        WebDriverWait Wait { get; }
        IWebElement Login { get; set; }
        IWebElement Password { get; set; }
        IWebElement CheckBox { get; set; }
        IWebElement LoginButton { get; set; }
        RamblerLocators.LoginPageLocator Locator { get; }

        /// <summary>
        /// Constructor of LoginRamblerPage.
        /// </summary>
        /// <param name="driver"></param>
        public LoginRamblerPage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1));
            this.Locator = new RamblerLocators.LoginPageLocator();
        }

        /// <summary>
        /// Method goes to start page.
        /// </summary>
        public void GoToLoginPage()
        {
            Driver.Navigate().GoToUrl(Locator.PageLocator);
        }

        /// <summary>
        /// Method logins to rambler account.
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public MainRamblerPage LoginIntoMail(string login, string password)
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.SwitcherToFrameLocator)).Any());
            Driver.SwitchTo().Frame(Driver.FindElement(By.XPath(Locator.SwitcherToFrameLocator)));
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.LoginLocator)).Any());
            Login = Driver.FindElement(By.XPath(Locator.LoginLocator));
            Password = Driver.FindElement(By.XPath(Locator.PasswordLocator));
            Login.SendKeys(login);
            Password.SendKeys(password);
            CheckBox = Driver.FindElement(By.XPath(Locator.CheckBoxlocator));
            CheckBox.Click();
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.LoginButtonLocator)).Any());
            LoginButton = Driver.FindElement(By.XPath(Locator.LoginButtonLocator));
            LoginButton.Click();

            return new MainRamblerPage(Driver);
        }
    }
}
