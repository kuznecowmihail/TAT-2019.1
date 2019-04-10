namespace Task_DEV_6
{
    /// <summary>
    /// Child class for pattern command calls method to count number of all cars.
    /// </summary>
    public class CounterAllCarsCommand : ICommand
    {
        CounterAllCars CounterAllCars { get; }

        /// <summary>
        /// Constructor of CounterAllCarsonCommand.
        /// </summary>
        /// <param name="counter"></param>
        public CounterAllCarsCommand(CounterAllCars counter) => CounterAllCars = counter;

        /// <summary>
        /// Implemented method. 
        /// </summary>
        /// <param name="type"></param>
        /// <returns>Count of all cars</returns>
        public void DisplayInformation(string type)
        {
            CounterAllCars.DisplayCountAllCars();
        }
    }
}
