using System;
using System.Linq;
using System.Collections.Generic;

namespace Task_DEV_6
{
    /// <summary>
    /// Class calculates and displays count of all auto.
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
            foreach (var i in Autos)
            {
                if (i.Key == AutoType)
                {
                    return i.Value.Sum(t => t.Number);
                }
            }
            return 0;
        }

        /// <summary>
        /// Method displays information about number of all autos.
        /// </summary>
        public void DisplayNumberAllCars() => Console.WriteLine(
            GetNumberAllAutos() == 0
            ? "The XML file hasn't autos."
            : $"Number of all {AutoType} is {GetNumberAllAutos()}");

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
