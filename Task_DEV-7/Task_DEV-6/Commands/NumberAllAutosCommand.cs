using System.Collections.Generic;

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
        public void DisplayInformation() => NumberAllAutos.DisplayNumberAllCars();

        /// <summary>
        /// Implemented method. 
        /// </summary>
        public List<string> GetAutoTypes() => NumberAllAutos.GetAutoTypes();

        /// <summary>
        /// Implemented method. 
        /// </summary>
        public void SetProperties(string autoType, string autoBrand) => NumberAllAutos.SetProperties(autoType, autoBrand);
    }
}
