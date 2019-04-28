using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Task_DEV_9;

namespace Task_DEV_9Test
{
    [TestFixture]
    public class LoginMailTest
    {
        IWebDriver driver;
        WebDriverWait wait;
        const string trueValue = "mailbox__row mailbox__row_extended i-clearfix";
        const string falseValue = "mailbox__row mailbox__row_extended i-clearfix is-error";

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(100));
        }

        [Test, Timeout(10000)]
        [TestCase("2209username1998@mail.ru", "2_password_2")]
        [TestCase("2209username1998", "2_password_2")]
        public void LoginToMail(string login, string password)
        {
            LoginMailPage loginMailPage = new LoginMailPage(driver);
            loginMailPage.GoToPage();
            loginMailPage.LoginToMail(login, password);
            var log = driver.FindElements(By.XPath($"//div[@class = '{trueValue}']"));
            Assert.IsTrue(log.Count == 1);
        }

        [Test, Timeout(10000)]
        [TestCase("2209username1997@mail.ru", "2_password_2")]
        [TestCase("2209username1998@mail.ru", "1_password_2")]
        [TestCase("1209username1998@mail.ru", "2_password_1")]
        public void IncorrectLoginToMail(string login, string password)
        {
            LoginMailPage loginMailPage = new LoginMailPage(driver);
            loginMailPage.GoToPage();
            loginMailPage.LoginToMail(login, password);
            wait.Until(t => driver.FindElements(By.XPath($"//div[@class = '{falseValue}']")).Any());
            var log = driver.FindElements(By.XPath($"//div[@class = '{falseValue}']"));
            Assert.IsTrue(log.Count == 1);
        }

        [Test, Timeout(10000)]
        [TestCase("", "2_password_2")]
        [TestCase("2209username1997@mail.ru", "")]
        [TestCase("", "")]
        public void EmptyLoginToMail(string login, string password)
        {
            LoginMailPage loginMailPage = new LoginMailPage(driver);
            loginMailPage.GoToPage();
            loginMailPage.LoginToMail(login, password);
            wait.Until(t => driver.FindElements(By.XPath($"//div[@class = '{falseValue}']")).Any());
            var log = driver.FindElements(By.XPath($"//div[@class = '{falseValue}']"));
            Assert.IsTrue(log.Count == 1);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
