using System;
using System.Linq;
using System.Collections.Generic;

namespace Task_DEV_6
{
    /// <summary>
    /// Class calculates and displays average type price of auto.
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
            foreach (var auto in Autos)
            {
                if (auto.Key == AutoType)
                {
                    return auto.Value.Where(t => t.Brand.Equals(brand)).Sum(t => t.Number) > 0
                        ? auto.Value.Where(t => t.Brand.Equals(brand)).Sum(t => t.Price * t.Number) / auto.Value.Where(t => t.Brand.Equals(brand)).Sum(t => t.Number)
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
            ? $"->The XML file hasn't {AutoType} of '{brand}' brand."
            : $"->The average price of '{brand}' {AutoType} is {GetAveragePriceType(brand)}");

        /// <summary>
        /// Metod displays auto types.
        /// </summary>
        public void DisplayAutoTypes()
        {
            foreach (var auto in Autos)
            {
                Console.WriteLine($"-{auto.Key}");
            }
        }

        /// <summary>
        /// Method returns true if the type of auto exists.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool DoesTypeContain(string type)
        {
            AutoType = Autos.Keys.Where(t => t == type).Count() > 0 ? type : string.Empty;
            return Autos.Keys.Where(t => t == type).Count() > 0;
        }
    }
}
