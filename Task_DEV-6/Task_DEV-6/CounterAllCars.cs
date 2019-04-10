using System;
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
        /// Method displays information about count all cars.
        /// </summary>
        public void DisplayCountAllCars()
        {
            int countAllCars = Cars.Sum(t => t.Number);
            if (countAllCars == 0)
            {
                Console.WriteLine("The XML file hasn't cars.");
            }
            else
            {
                Console.WriteLine($"Number of all cars is {countAllCars}");
            }
        }
    }
}
