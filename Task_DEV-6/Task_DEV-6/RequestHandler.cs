using System;
using System.Collections.Generic;

namespace Task_DEV_6
{
    /// <summary>
    /// Class handle request of users.
    /// </summary>
    class RequestHandler
    {
        Dictionary<string, ICommand> DictionaryOfCommands { get; set; }
        // Difficult command.
        const string difficultCommand = "average price";
        const string exitCommand = "exit";

        /// <summary>
        /// Set command.
        /// </summary>
        /// <param name="dictionaryOfCommand"></param>
        public void SetCommand(Dictionary<string, ICommand> dictionaryOfCommand)
        {
            DictionaryOfCommands = dictionaryOfCommand;
        }

        /// <summary>
        /// Method handle request.
        /// </summary>
        public void HandleRequest()
        {
            bool existence = false;
            string request = String.Empty;
            Console.WriteLine($"Enter command! Available commands:");
            foreach(var i in DictionaryOfCommands.Keys)
            {
                Console.WriteLine($"-{i}");
            }
            // Infinity cicle.
            while((request = Console.ReadLine().ToLower()) != exitCommand)
            {
                existence = false;
                foreach (var i in DictionaryOfCommands)
                {
                    if(i.Key == request)
                    {
                        Console.WriteLine(i.Value.Calculate());
                        existence = true;
                        break;
                    }
                    // For difficult command
                    // If request conatains part of command, request contains fourth command and it isn't third command - go to fourth command.
                    else if(request.Contains(i.Key) && request.Contains(difficultCommand) && i.Key != difficultCommand)
                    {
                        Console.WriteLine(i.Value.Calculate(request.Substring(i.Key.Length, request.Length - i.Key.Length)));
                        existence = true;
                        break;
                    }
                    else if(request == exitCommand)
                    {
                        Console.WriteLine("Program complete.");
                        Environment.Exit(0);
                    }
                }

                // if the request isn't command - false.
                if (existence == false)
                {
                    Console.WriteLine($"Try again. Available command:");
                    foreach (var i in DictionaryOfCommands.Keys)
                    {
                        Console.WriteLine($"-{i}");
                    }
                }
            }
        }
    }
}
