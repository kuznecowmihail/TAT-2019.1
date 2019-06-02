using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Task_DEV_9
{
    /// <summary>
    /// Class open letter.
    /// </summary>
    public class MainRamblerPage
    {
        IWebDriver Driver { get; }
        WebDriverWait Wait { get; }
        IWebElement SelecterUnreadLetter { get; set; }
        RamblerLocators.MainRamblerLocator Locator { get; }

        /// <summary>
        /// Constructor of MainRamblerPage.
        /// </summary>
        /// <param name="driver"></param>
        public MainRamblerPage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1));
            this.Locator = new RamblerLocators.MainRamblerLocator();
        }

        /// <summary>
        /// Method opens letter.
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public LettterRamblerPage SelectUnreadLetter(string sender)
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.GetUnreadLetterLocator(sender))).Any());
            SelecterUnreadLetter = Driver.FindElement(By.XPath(Locator.GetUnreadLetterLocator(sender)));
            SelecterUnreadLetter.Click();

            return new LettterRamblerPage(Driver);
        }

        /// <summary>
        /// Method gets number of unread letters of sender.
        /// </summary>
        /// <param name="sender"></param>
        /// <returns>Count of letters</returns>
        public int GetCountUnreadSenderLetter(string sender)
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.GetUnreadLetterLocator(sender))).Any());
            var unreadLetters = Driver.FindElements(By.XPath(Locator.GetUnreadLetterLocator(sender))).ToList();

            return unreadLetters.Count;
        }
    }
}
