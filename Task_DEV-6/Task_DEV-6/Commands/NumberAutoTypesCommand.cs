﻿namespace Task_DEV_6
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
        public void DisplayInformation(string type) => NumberAutoTypes.DisplayNumberCarTypes();

        /// <summary>
        /// Implemented method. 
        /// </summary>
        public void DisplayAutoTypes() => NumberAutoTypes.DisplayAutoTypes();

        /// <summary>
        /// Implemented method. 
        /// </summary>
        /// <param name="type"></param>
        public bool DoesTypeContain(string type) => NumberAutoTypes.DoesTypeContain(type);
    }
}