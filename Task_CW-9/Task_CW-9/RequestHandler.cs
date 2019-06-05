using System;

namespace Task9
{
    /// <summary>
    /// The class handles request.
    /// </summary>
    public class RequestHandler
    {
        FactoryDriverCreater FactoryDriverCreater { get; }
        FactoryWriter FactoryWriter { get; }

        public RequestHandler()
        {
            this.FactoryDriverCreater = new FactoryDriverCreater();
            this.FactoryWriter = new FactoryWriter();
        }

        /// <summary>
        /// The method handles requests and write data to file.
        /// </summary>
        public void HandleRequests()
        {
            while (true)
            {
                Console.WriteLine("Enter the command in the format:\n@name.format browser");
                string request = Console.ReadLine();
                ICreater creater = FactoryDriverCreater.GetDriver(request);
                IWriter writer = FactoryWriter.GetWriter(request);

                if (creater != null && writer != null)
                {
                    MainPage mainPage = new MainPage(creater.Create());
                    writer.Write(mainPage.GetCurrency());
                    Console.WriteLine("Data recorded.");

                    break;
                }
            }
        }
    }
}
