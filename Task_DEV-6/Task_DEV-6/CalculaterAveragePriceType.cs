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
        /// <param name=name of XML></param>
        public CalculaterAveragePriceType(List<Car> cars) => Cars = cars;

        /// <summary>
        /// Method calculates average price of one of car type.
        /// </summary>
        /// <param name="type">Model of car</param>
        /// <returns></returns>
        public int CalculateAveragePriceType(string type)
        {
            int allPrice = 0;
            int allNumber = 0;
            bool existence = false;

            foreach(var i in Cars)
            {
                if(i.Brand == type)
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
