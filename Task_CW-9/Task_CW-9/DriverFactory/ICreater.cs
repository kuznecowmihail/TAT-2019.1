using OpenQA.Selenium;

namespace Task9
{
    /// <summary>
    /// Interface for factory pattern.
    /// </summary>
    public interface ICreater
    {
        /// <summary>
        /// The method creates webdriver.
        /// </summary>
        /// <returns></returns>
        IWebDriver Create();
    }
}
