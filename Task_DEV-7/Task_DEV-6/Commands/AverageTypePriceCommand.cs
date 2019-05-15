using System.Collections.Generic;

namespace Task_DEV_6
{
    /// <summary>
    /// Child class for pattern command calls method to calculate average price of auto type.
    /// </summary>
    public class AverageTypePriceCommand : ICommand
    {
        AverageTypePrice AverageTypePrice { get; }

        /// <summary>
        /// Constructor of AverageTypePriceCommand.
        /// </summary>
        /// <param name="averageTypePrice"></param>
        public AverageTypePriceCommand(AverageTypePrice averageTypePrice)
        {
            this.AverageTypePrice = averageTypePrice;
        }

        /// <summary>
        /// Implemented method. 
        /// </summary>
        /// <param name="type"></param>
        public void DisplayInformation() => AverageTypePrice.DisplayAveragePriceType();

        /// <summary>
        /// Implemented method. 
        /// </summary>
        public List<string> GetAutoTypes() => AverageTypePrice.GetAutoTypes();

        /// <summary>
        /// Implemented method. 
        /// </summary>
        public void SetProperties(string autoType, string autoBrand) => AverageTypePrice.SetProperties(autoType, autoBrand);
    }
}
