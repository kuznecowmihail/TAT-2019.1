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
        public void BeforeTest()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
        }

        public MainMailPage LoginToMail(string login, string password)
        {
            LoginMailPage loginMailPage = new LoginMailPage(driver);
            loginMailPage.GoToPage();
            
            return loginMailPage.LoginToMail(login, password); ;
        }

        public MainRamblerPage LoginToRambler(string login, string password)
        {
            LoginRamblerPage loginRamblerPage = new LoginRamblerPage(driver);
            loginRamblerPage.GoToLoginPage();

            return loginRamblerPage.LoginIntoRambler(login, password);
        }

        [TearDown]
        public void AfterTest()
        {
            driver.Quit();
        }
    }
}
