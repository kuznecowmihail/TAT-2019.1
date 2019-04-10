using System;
using System.Linq;
using System.Collections.Generic;

namespace Task_DEV_6
{
    /// <summary>
    /// Class calculates and displays count of type.
    /// </summary>
    public class NumberCarTypes
    {
        List<Auto> Cars { get; }

        /// <summary>
        /// Constructor of NumberCarTypes.
        /// </summary>
        /// <param name="cars"></param>
        public NumberCarTypes(List<Auto> cars) => Cars = cars;

        /// <summary>
        /// Method returns number of car types.
        /// </summary>
        /// <returns>number of car types</returns>
        public int GetNumberCarTypes() => Cars.GroupBy(t => t.Brand).Count();

        /// <summary>
        /// Method displays information about number of car types.
        /// </summary>
        public void DisplayNumberCarTypes() => Console.WriteLine(
            GetNumberCarTypes() == 0 
            ? "The XML file hasn't cars." 
            : $"Number of car types is {GetNumberCarTypes()}");
    }
}
