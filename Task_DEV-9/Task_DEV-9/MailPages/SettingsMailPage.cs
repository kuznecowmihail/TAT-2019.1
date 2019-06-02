using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Task_DEV_9
{
    /// <summary>
    /// Class changes name of account to new name.
    /// </summary>
    public class SettingsMailPage
    {
        IWebDriver Driver { get; }
        WebDriverWait Wait { get; }
        IWebElement UserName { get; set; }
        IWebElement SaveButton { get; set; }
        MailLocators.SettingsPageLocator Locator { get; }

        /// <summary>
        /// Constructor of SettingPage.
        /// </summary>
        /// <param name="driver"></param>
        public SettingsMailPage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1));
            this.Locator = new MailLocators.SettingsPageLocator();
        }

        /// <summary>
        /// Method changes name of account.
        /// </summary>
        /// <param name="newUserName"></param>
        public void ChangeUserName(string newUserName)
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.UserNameLocator)).Any());
            UserName = Driver.FindElement(By.XPath(Locator.UserNameLocator));
            UserName.Clear();
            UserName.SendKeys(newUserName);
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.SaveButtonlocator)).Any());
            SaveButton = Driver.FindElement(By.XPath(Locator.SaveButtonlocator));
            SaveButton.Click();
        }
    }
}
