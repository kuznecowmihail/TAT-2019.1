using System;
using System.Linq;
using System.Collections.Generic;

namespace Task_DEV_6
{
    /// <summary>
    /// Class calculate average price of type.
    /// </summary>
    public class AveragePriceType
    {
        List<Car> Cars { get; }

        /// <summary>
        /// Constructor of AveragePriceType.
        /// </summary>
        /// <param name="cars"></param>
        public AveragePriceType(List<Car> cars) => Cars = cars;

        /// <summary>
        /// Method returns average price type.
        /// </summary>
        /// <param name="brand"></param>
        /// <returns>Average price type</returns>
        public int GetAveragePriceType(string brand) => Cars.Where(t => t.Brand.Equals(brand)).Sum(t => t.Number) > 0
            ? Cars.Where(t => t.Brand.Equals(brand)).Sum(t => t.Price * t.Number) / Cars.Where(t => t.Brand.Equals(brand)).Sum(t => t.Number)
            : 0;

        /// <summary>
        /// Method displays information about average car price.
        /// </summary>
        /// <param name="brand"></param>
        public void DisplayAveragePriceType(string brand) => Console.WriteLine(
            GetAveragePriceType(brand) == 0 
            ? "The XML file hasn't cars of this brand." 
            : $"The average price of {brand} is {GetAveragePriceType(brand)}");
    }
}
