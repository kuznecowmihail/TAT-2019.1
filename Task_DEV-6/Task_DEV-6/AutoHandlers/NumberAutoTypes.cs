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
        string AutoType { get; set; }
        Dictionary<string, IEnumerable<Auto>> Autos { get; }

        /// <summary>
        /// Constructor of NumberAutoTypes.
        /// </summary>
        /// <param name="autos"></param>
        public NumberAutoTypes(Dictionary<string, IEnumerable<Auto>> autos)
        {
            this.Autos = autos;
        }

        /// <summary>
        /// Method returns number of auto types.
        /// </summary>
        /// <returns>number of car types</returns>
        public int GetNumberAutoTypes()
        {
            foreach (var i in Autos)
            {
                if (i.Key == AutoType)
                {
                    return i.Value.GroupBy(t => t.Brand).Count();
                }
            }
            return 0;
        }

        /// <summary>
        /// Method displays information about number of auto types.
        /// </summary>
        public void DisplayNumberCarTypes() => Console.WriteLine(
            GetNumberAutoTypes() == 0
            ? "The XML file hasn't autos."
            : $"Number of {AutoType} types is {GetNumberAutoTypes()}");

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
