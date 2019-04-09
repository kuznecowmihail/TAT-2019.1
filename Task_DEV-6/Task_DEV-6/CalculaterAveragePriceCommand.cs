using System;

namespace Task_DEV_6
{
    /// <summary>
    /// Child class for pattern command calls method to calculate average price all cars.
    /// </summary>
    public class CalculaterAveragePriceCommand : ICommand
    {
        CalculaterAveragePrice CalculaterAveragePrice { get; }

        /// <summary>
        /// Constructor of CalculaterAveragePricaOnCommand.
        /// </summary>
        /// <param name="calculater"></param>
        public CalculaterAveragePriceCommand(CalculaterAveragePrice calcualater) => CalculaterAveragePrice = calcualater;

        /// <summary>
        /// Implemented method. 
        /// </summary>
        /// <param name="type"></param>
        /// <returns>Average price</returns>
        public int Calculate(string type)
        {
            DisplayInformation(CalculaterAveragePrice.CalculateAveragePrice());

            return CalculaterAveragePrice.CalculateAveragePrice();
        }

        /// <summary>
        /// Method displays information if average pris is 0.
        /// </summary>
        /// <param name="price"></param>
        public void DisplayInformation(int price)
        {
            if (price == 0)
            {
                Console.Write("XML files hasn't cars - ");
            }
        }
    }
}
