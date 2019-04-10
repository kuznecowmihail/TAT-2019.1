using System;
using System.Linq;
using System.Collections.Generic;

namespace Task_DEV_6
{
    /// <summary>
    /// Class calculate count of type.
    /// </summary>
    public class CounterTypes
    {
        List<Car> Cars { get; }

        /// <summary>
        /// Constructor of CounterTypes.
        /// </summary>
        /// <param name="cars"></param>
        public CounterTypes(List<Car> cars) => Cars = cars;

        /// <summary>
        /// Method displays information about type count.
        /// </summary>
        public void DisplayCountTypes()
        {
            int countTypes = Cars.GroupBy(t => t.Brand).Count();
            if (countTypes == 0)
            {
                Console.WriteLine("The XML file hasn't cars.");
            }
            else
            {
                Console.WriteLine($"Number of car types is {countTypes}");
            }
        }
    }
}
