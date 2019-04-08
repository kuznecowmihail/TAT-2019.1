namespace Task_DEV_6
{
    /// <summary>
    /// Child class for pattern command calls method to count number of all cars.
    /// </summary>
    public class CounterAllCarsCommand : ICommand
    {
        CounterAllCars counterAllCars;

        /// <summary>
        /// Constructor of CounterAllCarsonCommand.
        /// </summary>
        /// <param name="cars"></param>
        public CounterAllCarsCommand(CounterAllCars counter) => counterAllCars = counter;

        /// <summary>
        /// Implemented method. 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int Calculate(string type) => counterAllCars.CountAllCars();
    }
}
