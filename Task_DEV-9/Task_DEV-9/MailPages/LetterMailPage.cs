using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Task_DEV_9
{
    /// <summary>
    /// Class get content of message and open settings..
    /// </summary>
    public class LetterMailPage
    {
        IWebDriver Driver { get; }
        WebDriverWait Wait { get; }
        IWebElement Name { get; set; }
        IWebElement Profile { get; set; }
        IWebElement Settings { get; set; }
        MailLocators.LetterPageLocator Locator { get; }

        /// <summary>
        /// Constructor of LetterMailPage.
        /// </summary>
        /// <param name="driver"></param>
        public LetterMailPage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1));
            this.Locator = new MailLocators.LetterPageLocator();
        }
        
        /// <summary>
        /// Method gets content of message.
        /// </summary>
        /// <returns>New userName</returns>
        public string GetNameFromLetter()
        {
            Wait.Until(t => Driver.FindElement(By.XPath(Locator.TextLocator)));
            Name = Driver.FindElement(By.XPath(Locator.TextLocator));

            return Name.Text.Remove(Name.Text.IndexOf("\r\n"), Name.Text.Length - Name.Text.IndexOf("\r\n")); ;
        }

        /// <summary>
        /// Method opens settings.
        /// </summary>
        /// <returns></returns>
        public SettingsMailPage GoToSetting()
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.ProfileLocator)).Any());
            Profile = Driver.FindElement(By.XPath(Locator.ProfileLocator));
            Profile.Click();
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.SettingsLocator)).Any());
            Settings = Driver.FindElement(By.XPath(Locator.SettingsLocator));
            Settings.Click();

            return new SettingsMailPage(Driver);
        }
    }
}
