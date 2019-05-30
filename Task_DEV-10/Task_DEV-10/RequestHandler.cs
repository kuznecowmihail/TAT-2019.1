using System;
using System.Collections.Generic;

namespace Task_DEV_10
{
    /// <summary>
    /// Class handle request of users.
    /// </summary>
    public class RequestHandler
    {
        public event Action<RequestHandler> ReadData;
        private Dictionary<string, ICommand> _commandsDictionary;
        public Dictionary<string, ICommand> CommandsDictionary {
            get => this._commandsDictionary;
            set
            {
                if(this._commandsDictionary != value)
                {
                    this._commandsDictionary = value;
                    this.ReadData?.Invoke(this);
                }
            }
        }
        const string displayCommand = "display";
        const string addCommand = "add";
        const string deleteCommand = "delete";
        const string writeToXMLCommand = "write to xml";
        const string exitCommand = "exit";

        /// <summary>
        /// Method handle requests.
        /// </summary>
        public void HandleRequests(Dictionary<string, ICommand> commandsDictionary)
        {
            this.CommandsDictionary = commandsDictionary ?? throw new ArgumentNullException(nameof(commandsDictionary));
            bool existence = true;

            while (true)
            {
                DisplayBaseCommands(existence == true ? "Enter command!" : "Try again!");
                string request = Console.ReadLine().ToLower();
                existence = false;

                switch (request)
                {
                    case exitCommand:
                        Console.WriteLine("Program completed.");
                        Environment.Exit(0);

                        break;
                    case addCommand:
                        while (existence == false)
                        {
                            DisplayAllCommands("Enter command!", CommandsDictionary.Keys);
                            request = Console.ReadLine().ToLower();

                            foreach (var command in CommandsDictionary)
                            {
                                if (command.Key == request)
                                {
                                    command.Value.AddNewElement();
                                    existence = true;

                                    break;
                                }
                            }
                        }

                        break;
                    case deleteCommand:
                        while (existence == false)
                        {
                            DisplayAllCommands("Enter command!", CommandsDictionary.Keys);
                            request = Console.ReadLine().ToLower();

                            foreach (var command in CommandsDictionary)
                            {
                                if (command.Key == request)
                                {
                                    command.Value.DeleteElement();
                                    existence = true;

                                    break;
                                }
                            }
                        }

                        break;
                    case displayCommand:
                        while (existence == false)
                        {
                            DisplayAllCommands("Enter command!", CommandsDictionary.Keys);
                            request = Console.ReadLine().ToLower();

                            foreach (var command in CommandsDictionary)
                            {
                                if (command.Key == request)
                                {
                                    command.Value.DisplayElements();
                                    existence = true;

                                    break;
                                }
                            }
                        }

                        break;
                    case writeToXMLCommand:
                        while (existence == false)
                        {
                            DisplayAllCommands("Enter command!", CommandsDictionary.Keys);
                            request = Console.ReadLine().ToLower();

                            foreach (var command in CommandsDictionary)
                            {
                                if (command.Key == request)
                                {
                                    command.Value.WriteToXML();
                                    existence = true;

                                    break;
                                }
                            }
                        }

                        break;
                }
            }
        }

        /// <summary>
        /// Method displays base commands to console.
        /// </summary>
        /// <param name="line"></param>
        void DisplayBaseCommands(string line)
        {
            Console.WriteLine($"{line} Available command:");
            Console.WriteLine($"-{addCommand}");
            Console.WriteLine($"-{deleteCommand}");
            Console.WriteLine($"-{displayCommand}");
            Console.WriteLine($"-{writeToXMLCommand}");
            Console.WriteLine($"-{exitCommand}");
        }

        /// <summary>
        /// Method displays commands to console.
        /// </summary>
        /// <param name="line"></param>
        /// <param name="commands"></param>
        void DisplayAllCommands(string line, IEnumerable<string> commands)
        {
            Console.WriteLine($"{line} Available command:");

            foreach (var command in commands)
            {
                Console.WriteLine($"-{command}");
            }
        }
    }
}