using System;

namespace Task_DEV_6
{
    /// <summary>
    /// Child class for pattern command calls method to calculate average price of type cars.
    /// </summary>
    public class CalculaterAveragePriceTypeCommand : ICommand
    {
        CalculaterAveragePriceType CalculaterAveragePricaType { get; }

        /// <summary>
        /// Constructor of CalculaterAveragePricaTypeOnCommand.
        /// </summary>
        /// <param name="calculater"></param>
        public CalculaterAveragePriceTypeCommand(CalculaterAveragePriceType calculater) => CalculaterAveragePricaType = calculater;

        /// <summary>
        /// Implemented method. 
        /// </summary>
        /// <param name="type"></param>
        /// <returns>Average price of all type cars</returns>
        public int Calculate(string type)
        {
            DisplayInformation(CalculaterAveragePricaType.CalculateAveragePriceType(type), type);

            return CalculaterAveragePricaType.CalculateAveragePriceType(type);
        }

        /// <summary>
        /// Method displays information if average pris is 0.
        /// </summary>
        /// <param name="price"></param>
        /// <param name="brand"></param>
        public void DisplayInformation(int price, string brand)
        {
            if(price == 0)
            {
                Console.Write($"XML file hasn't {brand} cars - ");
            }
        }
    }
}
