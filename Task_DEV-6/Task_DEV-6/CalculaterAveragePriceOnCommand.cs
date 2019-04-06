namespace Task_DEV_6
{
    /// <summary>
    /// Child class for pattern command calls method to calculate average price all cars.
    /// </summary>
    public class CalculaterAveragePriceOnCommand : ICommand
    {
        CarsHandler carsHead;

        /// <summary>
        /// Constructor of CalculaterAveragePricaOnCommand.
        /// </summary>
        /// <param name="cars"></param>
        public CalculaterAveragePriceOnCommand(CarsHandler cars) => carsHead = cars;

        /// <summary>
        /// Implemented method. 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int Calculate(string type) => carsHead.CalculateAveragePrice();
    }
}
