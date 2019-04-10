﻿using System;
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
                AutoGetter carsGetter = new AutoGetter(args[0]);
                AutoGetter trucksGetter = new AutoGetter(args[1]);
                List<Auto> cars = carsGetter.GetAuto();
                List<Auto> trucks = trucksGetter.GetAuto();
                // Commands for our task.
                Dictionary<string, ICommand> DictionaryOfAutoCommands = new Dictionary<string, ICommand>
                {
                    ["count types car"] = new NumberAutoTypesCommand(new NumberAutoTypes(cars, carsGetter.AutoTypeGet())),
                    ["count all car"] = new NumberAllAutosCommand(new NumberAllAutos(cars, carsGetter.AutoTypeGet())),
                    ["average price car"] = new AverageAutoPriceCommand(new AverageAutoPrice(cars, carsGetter.AutoTypeGet())),
                    ["average price car "] = new AverageTypePriceCommand(new AverageTypePrice(cars, carsGetter.AutoTypeGet())),
                    ["count types truck"] = new NumberAutoTypesCommand(new NumberAutoTypes(trucks, trucksGetter.AutoTypeGet())),
                    ["count all truck"] = new NumberAllAutosCommand(new NumberAllAutos(trucks, trucksGetter.AutoTypeGet())),
                    ["average price truck"] = new AverageAutoPriceCommand(new AverageAutoPrice(trucks, trucksGetter.AutoTypeGet())),
                    ["average price truck "] = new AverageTypePriceCommand(new AverageTypePrice(trucks, trucksGetter.AutoTypeGet())),
                };
                RequestHandler requestHandler = new RequestHandler();
                // Add the commands to handler.
                // In programm can set different string and different command to requesthandler.
                requestHandler.SetCommand(DictionaryOfAutoCommands);
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
