namespace Task_DEV_6
{
    /// <summary>
    /// Child class for pattern command calls method to calculate average price all cars.
    /// </summary>
    public class CalculaterAveragePriceCommand : ICommand
    {
        CalculaterAveragePrice CalculaterAveragePrice { get; }

        /// <summary>
        /// Constructor of CalculaterAveragePricaOnCommand.
        /// </summary>
        /// <param name="cars"></param>
        public CalculaterAveragePriceCommand(CalculaterAveragePrice calcualater) => CalculaterAveragePrice = calcualater;

        /// <summary>
        /// Implemented method. 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int Calculate(string type) => CalculaterAveragePrice.CalculateAveragePrice();
    }
}
