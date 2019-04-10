using System;
using System.Linq;
using System.Collections.Generic;

namespace Task_DEV_6
{
    /// <summary>
    /// Class calculates and displays count of all car.
    /// </summary>
    public class NumberAllCars
    {
        List<Auto> Cars { get; }

        /// <summary>
        /// Constructor of NumberAllCars.
        /// </summary>
        /// <param name="cars"></param>
        public NumberAllCars(List<Auto> cars) => Cars = cars;

        /// <summary>
        /// Method returns number of all cars.
        /// </summary>
        /// <returns>number of all cars</returns>
        public int GetNumberAllCars() => Cars.Sum(t => t.Number);

        /// <summary>
        /// Method displays information about number of all cars.
        /// </summary>
        public void DisplayNumberAllCars() => Console.WriteLine(
            GetNumberAllCars() == 0 
            ? "The XML file hasn't cars." 
            : $"Number of all cars is {GetNumberAllCars()}");
    }
}
