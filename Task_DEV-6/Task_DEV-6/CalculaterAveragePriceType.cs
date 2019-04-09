using System.Linq;
using System.Collections.Generic;

namespace Task_DEV_6
{
    /// <summary>
    /// Class calculate average price of type.
    /// </summary>
    public class CalculaterAveragePriceType
    {
        List<Car> Cars { get; }

        /// <summary>
        /// Constructor of CalculaterAveragePriceType.
        /// </summary>
        /// <param name="cars"></param>
        public CalculaterAveragePriceType(List<Car> cars) => Cars = cars;

        /// <summary>
        /// Method calculates average price of one of car type.
        /// </summary>
        /// <param name="brand">Model of car</param>
        /// <returns>Average type price = countbrand*price*number/allnumber</returns>
        public int CalculateAveragePriceType(string brand)
            => Cars.Where(t => t.Brand.Equals(brand)).Sum(t => t.Number) > 0 
            ? Cars.Where(t => t.Brand.Equals(brand)).Sum(t => t.Price * t.Number) / Cars.Where(t => t.Brand.Equals(brand)).Sum(t => t.Number)
            : 0;
    }
}
