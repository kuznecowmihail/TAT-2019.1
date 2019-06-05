using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Task9
{
    public class ChromeDriverCreater : ICreater
    {
        public IWebDriver Create()
        {
            return new ChromeDriver();
        }
    }
}
