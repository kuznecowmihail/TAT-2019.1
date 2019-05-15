using System.Collections.Generic;

namespace Task_DEV_7
{
    /// <summary>
    /// Child class for pattern command calls method to count number of all auto types.
    /// </summary>
    public class NumberAutoTypesCommand : ICommand
    {
        NumberAutoTypes NumberAutoTypes { get; }

        /// <summary>
        /// Constructor of NumberAutoTypesCommand.
        /// </summary>
        /// <param name="numberAutoTypes"></param>
        public NumberAutoTypesCommand(NumberAutoTypes numberAutoTypes)
        {
            this.NumberAutoTypes = numberAutoTypes;
        }

        /// <summary>
        /// Implemented method. 
        /// </summary>
        /// <param name="type"></param>
        public void DisplayInformation() => NumberAutoTypes.DisplayNumberCarTypes();

        /// <summary>
        /// Implemented method. 
        /// </summary>
        public List<string> GetAutoTypes() => NumberAutoTypes.GetAutoTypes();

        /// <summary>
        /// Implemented method. 
        /// </summary>
        public void SetProperties(string autoType, string autoBrand) => NumberAutoTypes.SetProperties(autoType, autoBrand);
    }
}