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
        /// <param name=name of XML></param>
        public CounterAllCars(List<Car> cars) => Cars = cars;

        /// <summary>
        /// Method counts number of all cars.
        /// </summary>
        /// <returns></returns>
        public int CountAllCars()
        {
            int number = 0;

            foreach(var i in Cars)
            {
                number += i.Number;
            }

            return number;
        }
    }
}
