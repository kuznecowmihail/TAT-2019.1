using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Task_DEV_9
{
    /// <summary>
    /// Class login to mail account.
    /// </summary>
    public class LoginMailPage
    {
        IWebDriver Driver { get; }
        WebDriverWait Wait { get; }
        IWebElement Login { get; set; }
        IWebElement Password { get; set; }
        IWebElement CheckBox { get; set; }
        IWebElement LoginButton { get; set; }
        MailLocators.LoginPageLocator Locator { get; }

        /// <summary>
        /// Constructor of LoginMailPage.
        /// </summary>
        /// <param name="driver"></param>
        public LoginMailPage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1));
            this.Locator = new MailLocators.LoginPageLocator();
        }

        /// <summary>
        /// Method goes to start page of mail.
        /// </summary>
        public void GoToPage()
        {
            Driver.Navigate().GoToUrl(Locator.PageLocator);
        }

        /// <summary>
        /// Method logins to mail account.
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public MainMailPage LoginToMail(string login, string password)
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.LoginLocator)).Any());
            Login = Driver.FindElement(By.XPath(Locator.LoginLocator));
            Password = Driver.FindElement(By.XPath(Locator.PasswordLocator));
            Login.SendKeys(login);
            Password.SendKeys(password);
            CheckBox = Driver.FindElement(By.XPath(Locator.CheckBoxLocator));
            CheckBox.Click();
            LoginButton = Driver.FindElement(By.XPath(Locator.LoginButtonLocator));
            LoginButton.Click();

            return new MainMailPage(Driver);
        }
    }
}
