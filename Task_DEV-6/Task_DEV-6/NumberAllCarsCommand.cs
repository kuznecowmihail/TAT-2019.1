namespace Task_DEV_6
{
    /// <summary>
    /// Child class for pattern command calls method to count number of all cars.
    /// </summary>
    public class NumberAllCarsCommand : ICommand
    {
        NumberAllCars NumberAllCars { get; }

        /// <summary>
        /// Constructor of NumberAllCars.
        /// </summary>
        /// <param name="counter"></param>
        public NumberAllCarsCommand(NumberAllCars numberAllCars) => NumberAllCars = numberAllCars;

        /// <summary>
        /// Implemented method. 
        /// </summary>
        /// <param name="type"></param>
        public void DisplayInformation(string type) => NumberAllCars.DisplayNumberAllCars();
    }
}
