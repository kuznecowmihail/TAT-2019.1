﻿using System;
using System.Collections.Generic;

namespace Task_DEV_7
{
    /// <summary>
    /// The main class of program create object of RequestHandle and handle request.
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// The entry point of program calls request handler.
        /// </summary>
        /// <param name="args">Names XML</param>
        /// <returns>0 - norm start</returns>
        /// <returns>1 -Error</returns>
        static int Main(string[] args)
        {
            try
            {
                if (args.Length < 2)
                {
                    throw new Exception("Program hasn't names of XML files.");
                }
                // Dictionary string name of types -> list of type autos.
                Dictionary<string, IEnumerable<Auto>> dictionaryOfAutoTypes = new Dictionary<string, IEnumerable<Auto>>
                {
                    [args[0].ToLower()] = CarGetter.GetCarGetter(args[0]).Cars,
                    [args[1].ToLower()] = TruckGetter.GetTruckGetter(args[1]).Trucks
                };
                // Dictionary string name of commands -> commands.
                Dictionary<string, ICommand> dictionaryOfAutoCommands = new Dictionary<string, ICommand>
                {
                    ["count types"] = new NumberAutoTypesCommand(new NumberAutoTypes(dictionaryOfAutoTypes)),
                    ["count all"] = new NumberAllAutosCommand(new NumberAllAutos(dictionaryOfAutoTypes)),
                    ["average price"] = new AverageAutoPriceCommand(new AverageAutoPrice(dictionaryOfAutoTypes)),
                    ["average price "] = new AverageTypePriceCommand(new AverageTypePrice(dictionaryOfAutoTypes))
                };
                RequestHandler requestHandler = new RequestHandler();
                requestHandler.HandleRequest(dictionaryOfAutoCommands);

                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}.");

                return 1;
            }
        }
    }
}