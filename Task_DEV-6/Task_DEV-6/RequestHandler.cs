using System;
using System.Collections.Generic;

namespace Task_DEV_6
{
    /// <summary>
    /// Class handle request of users.
    /// </summary>
    public class RequestHandler
    {
        // String - name of command.
        Dictionary<string, ICommand> DictionaryOfCommands { get; set; }
        // String - param for object function.
        Dictionary<ICommand, string> CommandsForExecute { get; set; }
        const string executeCommand = "execute";
        const string exitCommand = "exit";

        /// <summary>
        /// Constructor of Requesthandler.
        /// </summary>
        public RequestHandler()
        {
            this.CommandsForExecute = new Dictionary<ICommand, string>();
        }

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
            // The existence of such a request.
            bool existence = false;
            string request = string.Empty;
            string requestType = string.Empty;

            // Infinity cicle.
            while (true)
            {
                DisplayAllCommands("Enter command!");
                request = Console.ReadLine().ToLower();
                existence = false;

                if (request == executeCommand)
                {
                    foreach (var k in CommandsForExecute)
                    {
                        k.Key.DisplayInformation(k.Value);
                    }
                    existence = true;
                    CommandsForExecute = new Dictionary<ICommand, string>();
                    continue;
                }
                else if (request == exitCommand)
                {
                    Console.WriteLine("Program completed.");
                    Environment.Exit(0);
                }

                foreach (var i in DictionaryOfCommands)
                {
                    if (i.Key == request)
                    {
                        Console.WriteLine("Enter the type of auto.");
                        requestType = Console.ReadLine();

                        // Exception on existence the command to commands to perform.
                        if (CommandsForExecute.ContainsKey(i.Value))
                        {
                            Console.WriteLine("This command using now. Can use 'execute' command.");
                            existence = true;
                            break;
                        }

                        // Check on existence the auto type.
                        while (i.Value.IsContains(requestType) == false)
                        {
                            Console.WriteLine("Try again type of auto!");
                            requestType = Console.ReadLine();
                        }
                        CommandsForExecute.Add(i.Value, string.Empty);
                        existence = true;
                        break;
                    }
                    // For difficult command.
                    // If command have last ' ' symbol -> this is difficult command
                    // For this example: "average price " is difficult command, because after it comes our parameter.
                    // For example: "average price ford". Parameter is "ford".
                    else if (i.Key[i.Key.Length - 1] == ' ' && request.Contains(i.Key))
                    {
                        Console.WriteLine("Enter the type of auto.");
                        requestType = Console.ReadLine();
                        
                        if (CommandsForExecute.ContainsKey(i.Value))
                        {
                            Console.WriteLine("This command using now. Can use 'execute' command.");
                            existence = true;
                            break;
                        }

                        while (i.Value.IsContains(requestType) == false)
                        {
                            Console.WriteLine("Try again type of auto!");
                            requestType = Console.ReadLine();
                        }
                        CommandsForExecute.Add(i.Value, request.Substring(i.Key.Length, request.Length - i.Key.Length));
                        existence = true;
                        break;
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
            Console.WriteLine($"-{executeCommand}\n-{exitCommand}");
        }
    }
}
