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
        /// <param name=name of XML></param>
        public CalculaterAveragePrice(List<Car> cars) => Cars = cars;

        /// <summary>
        /// Method calculate average price of all cars.
        /// </summary>
        /// <returns></returns>
        public int CalculateAveragePrice()
        {
            int allPrice = 0;
            int allNumber = 0;

            foreach(var i in Cars)
            {
                allPrice += i.Price * i.Number;
                allNumber += i.Number;
            }

            return allPrice / allNumber;
        }
    }
}
