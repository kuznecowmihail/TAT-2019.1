using System;
using System.Linq;
using System.Collections.Generic;

namespace Task_DEV_6
{
    /// <summary>
    /// Class calculate average price.
    /// </summary>
    public class CalculaterAveragePrice
    {
        List<Car> Cars { get; }

        /// <summary>
        /// Constructor of CalculaterAveragePrice.
        /// </summary>
        /// <param name="cars"></param>
        public CalculaterAveragePrice(List<Car> cars) => Cars = cars;

        /// <summary>
        /// Method displays information about average price.
        /// </summary>
        public void DisplayAveragePrice()
        {
            int averagePrice = Cars.Sum(t => t.Number) > 0
            ? Cars.Sum(t => t.Price * t.Number) / Cars.Sum(t => t.Number)
            : 0;
            if (averagePrice == 0)
            {
                Console.WriteLine("The XML file hasn't cars.");
            }
            else
            {
                Console.WriteLine($"The average price of all cars is {averagePrice}");
            }
        }
    }
}
