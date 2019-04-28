using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Task_DEV_9;

namespace EMailTest
{
    [TestFixture]
    public class StartMailTest
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void GoToMail()
        {
            LoginMailPage loginMailPage = new LoginMailPage(driver);
            loginMailPage.GoToLoginPage();
            var title = driver.Title;
            Assert.IsTrue(title == "Mail.ru: почта, поиск в интернете, новости, игры");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
