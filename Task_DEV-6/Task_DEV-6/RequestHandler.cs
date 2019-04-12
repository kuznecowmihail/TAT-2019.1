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
            
            // Infinity cicle.
            while(true)
            {
                // if the request isn't command - false.
                DisplayAllCommands(existence == true ? "Enter command!" : "Try again!");
                request = Console.ReadLine().ToLower();
                existence = false;

                if (request == exitCommand)
                {
                    Console.WriteLine("Program completed.");
                    Environment.Exit(0);
                }

                foreach (var command in DictionaryOfCommands)
                {
                    if (command.Key == request)
                    {
                        command.Value.DisplayInformation();
                        existence = true;
                        break;
                    }

                    // For difficult command.
                    // If command have last ' ' symbol -> this is difficult command
                    // For this example: "average price " is difficult command, because after it comes our parameter.
                    // For example: "average price ford". Parameter is "ford".
                    if (command.Key[command.Key.Length - 1] == ' ' && request.Contains(command.Key))
                    {
                        command.Value.DisplayInformation(request.Substring(command.Key.Length, request.Length - command.Key.Length));
                        existence = true;
                        break;
                    }
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

            foreach (var command in DictionaryOfCommands.Keys)
            {
                Console.WriteLine($"-{command}");
            }
            Console.WriteLine("-exit");
        }
    }
}
