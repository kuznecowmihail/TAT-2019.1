namespace Task_DEV_6
{
    /// <summary>
    /// Child class for pattern command calls method to count number of all car types.
    /// </summary>
    public class CounterTypesCommand : ICommand
    {
        CounterTypes CounterTypes { get; }

        /// <summary>
        /// Constructor of CounterTypesOnCommand.
        /// </summary>
        /// <param name="cars"></param>
        public CounterTypesCommand(CounterTypes counter) => CounterTypes = counter;

        /// <summary>
        /// Implemented method. 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int Calculate(string type) => CounterTypes.CountTypes();
    }
}
