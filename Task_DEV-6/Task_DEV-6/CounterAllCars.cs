using System.Linq;
using System.Collections.Generic;

namespace Task_DEV_6
{
    /// <summary>
    /// Class calculate count of all car.
    /// </summary>
    public class CounterAllCars
    {
        List<Car> Cars { get; }

        /// <summary>
        /// Constructor of CounterAllCars.
        /// </summary>
        /// <param name="cars"></param>
        public CounterAllCars(List<Car> cars) => Cars = cars;

        /// <summary>
        /// Method counts number of all cars.
        /// </summary>
        /// <returns>Count of all cars</returns>
        public int CountAllCars() => Cars.Select(t => t.Number).Sum();
    }
}
