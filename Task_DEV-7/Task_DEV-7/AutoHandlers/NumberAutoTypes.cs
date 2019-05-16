using System;
using System.Linq;
using System.Collections.Generic;

namespace Task_DEV_7
{
    /// <summary>
    /// Class calculates and displays number of auto type.
    /// </summary>
    public class NumberAutoTypes
    {
        string AutoType { get; set; }
        string AutoBrand { get; set; }
        int NumberTypes { get; set; }
        // string - name of type and list of this type.
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
            NumberTypes == 0
            ? $"->The XML file hasn't {AutoType}."
            : $"->Number of {AutoType} types is {NumberTypes}");

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
            this.NumberTypes = GetNumberAutoTypes();
        }
    }
}