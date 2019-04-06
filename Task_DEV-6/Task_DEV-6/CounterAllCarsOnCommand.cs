namespace Task_DEV_6
{
    /// <summary>
    /// Child class for pattern command calls method to count all cars.
    /// </summary>
    public class CounterAllCarsOnCommand : ICommand
    {
        CarsHandler carsHead;

        /// <summary>
        /// Constructor of CounterAllCarsonCommand.
        /// </summary>
        /// <param name="cars"></param>
        public CounterAllCarsOnCommand(CarsHandler cars) => carsHead = cars;

        /// <summary>
        /// Implemented method. 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int Calculate(string type) => carsHead.CountAllCars();
    }
}
