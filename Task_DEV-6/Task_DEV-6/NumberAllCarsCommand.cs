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
        /// <param name="numberAllCars"></param>
        public NumberAllCarsCommand(NumberAllCars numberAllCars)
        {
            this.NumberAllCars = numberAllCars;
        }

        /// <summary>
        /// Implemented method. 
        /// </summary>
        /// <param name="type"></param>
        public void DisplayInformation(string type) => NumberAllCars.DisplayNumberAllCars();
    }
}
