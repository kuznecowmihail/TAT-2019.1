namespace Task_DEV_6
{
    /// <summary>
    /// Child class for pattern command calls method to calculate average price all cars.
    /// </summary>
    public class AverageCarPriceCommand : ICommand
    {
        AverageCarPrice AverageCarsPrice { get; }

        /// <summary>
        /// Constructor of AverageCarPriceCommand.
        /// </summary>
        /// <param name="averageCarPrice"></param>
        public AverageCarPriceCommand(AverageCarPrice averageCarPrice) => AverageCarsPrice = averageCarPrice;

        /// <summary>
        /// Implemented method. 
        /// </summary>
        /// <param name="type"></param>
        public void DisplayInformation(string type) => AverageCarsPrice.DisplayAveragePrice();
    }
}
