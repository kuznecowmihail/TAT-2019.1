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
    public class TransportLetterTest
    {
        IWebDriver driver;
        WebDriverWait wait;
        const string sentLetterlocator = "//div[@class = 'message-sent__title']";
        const string unseenLettersLocator = "//div[@class = 'AutoMaillistItem-root-1n AutoMaillistItem-unseen-ad']//a//span[@class = 'AutoMaillistItem-sender-1V']";
        const string textLocator = "//div[text() = '";

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
        }

        [TestCase("2209username1998@mail.ru", "2_password_2", "2909username1998@rambler.ru", "I ready to change my name!!")]
        public void SendLetterFromMail(string login, string password, string recipient, string content)
        {
            LoginMailPage loginMailPage = new LoginMailPage(driver);
            loginMailPage.GoToPage();
            var mainMailPage = loginMailPage.LoginToMail(login, password);
            var writerLetterMailPage = mainMailPage.ClickToWriteLetter();
            writerLetterMailPage.SendLetter(recipient, content);
            wait.Until(t => driver.FindElements(By.XPath(sentLetterlocator)).Any());
            var sentLetter = driver.FindElements(By.XPath(sentLetterlocator));
            Assert.IsTrue(sentLetter.Count == 1);
        }

        [TestCase("2209username1998@mail.ru", "2_password_2", "I ready to change name!!", "2909username1998@rambler.ru", "1_Password_1")]
        public void SendAndRecieveLetter(string mailLogin, string mailPassword, string content, string ramblerLogin, string ramblerPassword)
        {
            int countLetter = 0;
            LoginMailPage loginMailPage = new LoginMailPage(driver);
            loginMailPage.GoToPage();
            var mainMailPage = loginMailPage.LoginToMail(mailLogin, mailPassword);
            var writerLetterMailPage = mainMailPage.ClickToWriteLetter();
            writerLetterMailPage.SendLetter(ramblerLogin, content);
            wait.Until(t => driver.FindElements(By.XPath(sentLetterlocator)).Any());
            var sentLetter = driver.FindElements(By.XPath(sentLetterlocator));
            LoginRamblerPage loginRamblerPage = new LoginRamblerPage(driver);
            loginRamblerPage.GoToLoginPage();
            var mainRamblerPage = loginRamblerPage.LoginIntoMail(ramblerLogin, ramblerPassword);
            wait.Until(t => driver.FindElements(By.XPath(unseenLettersLocator)).Any());
            var unseenLetters = driver.FindElements(By.XPath(unseenLettersLocator)).ToList();

            foreach(var letter in unseenLetters)
            {
                if(letter.GetAttribute("title").Contains(mailLogin))
                {
                    countLetter++;
                }
            }
            Assert.IsTrue(countLetter > 0);
        }

        [TestCase("2209username1998@mail.ru", "2_password_2", "I ready to change name!!", "2909username1998@rambler.ru", "1_Password_1")]
        public void SendAndReadLetter(string mailLogin, string mailPassword, string actualContent, string ramblerLogin, string ramblerPassword)
        {
            LoginMailPage loginMailPage = new LoginMailPage(driver);
            loginMailPage.GoToPage();
            var mainMailPage = loginMailPage.LoginToMail(mailLogin, mailPassword);
            var writerLetterMailPage = mainMailPage.ClickToWriteLetter();
            writerLetterMailPage.SendLetter(ramblerLogin, actualContent);
            wait.Until(t => driver.FindElements(By.XPath(sentLetterlocator)).Any());
            var sentLetter = driver.FindElements(By.XPath(sentLetterlocator));
            LoginRamblerPage loginRamblerPage = new LoginRamblerPage(driver);
            loginRamblerPage.GoToLoginPage();
            var mainRamblerPage = loginRamblerPage.LoginIntoMail(ramblerLogin, ramblerPassword);
            var selectLetter = mainRamblerPage.SelectLetter(mailLogin);
            wait.Until(t => driver.FindElements(By.XPath($"{textLocator}{actualContent}']")).Any());
            var expectedContent = driver.FindElement(By.XPath($"{textLocator}{actualContent}']"));
            Assert.AreEqual(expectedContent.Text, actualContent);

        }

        [TestCase("2209username1998@mail.ru", "2_password_2", "I ready to change name!!", "2909username1998@rambler.ru", "1_Password_1", "UaVseCdelal")]
        public void SendAndSendLetterFromRambler(string mailLogin, string mailPassword, string content, string ramblerLogin, string ramblerPassword, string newUserName)
        {
            LoginMailPage loginMailPage = new LoginMailPage(driver);
            loginMailPage.GoToPage();
            var mainMailPage = loginMailPage.LoginToMail("2209username1998@mail.ru", "2_password_2");
            var writerLetterMailPage = mainMailPage.ClickToWriteLetter();
            writerLetterMailPage.SendLetter("2909username1998@rambler.ru", "I ready to change my name!!");
            driver.Quit();

            driver = new ChromeDriver();

            LoginRamblerPage loginRamblerPage = new LoginRamblerPage(driver);
            loginRamblerPage.GoToLoginPage();
            var mainRamblerPage = loginRamblerPage.LoginIntoMail("2909username1998@rambler.ru", "1_Password_1");
            var ramblerLetterPage = mainRamblerPage.SelectLetter("2209username1998@mail.ru");
            ramblerLetterPage.ReplyOnLetter(newUserName);
            driver.Quit();

            driver = new ChromeDriver();

            loginMailPage = new LoginMailPage(driver);
            loginMailPage.GoToPage();
            mainMailPage = loginMailPage.LoginToMail("2209username1998@mail.ru", "2_password_2");
            var mailLetterPage = mainMailPage.SelectUnseenLetter();
            string newName = mailLetterPage.GetNameFromLetter();
            var settingsPage = mailLetterPage.GoToSetting();
            settingsPage.ChangeUserName(newName);
            mailLetterPage.GoToSetting();
            wait.Until(t => driver.FindElements(By.XPath("//input[@name = 'FirstName']")));
            var text = driver.FindElement(By.XPath("//input[@name = 'FirstName']"));

            Assert.AreEqual(text.GetAttribute("value"), newUserName);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
