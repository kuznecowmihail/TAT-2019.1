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
        const string exitCommand = "exit";

        /// <summary>
        /// Set command.
        /// </summary>
        /// <param name="dictionaryOfCommand"></param>
        public void SetCommand(Dictionary<string, ICommand> dictionaryOfCommand) => DictionaryOfCommands = dictionaryOfCommand;

        /// <summary>
        /// Method handle request.
        /// </summary>
        public void HandleRequest()
        {
            bool existence = false;
            string request = String.Empty;
            DisplayAllCommands("Enter command!");

            // Infinity cicle.
            while(true)
            {
                request = Console.ReadLine().ToLower();
                existence = false;

                foreach (var i in DictionaryOfCommands)
                {
                    if (i.Key == request)
                    {
                        i.Value.DisplayInformation();
                        existence = true;
                        break;
                    }
                    // For difficult command.
                    // If command have last ' ' symbol -> this is difficult command
                    // For this example: "average price " is difficult command, because after it comes our parameter.
                    // For example: "average price ford". Parameter is "ford".
                    else if (i.Key[i.Key.Length - 1] == ' ' && request.Contains(i.Key))
                    {
                        i.Value.DisplayInformation(request.Substring(i.Key.Length, request.Length - i.Key.Length));
                        existence = true;
                        break;
                    }
                    else if (request == exitCommand)
                    {
                        Console.WriteLine("Program completed.");
                        Environment.Exit(0);
                    }
                }
                
                // if the request isn't command - false.
                if (existence == false)
                {
                    DisplayAllCommands("Try again!");
                }
            }
        }

        /// <summary>
        /// Method display information about commands.
        /// </summary>
        /// <param name="line"></param>
        public void DisplayAllCommands(string line)
        {
            Console.WriteLine($"{line} Available command:");
            foreach (var i in DictionaryOfCommands.Keys)
            {
                Console.WriteLine($"-{i}");
            }
        }
    }
}
