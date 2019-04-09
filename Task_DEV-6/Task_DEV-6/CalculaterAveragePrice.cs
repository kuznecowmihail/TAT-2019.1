using System.Linq;
using System.Collections.Generic;

namespace Task_DEV_6
{
    /// <summary>
    /// Class calculate average price.
    /// </summary>
    public class CalculaterAveragePrice
    {
        List<Car> Cars { get; }

        /// <summary>
        /// Constructor of CalculaterAveragePrice.
        /// </summary>
        /// <param name="cars"></param>
        public CalculaterAveragePrice(List<Car> cars) => Cars = cars;

        /// <summary>
        /// Method calculate average price of all cars.
        /// </summary>
        /// <returns>Average price of all cars = countbrand*price*number/allnumber</returns>
        public int CalculateAveragePrice() 
            => Cars.Sum(t => t.Number) > 0 
            ? Cars.Sum(t => t.Price * t.Number) / Cars.Sum(t => t.Number) 
            : 0;
    }
}
