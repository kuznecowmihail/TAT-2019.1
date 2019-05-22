using System;
using System.Collections.Generic;

namespace Task_DEV_10
{
    /// <summary>
    /// Class handle request of users.
    /// </summary>
    public class RequestHandler
    {
        Dictionary<string, ICommand> CommandsDictionary { get; }
        const string displayCommand = "display";
        const string addCommand = "add";
        const string deleteCommand = "delete";
        const string backCommand = "back";
        const string exitCommand = "exit";

        public RequestHandler()
        {
            Shop shop = new Shop();
            this.CommandsDictionary = new Dictionary<string, ICommand>
            {
                ["product"] = new ProductCommand(shop),
                ["address"] = new AddressCommand(shop),
                ["delivery"] = new DeliveryCommand(shop),
                ["manufacturer"] = new ManufacturerCommand(shop),
                ["warehouse"] = new WareHouseCommand(shop),
            };
        }

        /// <summary>
        /// Method handle requests.
        /// </summary>
        public void HandleRequests()
        {
            bool existence = true;

            foreach (var command in CommandsDictionary.Values)
            {
                command.ReadAndFillElements();
            }

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
                                    command.Value.UpdateJsonFile();
                                    existence = true;

                                    break;
                                }
                                else if (request == backCommand)
                                {
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
                                else if (request == backCommand)
                                {
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
                                else if (request == backCommand)
                                {
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
            Console.WriteLine($"-{backCommand}");
        }
    }
}
