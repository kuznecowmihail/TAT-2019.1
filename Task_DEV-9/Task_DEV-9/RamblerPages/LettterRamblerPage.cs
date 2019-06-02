using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Task_DEV_9
{
    /// <summary>
    /// Class read letter and reply.
    /// </summary>
    public class LettterRamblerPage
    {
        IWebDriver Driver { get; }
        WebDriverWait Wait { get; }
        IWebElement Text { get; set; }
        IWebElement SenderLetter { get; set; }
        RamblerLocators.LetterPageLocator Locator { get; }

        /// <summary>
        /// Constructor of LetterRamblerPage.
        /// </summary>
        /// <param name="driver"></param>
        public LettterRamblerPage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1));
            this.Locator = new RamblerLocators.LetterPageLocator();
        }

        /// <summary>
        /// Method replyes on message.
        /// </summary>
        /// <param name="content"></param>
        public void ReplyOnLetter(string content)
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.TextLocator)).Any());
            Text = Driver.FindElement(By.XPath(Locator.TextLocator));
            Text.Clear();
            Text.SendKeys(content);
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.SendButtonLocator)).Any());
            SenderLetter = Driver.FindElement(By.XPath(Locator.SendButtonLocator));
            SenderLetter.Click();
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.LetterSentLocator)));
        }
    }
}
