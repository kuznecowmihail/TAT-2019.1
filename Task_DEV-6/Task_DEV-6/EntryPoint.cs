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
                // Commands for our task.
                Dictionary<string, ICommand> DictionaryOfAutoCommands = new Dictionary<string, ICommand>
                {
                    ["count types car"] = new NumberAutoTypesCommand(new NumberAutoTypes(AutoGetter.GetAutoGetter().GetAuto(args[0]))),
                    ["count all car"] = new NumberAllAutosCommand(new NumberAllAutos(AutoGetter.GetAutoGetter().GetAuto(args[0]))),
                    ["average price car"] = new AverageAutoPriceCommand(new AverageAutoPrice(AutoGetter.GetAutoGetter().GetAuto(args[0]))),
                    ["average price car "] = new AverageTypePriceCommand(new AverageTypePrice(AutoGetter.GetAutoGetter().GetAuto(args[0]))),
                    ["count types truck"] = new NumberAutoTypesCommand(new NumberAutoTypes(AutoGetter.GetAutoGetter().GetAuto(args[1]))),
                    ["count all truck"] = new NumberAllAutosCommand(new NumberAllAutos(AutoGetter.GetAutoGetter().GetAuto(args[1]))),
                    ["average price truck"] = new AverageAutoPriceCommand(new AverageAutoPrice(AutoGetter.GetAutoGetter().GetAuto(args[1]))),
                    ["average price truck "] = new AverageTypePriceCommand(new AverageTypePrice(AutoGetter.GetAutoGetter().GetAuto(args[1])))
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
