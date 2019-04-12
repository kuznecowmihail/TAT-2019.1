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
                DisplayAvailableCommands("Enter command!");
                request = Console.ReadLine().ToLower();
                existence = false;

                if (request == executeCommand)
                {
                    foreach (var k in CommandsForExecute)
                    {
                        k.Key.DisplayInformation(k.Value);
                    }
                    CommandsForExecute = new Dictionary<ICommand, string>();
                    continue;
                }

                if (request == exitCommand)
                {
                    Console.WriteLine("Program completed.");
                    Environment.Exit(0);
                }

                foreach (var i in DictionaryOfCommands)
                {
                    if (i.Key == request)
                    {
                        AddToExecuteCommands(request, ref existence, i.Value, string.Empty);
                        break;
                    }
                    // For difficult command.
                    // If command have last ' ' symbol -> this is difficult command
                    // For this example: "average price " is difficult command, because after it comes our parameter.
                    // For example: "average price ford". Parameter is "ford".
                    else if (i.Key[i.Key.Length - 1] == ' ' && request.Contains(i.Key))
                    {
                        AddToExecuteCommands(request, ref existence, i.Value, request.Substring(i.Key.Length, request.Length - i.Key.Length));
                        break;
                    }
                }

                // if the request isn't command - false.
                if (existence == false)
                {
                    DisplayAvailableCommands("Try again!");
                }
            }
        }

        /// <summary>
        /// Method display information about available commands.
        /// </summary>
        /// <param name="line"></param>
        public void DisplayAvailableCommands(string line)
        {
            Console.WriteLine($"{line} Available command:");
            foreach (var i in DictionaryOfCommands)
            {
                if (!CommandsForExecute.ContainsKey(i.Value))
                {
                    Console.WriteLine($"-{i.Key}");
                }
            }
            Console.WriteLine($"-{executeCommand}\n-{exitCommand}");
        }

        /// <summary>
        /// Method check on contains the command in execute command and add to execute command.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="existence"></param>
        /// <param name="command"></param>
        /// <param name="param"></param>
        public void AddToExecuteCommands(string request, ref bool existence, ICommand command, string param)
        {
            if (CommandsForExecute.ContainsKey(command))
            {
                Console.WriteLine("This command using now. Can use 'execute' command.");
                existence = true;
                return;
            }
            Console.WriteLine("Enter auto type. Available type:");
            command.DisplayAutoTypes();
            string requestType = Console.ReadLine();

            while (command.IsContains(requestType) == false)
            {
                Console.WriteLine("Try again enter auto type!");
                requestType = Console.ReadLine();
            }
            CommandsForExecute.Add(command, param);
            existence = true;
        }
    }
}
