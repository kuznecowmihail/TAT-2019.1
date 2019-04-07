using System;
using System.Collections.Generic;

namespace Task_DEV_6
{
    /// <summary>
    /// Class handle request of users.
    /// </summary>
    class RequestHandler
    {
        Dictionary<string, ICommand> DictionaryOfCommands { get; }
        const string firstCommand = "count types";
        const string secondCommand = "count all";
        const string thirdCommand = "average price";
        const string fourthCommand = "average price ";
        const string exitCommand = "exit";

        /// <summary>
        /// Constructor of RequestHandler.
        /// </summary>
        /// <param name="carsHead"></param>
        public RequestHandler(CarsHandler carsHead)
        {
            DictionaryOfCommands = new Dictionary<string, ICommand>
            {
                ["count types"] = new CounterTypesOnCommand(carsHead),
                ["count all"] = new CounterAllCarsOnCommand(carsHead),
                ["average price"] = new CalculaterAveragePriceOnCommand(carsHead),
                ["average price "] = new CalculaterAveragePricaTypeOnCommand(carsHead)
            };
        }

        /// <summary>
        /// Method handle request.
        /// </summary>
        public void HandleRequest()
        {
            bool existence = false;
            string request = String.Empty;
            Console.WriteLine($"Enter command! Available commands: 1){firstCommand} 2){secondCommand} 3){thirdCommand} 4){fourthCommand}<type>.");

            while((request = Console.ReadLine().ToLower()) != exitCommand)
            {
                foreach(var i in DictionaryOfCommands)
                {
                    if(i.Key == request)
                    {
                        Console.WriteLine(i.Value.Calculate());
                        existence = true;
                        break;
                    }
                    else if(request.Contains(i.Key) &&  i.Key != thirdCommand)
                    {
                        Console.WriteLine(i.Value.Calculate(request.Substring(fourthCommand.Length, request.Length - fourthCommand.Length)));
                        existence = true;
                        break;
                    }
                }

                if (existence == false)
                {
                    Console.WriteLine($"Try again. Available command: 1){firstCommand} 2){secondCommand} 3){thirdCommand} 4){fourthCommand}<type>.");
                    continue;
                }
                existence = false;
            }
        }
    }
}
