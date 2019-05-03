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
        const string space = " ";
        const string newLine = "\r\n";
        const string endSymbol = "\n";

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
        /// Method gets co+ntent of message.
        /// </summary>
        /// <returns>New userName</returns>
        public string GetNameFromLetter()
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.TextLocator)).Any());
            Name = Driver.FindElement(By.XPath(Locator.TextLocator));

            return CutWord(Name.Text);
        }

        public string CutWord(string word)
        {
            int[] positionOfSymbols = new int[] { word.IndexOf(space) < 0 ? word.Length + 1 : word.IndexOf(space), word.IndexOf(newLine) < 0 ? word.Length + 1 : word.IndexOf(newLine), word.Length };
            int length = word.Length;
            int pos = positionOfSymbols.Min();

            return word.Remove(positionOfSymbols.Min(), word.Length - positionOfSymbols.Min());
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
