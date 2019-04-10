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
        public NumberAutoTypesCommand(NumberAutoTypes numberAutoTypes) => NumberAutoTypes = numberAutoTypes;

        /// <summary>
        /// Implemented method. 
        /// </summary>
        /// <param name="type"></param>
        public void DisplayInformation(string type) => NumberAutoTypes.DisplayNumberCarTypes();
    }
}
