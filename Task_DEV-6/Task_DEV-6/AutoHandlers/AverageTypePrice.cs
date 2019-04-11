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
        string AutoType { get; set; }
        Dictionary<string, IEnumerable<Auto>> Autos { get; }

        /// <summary>
        /// Constructor of AverageTypePrice.
        /// </summary>
        /// <param name="autos"></param>
        public AverageTypePrice(Dictionary<string, IEnumerable<Auto>> autos)
        {
            this.Autos = autos;
        }

        /// <summary>
        /// Method returns average price type.
        /// </summary>
        /// <param name="brand"></param>
        /// <returns>Average price type</returns>
        public int GetAveragePriceType(string brand)
        {
            foreach (var i in Autos)
            {
                if (i.Key == AutoType)
                {
                    return i.Value.Where(t => t.Brand.Equals(brand)).Sum(t => t.Number) > 0
                        ? i.Value.Where(t => t.Brand.Equals(brand)).Sum(t => t.Price * t.Number) / i.Value.Where(t => t.Brand.Equals(brand)).Sum(t => t.Number)
                        : 0;
                }
            }
            return 0;
        }

        /// <summary>
        /// Method displays information about average auto price.
        /// </summary>
        /// <param name="brand"></param>
        public void DisplayAveragePriceType(string brand) => Console.WriteLine(
            GetAveragePriceType(brand) == 0
            ? "The XML file hasn't autos of this brand."
            : $"The average price of {brand} {AutoType} is {GetAveragePriceType(brand)}");

        /// <summary>
        /// Method returns true if the type of auto existences.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool IsContains(string type)
        {
            AutoType = Autos.Keys.Where(t => t == (type)).Count() > 0 ? type : string.Empty;
            return Autos.Keys.Where(t => t == (type)).Count() > 0;
        }
    }
}
