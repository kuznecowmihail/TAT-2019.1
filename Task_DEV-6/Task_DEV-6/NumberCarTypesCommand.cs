namespace Task_DEV_6
{
    /// <summary>
    /// Child class for pattern command calls method to count number of all car types.
    /// </summary>
    public class NumberCarTypesCommand : ICommand
    {
        NumberCarTypes NumberCarTypes { get; }

        /// <summary>
        /// Constructor of NumberCarTypesCommand.
        /// </summary>
        /// <param name="counter"></param>
        public NumberCarTypesCommand(NumberCarTypes numberCarTypes) => NumberCarTypes = numberCarTypes;

        /// <summary>
        /// Implemented method. 
        /// </summary>
        /// <param name="type"></param>
        public void DisplayInformation(string type) => NumberCarTypes.DisplayNumberCarTypes();
    }
}
