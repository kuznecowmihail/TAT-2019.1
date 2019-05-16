using System;
using System.Collections.Generic;

namespace Task_DEV_7
{
    /// <summary>
    /// Class handle request of users.
    /// </summary>
    public class RequestHandler
    {
        // String - name of command.
        Dictionary<string, ICommand> DictionaryOfCommands { get; set; }
        // Commands for execute.
        List<ICommand> CommandsForExecution { get; set; }
        const string executeCommand = "execute";
        const string exitCommand = "exit";

        /// <summary>
        /// Constructor of Requesthandler.
        /// </summary>
        public RequestHandler()
        {
            this.CommandsForExecution = new List<ICommand>();
        }

        /// <summary>
        /// Method handles request.
        /// </summary>
        public void HandleRequest(Dictionary<string, ICommand> dictionaryOfCommands)
        {
            DictionaryOfCommands = dictionaryOfCommands ?? throw new NullReferenceException("Don't set a dictionary of command.");
            // The existence of such a request.
            bool existence = true;
            // Request of users.

            // Infinity cicle.
            while (true)
            {
                // if the request isn't command - false.
                DisplayAvailableCommands(existence == true ? "Enter command!" : "Try again!");
                string request = Console.ReadLine().ToLower();
                existence = false;

                if (request == executeCommand)
                {
                    foreach (var executeCommand in CommandsForExecution)
                    {
                        executeCommand.DisplayInformation();
                    }
                    CommandsForExecution.Clear();
                    existence = true;
                    continue;
                }

                if (request == exitCommand)
                {
                    Console.WriteLine("Program completed.");
                    Environment.Exit(0);
                }

                foreach (var command in DictionaryOfCommands)
                {
                    if (command.Key == request)
                    {
                        AddToExecuteCommands(command.Value, string.Empty);
                        existence = true;
                        break;
                    }
                    // For difficult command.
                    // If command have last ' ' symbol -> this is difficult command
                    // For this example: "average price " is difficult command, because after it comes our parameter.
                    // For example: "average price ford". Parameter is "ford".
                    else if (command.Key[command.Key.Length - 1] == ' ' && request.Contains(command.Key))
                    {
                        AddToExecuteCommands(command.Value, request.Substring(command.Key.Length, request.Length - command.Key.Length));
                        existence = true;
                        break;
                    }
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

            foreach (var command in DictionaryOfCommands)
            {
                if (!CommandsForExecution.Contains(command.Value))
                {
                    Console.WriteLine($"-{command.Key}");
                }
            }
            Console.WriteLine($"-{executeCommand}\n-{exitCommand}");
        }

        public void DisplayAvailableType(List<string> autoTypes, string line)
        {
            Console.WriteLine($"{line} Available type:");
            foreach (var autoType in autoTypes)
            {
                Console.WriteLine($"-{autoType}");
            }
        }

        /// <summary>
        /// Method check on contains the command in execute command and add to execute command.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="brand"></param>
        public void AddToExecuteCommands(ICommand command, string brand)
        {
            if (CommandsForExecution.Contains(command))
            {
                Console.WriteLine("This command using now. Can use 'execute' command.");

                return;
            }
            string type;
            bool incorrecetType = false;

            do
            {
                DisplayAvailableType(command.GetAutoTypes(),
                    incorrecetType == false
                    ? "Enter auto type."
                    : "Try again!");
                type = Console.ReadLine();
                incorrecetType = true;
            } while (!command.GetAutoTypes().Contains(type));
            command.SetProperties(type, brand);
            CommandsForExecution.Add(command);
        }
    }
}