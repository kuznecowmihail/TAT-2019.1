using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Task_DEV_9;

namespace Task_DEV_9Test
{
    [TestFixture]
    public abstract class BaseTest
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
        }

        public MainMailPage LoginToMail(string login, string password)
        {
            LoginMailPage loginMailPage = new LoginMailPage(driver);
            loginMailPage.GoToPage();
            loginMailPage.LoginToMail(login, password);

            return new MainMailPage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
