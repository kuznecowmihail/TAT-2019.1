namespace Task_DEV_6
{
    /// <summary>
    /// Child class for pattern command calls method to calculate average price of type cars.
    /// </summary>
    public class CalculaterAveragePricaTypeOnCommand : ICommand
    {
        CarsHandler carsHead;

        /// <summary>
        /// Constructor of CalculaterAveragePricaTypeOnCommand.
        /// </summary>
        /// <param name="cars"></param>
        public CalculaterAveragePricaTypeOnCommand(CarsHandler cars) => carsHead = cars;

        /// <summary>
        /// Implemented method. 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int Calculate(string type) => carsHead.CalculateAveragePricaType(type);
    }
}
