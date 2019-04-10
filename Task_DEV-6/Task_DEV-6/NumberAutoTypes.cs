using System;
using System.Linq;
using System.Collections.Generic;

namespace Task_DEV_6
{
    /// <summary>
    /// Class calculates and displays number of type.
    /// </summary>
    public class NumberAutoTypes
    {
        List<Auto> Autos { get; }
        String Type { get; }

        /// <summary>
        /// Constructor of NumberAutoTypes.
        /// </summary>
        /// <param name="autos"></param>
        /// <param name="type">Type of auto</param>
        public NumberAutoTypes(List<Auto> autos, string type)
        {
            Autos = autos;
            Type = type;
        }

        /// <summary>
        /// Method returns number of auto types.
        /// </summary>
        /// <returns>number of car types</returns>
        public int GetNumberAutoTypes() => Autos.GroupBy(t => t.Brand).Count();

        /// <summary>
        /// Method displays information about number of auto types.
        /// </summary>
        public void DisplayNumberCarTypes() => Console.WriteLine(
            GetNumberAutoTypes() == 0 
            ? "The XML file hasn't autos." 
            : $"Number of {Type} types is {GetNumberAutoTypes()}");
    }
}
