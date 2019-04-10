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
                // Commands for our task.
                Dictionary<string, ICommand> DictionaryOfCarCommands = new Dictionary<string, ICommand>
                {
                    ["count types car"] = new NumberCarTypesCommand(new NumberCarTypes(new AutoGetter(args[0]).GetCars())),
                    ["count all car"] = new NumberAllCarsCommand(new NumberAllCars(new AutoGetter(args[0]).GetCars())),
                    ["average price car"] = new AverageCarPriceCommand(new AverageCarPrice(new AutoGetter(args[0]).GetCars())),
                    ["average price car "] = new AverageTypePriceCommand(new AverageTypePrice(new AutoGetter(args[0]).GetCars())),
                    ["count types truck"] = new NumberCarTypesCommand(new NumberCarTypes(new AutoGetter(args[1]).GetCars())),
                    ["count all truck"] = new NumberAllCarsCommand(new NumberAllCars(new AutoGetter(args[1]).GetCars())),
                    ["average price truck"] = new AverageCarPriceCommand(new AverageCarPrice(new AutoGetter(args[1]).GetCars())),
                    ["average price truck "] = new AverageTypePriceCommand(new AverageTypePrice(new AutoGetter(args[1]).GetCars())),
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
