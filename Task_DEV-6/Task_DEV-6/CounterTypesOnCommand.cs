namespace Task_DEV_6
{
    /// <summary>
    /// Child class for pattern command calls method to count number of all car types.
    /// </summary>
    public class CounterTypesOnCommand : ICommand
    {
        CarsHandler carsHead;

        /// <summary>
        /// Constructor of CounterTypesOnCommand.
        /// </summary>
        /// <param name="cars"></param>
        public CounterTypesOnCommand(CarsHandler cars) => carsHead = cars;

        /// <summary>
        /// Implemented method. 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int Calculate(string type) => carsHead.CountTypes();
    }
}
