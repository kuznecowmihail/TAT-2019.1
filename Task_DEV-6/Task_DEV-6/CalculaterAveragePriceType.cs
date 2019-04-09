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
        /// <returns>Average price</returns>
        public int CalculateAveragePriceType(string brand)
        {
            int allPrice = 0;
            int allNumber = 0;
            bool existence = false;

            foreach(var i in Cars)
            {
                if(i.Brand == brand)
                {
                    allPrice += i.Price * i.Number;
                    allNumber += i.Number;
                    existence = true;
                }
            }

            return existence != false ? allPrice / allNumber : 0;
        }
    }
}
