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
        List<Auto> Autos { get; }
        String Type { get; }

        /// <summary>
        /// Constructor of NumberAllAutos.
        /// </summary>
        /// <param name="autos"></param>
        /// <param name="type">Type of auto</param>
        public NumberAllAutos(List<Auto> autos, string type)
        {
            Autos = autos;
            Type = type;
        }

        /// <summary>
        /// Method returns number of all autos.
        /// </summary>
        /// <returns>number of all autos</returns>
        public int GetNumberAllAutos() => Autos.Sum(t => t.Number);

        /// <summary>
        /// Method displays information about number of all autos.
        /// </summary>
        public void DisplayNumberAllCars() => Console.WriteLine(
            GetNumberAllAutos() == 0 
            ? "The XML file hasn't autos." 
            : $"Number of all {Type} is {GetNumberAllAutos()}");
    }
}
