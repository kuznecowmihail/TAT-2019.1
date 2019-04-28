using System;
using OpenQA.Selenium;

namespace Task_DEV_9
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            IWebDriver webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();

            LoginMailPage loginMailPage = new LoginMailPage(webDriver);
            loginMailPage.GoToPage();
            var mainMailPage = loginMailPage.LoginToMail("2209username1998@mail.ru", "2_password_2");
            var writerLetterMailPage = mainMailPage.ClickToWriteLetter();
            writerLetterMailPage.SendLetter("2909username1998@rambler.ru", "I ready to change my name!!");
            webDriver.Quit();

            webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();

            LoginRamblerPage loginRamblerPage = new LoginRamblerPage(webDriver);
            loginRamblerPage.GoToLoginPage();
            var mainRamblerPage = loginRamblerPage.LoginIntoMail("2909username1998@rambler.ru", "1_Password_1");
            var ramblerLetterPage = mainRamblerPage.SelectLetter("2209username1998@mail.ru");
            ramblerLetterPage.ReplyOnLetter("Tanechka");
            webDriver.Quit();

            webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();

            loginMailPage = new LoginMailPage(webDriver);
            loginMailPage.GoToPage();
            mainMailPage = loginMailPage.LoginToMail("2209username1998@mail.ru", "2_password_2");
            var mailLetterPage = mainMailPage.SelectUnseenLetter();
            string newUserName = mailLetterPage.GetNameFromLetter();
            var settingsPage = mailLetterPage.GoToSetting();
            settingsPage.ChangeUserName(newUserName);
        }
    }
}
