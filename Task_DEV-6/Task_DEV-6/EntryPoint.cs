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
                if(args.Length < 2)
                {
                    throw new Exception("Program hasn't names of XML files.");
                }
                List<Auto> cars = new AutoGetter(args[0]).GetAuto();
                List<Auto> trucks = new AutoGetter(args[1]).GetAuto();
                // Commands for our task.
                Dictionary<string, ICommand> DictionaryOfCarCommands = new Dictionary<string, ICommand>
                {
                    ["count types car"] = new NumberCarTypesCommand(new NumberCarTypes(cars)),
                    ["count all car"] = new NumberAllCarsCommand(new NumberAllCars(cars)),
                    ["average price car"] = new AverageCarPriceCommand(new AverageCarPrice(cars)),
                    ["average price car "] = new AverageTypePriceCommand(new AverageTypePrice(cars)),
                    ["count types truck"] = new NumberCarTypesCommand(new NumberCarTypes(trucks)),
                    ["count all truck"] = new NumberAllCarsCommand(new NumberAllCars(trucks)),
                    ["average price truck"] = new AverageCarPriceCommand(new AverageCarPrice(trucks)),
                    ["average price truck "] = new AverageTypePriceCommand(new AverageTypePrice(trucks)),
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
