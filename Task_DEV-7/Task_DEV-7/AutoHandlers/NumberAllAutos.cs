using System;
using System.Linq;
using System.Collections.Generic;

namespace Task_DEV_7
{
    /// <summary>
    /// Class calculates and displays number of all auto.
    /// </summary>
    public class NumberAllAutos
    {
        string AutoType { get; set; }
        string AutoBrand { get; set; }
        int NumberAutos { get; set; }
        // string - name of type and list of this type.
        Dictionary<string, IEnumerable<Auto>> Autos { get; }

        /// <summary>
        /// Constructor of NumberAllAutos.
        /// </summary>
        /// <param name="autos"></param>
        public NumberAllAutos(Dictionary<string, IEnumerable<Auto>> autos)
        {
            this.Autos = autos;
        }

        /// <summary>
        /// Method returns number of all autos.
        /// </summary>
        /// <returns>number of all autos</returns>
        public int GetNumberAllAutos()
        {
            foreach (var auto in Autos)
            {
                if (auto.Key == AutoType)
                {
                    return auto.Value.Sum(t => t.Number);
                }
            }

            return 0;
        }

        /// <summary>
        /// Method displays information about number of all autos.
        /// </summary>
        public void DisplayNumberAllCars() => Console.WriteLine(
            NumberAutos == 0
            ? $"->The XML file hasn't {AutoType}."
            : $"->Number of all {AutoType} is {NumberAutos}");

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
            this.NumberAutos = GetNumberAllAutos();
        }
    }
}