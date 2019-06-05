using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Task9
{
    /// <summary>
    /// The class of page object pattern.
    /// </summary>
    public class MainPage
    {
        IWebDriver WebDriver { get; }
        WebDriverWait WebDriverWait { get; }
        List<IWebElement> Names { get; }
        List<IWebElement> Values { get; }
        string web = "https://myfin.by/currency/minsk";
        string xPath = "//div[@class = 'bank-info-head content_i calc_color']";
        string xPathName = "//div[@class = 'table-responsive']//tr/td/a";
        string xPathValue = "//div[@class = 'table-responsive']//tr/td[2]";

        /// <summary>
        /// Constructor of MainPage.
        /// </summary>
        /// <param name="webDriver"></param>
        public MainPage(IWebDriver webDriver)
        {
            this.WebDriver = webDriver;
            this.WebDriverWait = new WebDriverWait(WebDriver, TimeSpan.FromMinutes(1));
            GoToPage();
            this.Names = WebDriver.FindElements(By.XPath(xPathName)).ToList();
            this.Values = WebDriver.FindElements(By.XPath(xPathValue)).ToList();
        }

        /// <summary>
        /// The method goes to website.
        /// </summary>
        public void GoToPage()
        {
            WebDriver.Navigate().GoToUrl(web);
        }

        /// <summary>
        /// Method returns list of currencies.
        /// </summary>
        /// <returns>list of currencies</returns>
        public List<Currency> GetCurrency()
        {
            WebDriverWait.Until(t => WebDriver.FindElements(By.XPath(xPath)).Any());
            List<Currency> currencies = new List<Currency>();

            for (int i = 0; i < Names.Count; i++)
            {
                currencies.Add(new Currency(Names[i].Text, Values[i].Text));
            }
            WebDriver.Quit();

            return currencies;
        }
    }
}
