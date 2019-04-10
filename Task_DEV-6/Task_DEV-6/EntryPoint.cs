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
                // Commands for our example.
                Dictionary<string, ICommand> DictionaryOfCarCommands = new Dictionary<string, ICommand>
                {
                    ["count types"] = new CounterTypesCommand(new CounterTypes(new CarsGetter(args[0]).GetCars())),
                    ["count all"] = new CounterAllCarsCommand(new CounterAllCars(new CarsGetter(args[0]).GetCars())),
                    ["average price"] = new CalculaterAveragePriceCommand(new CalculaterAveragePrice(new CarsGetter(args[0]).GetCars())),
                    ["average price "] = new CalculaterAveragePriceTypeCommand(new CalculaterAveragePriceType(new CarsGetter(args[0]).GetCars())),
                };
                RequestHandler requestHandler = new RequestHandler();
                // Add the commands to handler.
                // In programm can set different string and different command to requesthandler.
                requestHandler.SetCommand(DictionaryOfCarCommands);
                requestHandler.HandleRequest();

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
