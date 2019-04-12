namespace Task_DEV_6
{
    /// <summary>
    /// Child class for pattern command calls method to count number of all autos.
    /// </summary>
    public class NumberAllAutosCommand : ICommand
    {
        NumberAllAutos NumberAllAutos { get; }

        /// <summary>
        /// Constructor of NumberAllAutos.
        /// </summary>
        /// <param name="numberAllAutos"></param>
        public NumberAllAutosCommand(NumberAllAutos numberAllAutos)
        {
            this.NumberAllAutos = numberAllAutos;
        }

        /// <summary>
        /// Implemented method. 
        /// </summary>
        /// <param name="type"></param>
        public void DisplayInformation(string type) => NumberAllAutos.DisplayNumberAllCars();

        /// <summary>
        /// Implemented method. 
        /// </summary>
        public void DisplayAutoTypes() => NumberAllAutos.DisplayAutoTypes();

        /// <summary>
        /// Implemented method. 
        /// </summary>
        /// <param name="type"></param>
        public bool IsContains(string type) => NumberAllAutos.IsContains(type);
    }
}
