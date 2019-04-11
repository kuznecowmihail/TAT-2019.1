using System;
using System.Linq;
using System.Collections.Generic;

namespace Task_DEV_6
{
    /// <summary>
    /// Class calculates and displays average price.
    /// </summary>
    public class AverageCarPrice
    {
        List<Car> Cars { get; }

        /// <summary>
        /// Constructor of AverageCarPrice.
        /// </summary>
        /// <param name="cars"></param>
        public AverageCarPrice(List<Car> cars)
        {
            this.Cars = cars;
        }

        /// <summary>
        /// Method returns average price.
        /// </summary>
        /// <returns>Average price</returns>
        public int GetAveragePrice() => Cars.Sum(t => t.Number) > 0
            ? Cars.Sum(t => t.Price * t.Number) / Cars.Sum(t => t.Number)
            : 0;

        /// <summary>
        /// Method displays information about average price.
        /// </summary>
        public void DisplayAveragePrice() => Console.WriteLine(
            GetAveragePrice() == 0 
            ? "The XML file hasn't cars." 
            : $"The average price of all cars is {GetAveragePrice()}");
    }
}
