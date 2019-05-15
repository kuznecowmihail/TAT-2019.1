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
        int AveragePrice { get; set; }

        /// <summary>
        /// Constructor of AverageCarPrice.
        /// </summary>
        /// <param name="cars"></param>
        public AverageCarPrice(List<Car> cars)
        {
            this.Cars = cars;
            this.AveragePrice = 0;
        }

        /// <summary>
        /// Method returns average price.
        /// </summary>
        /// <returns>Average price</returns>
        public int GetAveragePrice()
        {
            if(Cars.Sum(t => t.Number) > 0 && AveragePrice == 0)
            {
                return AveragePrice = Cars.Sum(t => t.Price * t.Number) / Cars.Sum(t => t.Number);
            }
            else
            {
                return AveragePrice;
            }
        }

        /// <summary>
        /// Method displays information about average price.
        /// </summary>
        public void DisplayAveragePrice() => Console.WriteLine(
            GetAveragePrice() == 0 
            ? "->The XML file hasn't cars." 
            : $"->The average price of all cars is {GetAveragePrice()}");
    }
}
