namespace Task_DEV_9
{
    /// <summary>
    /// Class has locators for each page of mail.
    /// </summary>
    public class MailLocators
    {
        /// <summary>
        /// Class has locators for login page.
        /// </summary>
        public class LoginPageLocator
        {
            public string PageLocator
            {
                get => "https://mail.ru/";
            }

            public string LoginLocator
            {
                get => "//input[@name = 'login']";
            }

            public string PasswordLocator
            {
                get => "//input[@name = 'password']";
            }

            public string CheckBoxLocator
            {
                get => "//input[@class = 'mailbox__saveauth']";
            }

            public string LoginButtonLocator
            {
                get => "//input[@class= 'o-control']";
            }
        }

        /// <summary>
        /// Class has locators for main page.
        /// </summary>
        public class MainPageLocator
        {
            public string WriteButtonLocator
            {
                get => "//span[text() = 'Написать письмо']";
            }

            public string SelectUnseenLetterLocator
            {
                get => "//div[@class = 'b-datalist__item js-datalist-item b-datalist__item_unread']";
            }
        }

        /// <summary>
        /// Class has locators for write letter page.
        /// </summary>
        public class WriterPageLocator
        {
            public string RecepientLocator
            {
                get => "//textarea[@tabindex = '4']";
            }

            public string SendButtonLocator
            {
                get => "//div[@class = 'b-toolbar__item b-toolbar__item_ b-toolbar__item_false']";
            }

            public string SwitcherToFrameLocator
            {
                get => "//tr[@class = 'mceFirst mceLast']//iframe";
            }

            public string TextLocator
            {
                get => "//body[@id = 'tinymce']";
            }

            public string LetterSentLocator
            {
                get => "//div[@class = 'message-sent__title']";
            }
        }

        /// <summary>
        /// Class has locators for letter page.
        /// </summary>
        public class LetterPageLocator
        {
            public string TextLocator
            {
                get => "//div[@class = 'js-helper js-readmsg-msg']//div//div//div";
            }

            public string ProfileLocator
            {
                get => "//i[@id = 'PH_user-email']";
            }

            public string SettingsLocator
            {
                get => "//span[text() = 'Личные данные']";
            }
        }

        /// <summary>
        /// Class has locators for setting page.
        /// </summary>
        public class SettingsPageLocator
        {
            public string UserNameLocator
            {
                get => "//input[@name = 'FirstName']";
            }

            public string SaveButtonlocator
            {
                get => "//span[text() = 'Сохранить']";
            }

            public string ProfileLocator
            {
                get => "//i[@id = 'PH_user-email']";
            }
        }
    }
}
