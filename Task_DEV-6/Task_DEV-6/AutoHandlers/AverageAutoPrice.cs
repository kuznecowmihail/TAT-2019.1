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
        string AutoType { get; set; }
        Dictionary<string, IEnumerable<Auto>> Autos { get; }

        /// <summary>
        /// Constructor of AverageAutoPrice.
        /// </summary>
        /// <param name="autos"></param>
        public AverageAutoPrice(Dictionary<string, IEnumerable<Auto>> autos)
        {
            this.Autos = autos;
        }

        /// <summary>
        /// Method returns average price.
        /// </summary>
        /// <returns>Average price</returns>
        public int GetAveragePrice()
        {
            foreach (var i in Autos)
            {
                if (i.Key == AutoType)
                {
                    return i.Value.Sum(t => t.Number) > 0
                        ? i.Value.Sum(t => t.Price * t.Number) / i.Value.Sum(t => t.Number)
                        : 0;
                }
            }

            return 0;
        }

        /// <summary>
        /// Method displays information about average price.
        /// </summary>
        public void DisplayAveragePrice() => Console.WriteLine(
            GetAveragePrice() == 0
            ? $"->The XML file hasn't {AutoType}."
            : $"->The average price of all {AutoType} is {GetAveragePrice()}");

        /// <summary>
        /// Metod displays auto types.
        /// </summary>
        public void DisplayAutoTypes()
        {
            foreach (var i in Autos)
            {
                Console.WriteLine($"-{i.Key}");
            }
        }

        /// <summary>
        /// Method returns true if the type of auto existences
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
