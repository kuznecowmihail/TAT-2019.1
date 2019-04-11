using System;
using System.Linq;
using System.Collections.Generic;

namespace Task_DEV_6
{
    /// <summary>
    /// Class calculates and displays average type price .
    /// </summary>
    public class AverageTypePrice
    {
        IEnumerable<Auto> Autos { get; }

        /// <summary>
        /// Constructor of AverageTypePrice.
        /// </summary>
        /// <param name="autos"></param>
        public AverageTypePrice(IEnumerable<Auto> autos)
        {
            this.Autos = autos;
        }

        /// <summary>
        /// Method returns average price type.
        /// </summary>
        /// <param name="brand"></param>
        /// <returns>Average price type</returns>
        public int GetAveragePriceType(string brand) => Autos.Where(t => t.Brand.Equals(brand)).Sum(t => t.Number) > 0
            ? Autos.Where(t => t.Brand.Equals(brand)).Sum(t => t.Price * t.Number) / Autos.Where(t => t.Brand.Equals(brand)).Sum(t => t.Number)
            : 0;

        /// <summary>
        /// Method displays information about average auto price.
        /// </summary>
        /// <param name="brand"></param>
        public void DisplayAveragePriceType(string brand) => Console.WriteLine(
            GetAveragePriceType(brand) == 0 
            ? "The XML file hasn't autos of this brand." 
            : $"The average price of {brand} autos is {GetAveragePriceType(brand)}");
    }
}
