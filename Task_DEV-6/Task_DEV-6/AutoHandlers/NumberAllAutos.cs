using System;
using System.Linq;
using System.Collections.Generic;

namespace Task_DEV_6
{
    /// <summary>
    /// Class calculates and displays number of all auto.
    /// </summary>
    public class NumberAllAutos
    {
        string AutoType { get; set; }
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
            GetNumberAllAutos() == 0
            ? $"->The XML file hasn't {AutoType}."
            : $"->Number of all {AutoType} is {GetNumberAllAutos()}");

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
        /// Method returns true if the type of auto exists
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
