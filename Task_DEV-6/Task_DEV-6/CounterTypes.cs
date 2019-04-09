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
        /// Method counts number of types.
        /// </summary>
        /// <returns>Number of brend</returns>
        public int CountTypes() => Cars.GroupBy(t => t.Brand).Count();
    }
}
