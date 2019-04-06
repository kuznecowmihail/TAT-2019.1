using System;
using System.Xml;

namespace Task_DEV_6
{
    class RequestHandler
    {
        readonly ICommand[] command;
        const string firstCommand = "count types";
        const string secondCommand = "count all";
        const string thirdCommand = "average price";
        const string fourthCommand = "average price";

        public RequestHandler(CarsHandler carsHead)
        {
            command = new ICommand[] 
            {
                new CounterTypesOnCommand(carsHead),
                new CounterAllCarsOnCommand(carsHead),
                new CalculaterAveragePriceOnCommand(carsHead),
                new CalculaterAveragePricaTypeOnCommand(carsHead)
            };
        }

        public void HandleRequest()
        {
            Console.WriteLine("Enter command:");
            string request = String.Empty;

            while((request = Console.ReadLine()) != "Exit")
            {
                switch (request)
                {
                    case firstCommand:
                        Console.WriteLine(command[0].Calculate());
                        continue;
                    case secondCommand:
                        Console.WriteLine(command[1].Calculate());
                        continue;
                    case thirdCommand:
                        Console.WriteLine(command[2].Calculate());
                        continue;
                    default:
                        if(request.Contains(fourthCommand) && request != thirdCommand)
                        {
                            Console.WriteLine(command[3].Calculate(request.Substring(fourthCommand.Length + 1, request.Length - fourthCommand.Length - 1)));
                            continue;
                        }
                        PrintAvailableCommand();
                        continue;
                }
            }
        }
        
        public void PrintAvailableCommand()
        {
            Console.WriteLine("Try again. Available command:");
            Console.WriteLine($"1){firstCommand} 2){secondCommand} 3){thirdCommand} 4){fourthCommand} <type>.");
        }
    }
}
