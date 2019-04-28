using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Task_DEV_9
{
    /// <summary>
    /// Class send letter to other account.
    /// </summary>
    public class SenderLetterMailPage
    {
        IWebDriver Driver { get; }
        WebDriverWait Wait { get; }
        IWebElement Recepient { get; set; }
        IWebElement SentButton { get; set; }
        IWebElement Text { get; set; }
        MailLocators.WriterPageLocator Locator { get; }

        /// <summary>
        /// Constructor of SenderLetterMailPage.
        /// </summary>
        /// <param name="driver"></param>
        public SenderLetterMailPage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1));
            this.Locator = new MailLocators.WriterPageLocator();
        }

        /// <summary>
        /// Method write and send letter to other account.
        /// </summary>
        /// <param name="recepient"></param>
        /// <param name="content">Content of message</param>
        public void SendLetter(string recepient, string content)
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.RecepientLocator)).Any());
            Recepient = Driver.FindElement(By.XPath(Locator.RecepientLocator));
            Recepient.SendKeys(recepient);
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.SwitcherToFrameLocator)).Any());
            Driver.SwitchTo().Frame(Driver.FindElement(By.XPath(Locator.SwitcherToFrameLocator)));
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.TextLocator)).Any());
            Text = Driver.FindElement(By.XPath(Locator.TextLocator));
            Text.Clear();
            Text.SendKeys(content);
            Driver.SwitchTo().ParentFrame();
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.SendButtonLocator)).Any());
            SentButton = Driver.FindElement(By.XPath(Locator.SendButtonLocator));
            SentButton.Click();
            //Wait.Until(t => Driver.FindElements(By.XPath(Locator.LetterSentLocator)).Any());
        }
    }
}
