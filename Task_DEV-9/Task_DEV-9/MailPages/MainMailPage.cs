using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Task_DEV_9
{
    /// <summary>
    /// Class clicks to write letter button and opens letter.
    /// </summary>
    public class MainMailPage
    {
        IWebDriver Driver { get; }
        WebDriverWait Wait { get; }
        IWebElement LetterButton { get; set; }
        IWebElement SelecterLetter { get; set; }
        MailLocators.MainPageLocator Locator { get; }

        public MainMailPage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1));
            this.Locator = new MailLocators.MainPageLocator();
        }

        /// <summary>
        /// Method clicks to button.
        /// </summary>
        /// <returns></returns>
        public SenderLetterMailPage ClickToWriteLetter()
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.WriteButtonLocator)).Any());
            LetterButton = Driver.FindElement(By.XPath(Locator.WriteButtonLocator));
            LetterButton.Click();

            return new SenderLetterMailPage(Driver);
        }

        /// <summary>
        /// Method opens letter.
        /// </summary>
        /// <param name="senderName"></param>
        /// <returns></returns>
        public LetterMailPage SelectUnseenLetter(string senderName)
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.SelecterUnreadLetterLocator)).Any());
            SelecterLetter = Driver.FindElement(By.XPath(Locator.SelecterUnreadLetterLocator));
            SelecterLetter.Click();

            return new LetterMailPage(Driver);
        }
    }
}
