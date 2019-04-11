using System;
using System.Collections.Generic;

namespace Task_DEV_6
{
    /// <summary>
    /// Class handle request of users.
    /// </summary>
    public class RequestHandler
    {
        Dictionary<string, ICommand> DictionaryOfCommands { get; set; }
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
                        CommandsForExecute.Add(i.Value, String.Empty);
                        existence = true;
                        break;
                    }
                    // For difficult command.
                    // If command have last ' ' symbol -> this is difficult command
                    // For this example: "average price " is difficult command, because after it comes our parameter.
                    // For example: "average price ford". Parameter is "ford".
                    else if (i.Key[i.Key.Length - 1] == ' ' && request.Contains(i.Key))
                    {
                        CommandsForExecute.Add(i.Value, request.Substring(i.Key.Length, request.Length - i.Key.Length));
                        existence = true;
                        break;
                    }
                    else if(request == executeCommand)
                    {
                        foreach(var k in CommandsForExecute)
                        {
                            k.Key.DisplayInformation(k.Value);
                        }
                        existence = true;
                        CommandsForExecute = new Dictionary<ICommand, string>();
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
