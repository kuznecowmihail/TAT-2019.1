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
        IWebElement SelecterLetter { get; set; }
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
        public LettterRamblerPage SelectLetter(string sender)
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.SelectLetterLocator)).Any());
            var unseenLetters = Driver.FindElements(By.XPath(Locator.SelectLetterLocator)).ToList();

            foreach(var letter in unseenLetters)
            {
                if(letter.GetAttribute("title").Contains(sender))
                {
                    SelecterLetter = letter;
                    break;
                }
            }
            SelecterLetter.Click();

            return new LettterRamblerPage(Driver);
        }
    }
}
