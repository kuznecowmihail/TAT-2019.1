using System;
using System.Xml;

namespace Task_DEV_6
{
    /// <summary>
    /// The main class of program create object of RequestHandle and handle request.
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// The entry point of program.
        /// </summary>
        /// <param name="args">Name of XML</param>
        /// <returns 0>Normal start</returns>
        /// <returns 1>Error</returns>
        static int Main(string[] args)
        {
            try
            {
                if(args.Length == 0)
                {
                    throw new Exception("There isn't name of XML.");
                }
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(args[0]);
                RequestHandler requestHandler = new RequestHandler(new CarsHandler(xmlDocument));
                requestHandler.HandleRequest();

                return 0;
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");

                return 1;
            }
        }
    }
}
