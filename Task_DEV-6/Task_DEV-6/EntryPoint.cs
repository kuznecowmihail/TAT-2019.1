using System;
using System.Collections.Generic;

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
                    throw new Exception("Program hasn't name of XML.");
                }
                List<Car> cars = new CarsGetter(args[0]).GetCars();
                // Commands for our task.
                Dictionary<string, ICommand> DictionaryOfCarCommands = new Dictionary<string, ICommand>
                {
                    ["count types"] = new NumberCarTypesCommand(new NumberCarTypes(cars)),
                    ["count all"] = new NumberAllCarsCommand(new NumberAllCars(cars)),
                    ["average price"] = new AverageCarPriceCommand(new AverageCarPrice(cars)),
                    ["average price "] = new AverageTypePriceCommand(new AverageTypePrice(cars)),
                };
                RequestHandler requestHandler = new RequestHandler();
                // Add the commands to handler.
                // In programm can set different string and different command to requesthandler.
                requestHandler.HandleRequest(DictionaryOfCarCommands);

                return 0;
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error: {e.Message}.");

                return 1;
            }
        }
    }
}
