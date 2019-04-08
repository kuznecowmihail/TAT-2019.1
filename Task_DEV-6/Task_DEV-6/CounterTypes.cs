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
        /// <param name=name of XML></param>
        public CounterTypes(List<Car> cars) => Cars = cars;

        /// <summary>
        /// Method counts number of types.
        /// </summary>
        /// <returns>Number of brend</returns>
        public int CountTypes()
        {
            // Add list to save different brend.
            List<string> model = new List<string>();

            foreach(var i in Cars)
            {
                if(!model.Contains(i.Brand))
                {
                    model.Add(i.Brand);
                }
            }

            return model.Count;
        }
    }
}
