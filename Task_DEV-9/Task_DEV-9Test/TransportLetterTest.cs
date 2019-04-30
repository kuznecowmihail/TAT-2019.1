using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using Task_DEV_9;

namespace Task_DEV_9Test
{
    [TestFixture]
    public class TransportLetterTest : BaseTest
    {
        const string sentLetterlocator = "//div[@class = 'message-sent__title']";
        const string textLocator = "//div[text() = '";
        const string inputName = "//input[@name = 'FirstName']";

        [TestCase("2209username1998@mail.ru", "2_password_2", "2909username1998@rambler.ru", "I ready to change my name!!")]
        public void SendLetterFromMail(string mailLogin, string mailPassword, string recipient, string content)
        {
            // Mail.
            var mainMailPage = LoginToMail(mailLogin, mailPassword);
            var writerLetterMailPage = mainMailPage.ClickToWriteLetter();
            writerLetterMailPage.SendLetter(recipient, content);
            // Wait element that see sending letter.
            wait.Until(t => driver.FindElements(By.XPath(sentLetterlocator)).Any());
            var sentLetter = driver.FindElements(By.XPath(sentLetterlocator));
            Assert.IsTrue(sentLetter.Count == 1);
        }

        [TestCase("2209username1998@mail.ru", "2_password_2", "I ready to change name!!", "2909username1998@rambler.ru", "1_Password_1")]
        public void SendAndRecieveLetter(string mailLogin, string mailPassword, string content, string ramblerLogin, string ramblerPassword)
        {
            // Mail.
            var mainMailPage = LoginToMail(mailLogin, mailPassword);
            var writerLetterMailPage = mainMailPage.ClickToWriteLetter();
            writerLetterMailPage.SendLetter(ramblerLogin, content);
            // Rambler.
            LoginRamblerPage loginRamblerPage = new LoginRamblerPage(driver);
            loginRamblerPage.GoToLoginPage();
            var mainRamblerPage = loginRamblerPage.LoginIntoMail(ramblerLogin, ramblerPassword);
            Assert.IsTrue(mainRamblerPage.GetCountUnreadSenderLetter(mailLogin) > 0);
        }

        [TestCase("2209username1998@mail.ru", "2_password_2", "I ready to change name!!", "2909username1998@rambler.ru", "1_Password_1")]
        public void SendAndReadLetter(string mailLogin, string mailPassword, string actualContent, string ramblerLogin, string ramblerPassword)
        {
            // Mail.
            var mainMailPage = LoginToMail(mailLogin, mailPassword);
            var writerLetterMailPage = mainMailPage.ClickToWriteLetter();
            writerLetterMailPage.SendLetter(ramblerLogin, actualContent);
            //Rambler
            LoginRamblerPage loginRamblerPage = new LoginRamblerPage(driver);
            loginRamblerPage.GoToLoginPage();
            var mainRamblerPage = loginRamblerPage.LoginIntoMail(ramblerLogin, ramblerPassword);
            //Read unread letter from mailsender.
            var selectLetter = mainRamblerPage.SelectUnreadLetter(mailLogin);
            // Wait letter content from sender.
            wait.Until(t => driver.FindElements(By.XPath($"{textLocator}{actualContent}']")).Any());
            var expectedContent = driver.FindElement(By.XPath($"{textLocator}{actualContent}']"));
            Assert.AreEqual(expectedContent.Text, actualContent);

        }

        [TestCase("2209username1998@mail.ru", "2_password_2", "I ready to change name!!", "2909username1998@rambler.ru", "1_Password_1", "UaVseCdelal")]
        public void SendAndSendLetterFromRambler(string mailLogin, string mailPassword, string content, string ramblerLogin, string ramblerPassword, string newUserName)
        {
            // Mail.
            var mainMailPage = LoginToMail(mailLogin, mailPassword);
            var writerLetterMailPage = mainMailPage.ClickToWriteLetter();
            writerLetterMailPage.SendLetter(ramblerLogin, content);
            TearDown(); ;
            // Rambler.
            SetUp();
            LoginRamblerPage loginRamblerPage = new LoginRamblerPage(driver);
            loginRamblerPage.GoToLoginPage();
            var mainRamblerPage = loginRamblerPage.LoginIntoMail(ramblerLogin, ramblerPassword);
            var ramblerLetterPage = mainRamblerPage.SelectUnreadLetter(mailLogin);
            ramblerLetterPage.ReplyOnLetter(newUserName);
            TearDown();
            // Mail.
            SetUp();
            mainMailPage = LoginToMail(mailLogin, mailPassword);
            var letterMailPage = mainMailPage.SelectUnseenLetter(ramblerLogin);
            string newName = letterMailPage.GetNameFromLetter();
            var settingsPage = letterMailPage.GoToSetting();
            settingsPage.ChangeUserName(newName);
            // Check setting.
            letterMailPage.GoToSetting();
            // Wait name element.
            wait.Until(t => driver.FindElements(By.XPath(inputName)));
            var text = driver.FindElement(By.XPath(inputName));
            Assert.AreEqual(text.GetAttribute("value"), newUserName);
        }
    }
}
