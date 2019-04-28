namespace Task_DEV_9
{
    /// <summary>
    /// Class has locators for each page of rambler.
    /// </summary>
    public class RamblerLocators
    {
        /// <summary>
        /// Class has locators for login page.
        /// </summary>
        public class LoginPageLocator
        {
            public string PageLocator
            {
                get => "https://mail.rambler.ru";
            }

            public string SwitcherToFrameLocator
            {
                get => "//iframe";
            }

            public string LoginLocator
            {
                get => "//input[@name = 'login']";
            }

            public string PasswordLocator
            {
                get => "//input[@name = 'password']";
            }

            public string CheckBoxlocator
            {
                get => "//span[@class = 'rui-Checkbox-fake']";
            }

            public string LoginButtonLocator
            {
                get => "//span[@class='rui-Button-content']";
            }
        }

        /// <summary>
        /// Class has locators for main page.
        /// </summary>
        public class MainRamblerLocator
        {
            public string SelectLetterLocator
            {
                get => "//div[@class = 'AutoMaillistItem-root-1n AutoMaillistItem-unseen-ad']//a//span[@class = 'AutoMaillistItem-sender-1V']";
            }
        }

        /// <summary>
        /// Class has locators for letter page.
        /// </summary>
        public class LetterPageLocator
        {
            public string TextLocator
            {
                get => "//textarea[@class = 'rui-Input-input QuickReply-textarea-3R']";
            }

            public string SendButtonLocator
            {
                get => "//button[@type = 'button']";
            }

            public string LetterSentLocator
            {
                get => "//div[@class = 'notification notification-success notification-visible']";//a[@class = 'AutoMaillistItem-wrapper-18']";
            }
        }
    }
}
