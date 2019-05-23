using System;
using System.Collections.Generic;

namespace Task_DEV_10
{
    /// <summary>
    /// Base class of program.
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// The entry point of program.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                Shop shop = new Shop();
                RequestHandler handler = new RequestHandler();
                JsonFileHandler jsonFileHandler = new JsonFileHandler(shop);
                Dictionary<string, ICommand> commandsDictionary = new Dictionary<string, ICommand>
                {
                    ["product"] = new ProductCommand(shop),
                    ["address"] = new AddressCommand(shop),
                    ["delivery"] = new DeliveryCommand(shop),
                    ["manufacturer"] = new ManufacturerCommand(shop),
                    ["warehouse"] = new WareHouseCommand(shop),
                };

                foreach(var command in commandsDictionary.Values)
                {
                    command.UpdateData += jsonFileHandler.UpdateJsonFile;
                }
                handler.ReadData += jsonFileHandler.ReadAndWriteFromJson;
                handler.HandleRequests(commandsDictionary);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}
