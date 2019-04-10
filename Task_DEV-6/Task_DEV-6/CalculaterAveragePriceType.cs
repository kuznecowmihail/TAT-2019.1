using System;
using System.Linq;
using System.Collections.Generic;

namespace Task_DEV_6
{
    /// <summary>
    /// Class calculate average price of type.
    /// </summary>
    public class CalculaterAveragePriceType
    {
        List<Car> Cars { get; }

        /// <summary>
        /// Constructor of CalculaterAveragePriceType.
        /// </summary>
        /// <param name="cars"></param>
        public CalculaterAveragePriceType(List<Car> cars) => Cars = cars;

        /// <summary>
        /// Method displays information about average car price.
        /// </summary>
        /// <param name="brand"></param>
        public void DisplayAveragePriceType(string brand)
        {
            int averagePriceType = Cars.Where(t => t.Brand.Equals(brand)).Sum(t => t.Number) > 0
            ? Cars.Where(t => t.Brand.Equals(brand)).Sum(t => t.Price * t.Number) / Cars.Where(t => t.Brand.Equals(brand)).Sum(t => t.Number)
            : 0;
            if (averagePriceType == 0)
            {
                Console.WriteLine("The XML file hasn't cars of this brand.");
            }
            else
            {
                Console.WriteLine($"The average price of {brand} is {averagePriceType}");
            }
        }
    }
}
