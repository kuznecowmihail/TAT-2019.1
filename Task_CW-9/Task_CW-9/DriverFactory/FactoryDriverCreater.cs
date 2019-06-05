namespace Task9
{
    /// <summary>
    /// The class chooses webdriver.
    /// </summary>
    public class FactoryDriverCreater
    {
        const string nameChrome = "chrome";

        /// <summary>
        /// The method returns webdriver.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ICreater GetDriver(string request)
        {
            int startIndex = request.IndexOf(' ');
            string driverName = request.Substring(startIndex + 1);

            switch (driverName)
            {
                case nameChrome:
                    return new ChromeDriverCreater();
                default:
                    return null;
            }
        }
    }
}
