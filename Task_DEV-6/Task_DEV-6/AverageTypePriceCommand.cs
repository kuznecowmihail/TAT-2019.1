namespace Task_DEV_6
{
    /// <summary>
    /// Child class for pattern command calls method to calculate average price of type cars.
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
        public void DisplayInformation(string type) => AverageTypePrice.DisplayAveragePriceType(type);
    }
}
