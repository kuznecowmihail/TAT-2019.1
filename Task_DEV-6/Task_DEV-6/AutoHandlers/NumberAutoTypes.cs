using System;
using System.Linq;
using System.Collections.Generic;

namespace Task_DEV_6
{
    /// <summary>
    /// Class calculates and displays number of auto type.
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
            foreach (var auto in Autos)
            {
                if (auto.Key == AutoType)
                {
                    return auto.Value.GroupBy(t => t.Brand).Count();
                }
            }

            return 0;
        }

        /// <summary>
        /// Method displays information about number of auto types.
        /// </summary>
        public void DisplayNumberCarTypes() => Console.WriteLine(
            GetNumberAutoTypes() == 0
            ? $"->The XML file hasn't {AutoType}."
            : $"->Number of {AutoType} types is {GetNumberAutoTypes()}");

        /// <summary>
        /// Metod displays auto types.
        /// </summary>
        public void DisplayAutoTypes()
        {
            foreach(var auto in Autos)
            {
                Console.WriteLine($"-{auto.Key}");
            }
        }

        /// <summary>
        /// Method returns true if the type of auto exists
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool DoesTypeContain(string type)
        {
            AutoType = Autos.Keys.Where(t => t == (type)).Count() > 0 ? type : string.Empty;
            return Autos.Keys.Where(t => t == (type)).Count() > 0;
        }
    }
}
