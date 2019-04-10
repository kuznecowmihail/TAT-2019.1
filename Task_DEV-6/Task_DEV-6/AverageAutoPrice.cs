using System;
using System.Linq;
using System.Collections.Generic;

namespace Task_DEV_6
{
    /// <summary>
    /// Class calculates and displays average price.
    /// </summary>
    public class AverageAutoPrice
    {
        List<Auto> Autos { get; }

        /// <summary>
        /// Constructor of AverageAutoPrice.
        /// </summary>
        /// <param name="autos"></param>
        public AverageAutoPrice(List<Auto> autos) => Autos = autos;

        /// <summary>
        /// Method returns average price.
        /// </summary>
        /// <returns>Average price</returns>
        public int GetAveragePrice() => Autos.Sum(t => t.Number) > 0
            ? Autos.Sum(t => t.Price * t.Number) / Autos.Sum(t => t.Number)
            : 0;

        /// <summary>
        /// Method displays information about average price.
        /// </summary>
        public void DisplayAveragePrice() => Console.WriteLine(
            GetAveragePrice() == 0 
            ? "The XML file hasn't autos." 
            : $"The average price of all {Autos[0].Type} is {GetAveragePrice()}");
    }
}
