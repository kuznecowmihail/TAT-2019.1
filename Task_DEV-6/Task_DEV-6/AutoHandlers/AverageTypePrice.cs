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
        string AutoBrand { get; set; }
        int AveragePrice { get; set; }
        // string - name of type and list of this type.
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
        public int GetAveragePriceType()
        {
            foreach (var auto in Autos)
            {
                if (auto.Key == AutoType)
                {
                    return auto.Value.Where(t => t.Brand.Equals(AutoBrand)).Sum(t => t.Number) > 0
                        ? auto.Value.Where(t => t.Brand.Equals(AutoBrand)).Sum(t => t.Price * t.Number) / auto.Value.Where(t => t.Brand.Equals(AutoBrand)).Sum(t => t.Number)
                        : 0;
                }
            }

            return 0;
        }

        /// <summary>
        /// Method displays information about average auto price.
        /// </summary>
        /// <param name="brand"></param>
        public void DisplayAveragePriceType() => Console.WriteLine(
            AveragePrice == 0
            ? $"->The XML file hasn't {AutoType} of '{AutoBrand}' brand."
            : $"->The average price of '{AutoBrand}' {AutoType} is {AveragePrice}");

        /// <summary>
        /// Method returns list of available auto types.
        /// </summary>
        /// <returns>list of types</returns>
        public List<string> GetAutoTypes()
        {
            List<string> autoTypes = new List<string>();

            foreach (var autoType in Autos.Keys)
            {
                autoTypes.Add(autoType);
            }

            return autoTypes;
        }

        /// <summary>
        /// Method sets properties of auto.
        /// </summary>
        /// <param name="autoType"></param>
        /// <param name="autoModel"></param>
        public void SetProperties(string autoType, string autoModel)
        {
            this.AutoType = autoType;
            this.AutoBrand = autoModel;
            this.AveragePrice = GetAveragePriceType();
        }
    }
}
