using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Task_DEV_9Test
{
    [TestFixture]
    public class LoginMailTest : BaseTest
    {
        const string trueValue = "//div[@class = 'mailbox__row mailbox__row_extended i-clearfix']";
        const string falseValue = "//div[@class = 'mailbox__row mailbox__row_extended i-clearfix is-error']";

        [Test, Timeout(10000)]
        [TestCase("2209username1998@mail.ru", "2_password_2")]
        [TestCase("2209username1998", "2_password_2")]
        public void LoginToMailTest(string login, string password)
        {
            LoginToMail(login, password);
            var log = driver.FindElements(By.XPath(trueValue));
            Assert.IsTrue(log.Count == 1);
        }

        [Test, Timeout(10000)]
        [TestCase("2209username1997@mail.ru", "2_password_2")]
        [TestCase("2209username1998@mail.ru", "1_password_2")]
        [TestCase("1209username1998@mail.ru", "2_password_1")]
        public void IncorrectLoginToMailTest(string login, string password)
        {
            LoginToMail(login, password);
            wait.Until(t => driver.FindElements(By.XPath(falseValue)).Any());
            var log = driver.FindElements(By.XPath(falseValue));
            Assert.IsTrue(log.Count == 1);
        }

        [Test, Timeout(10000)]
        [TestCase("", "2_password_2")]
        [TestCase("2209username1998@mail.ru", "")]
        [TestCase("", "")]
        public void EmptyLoginToMailTest(string login, string password)
        {
            LoginToMail(login, password);
            wait.Until(t => driver.FindElements(By.XPath(falseValue)).Any());
            var log = driver.FindElements(By.XPath(falseValue));
            Assert.IsTrue(log.Count == 1);
        }
    }
}
