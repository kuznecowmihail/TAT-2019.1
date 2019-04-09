﻿namespace Task_DEV_6
{
    /// <summary>
    /// Child class for pattern command calls method to calculate average price of type cars.
    /// </summary>
    public class CalculaterAveragePriceTypeCommand : ICommand
    {
        CalculaterAveragePriceType CalculaterAveragePricaType { get; }

        /// <summary>
        /// Constructor of CalculaterAveragePricaTypeOnCommand.
        /// </summary>
        /// <param name="cars"></param>
        public CalculaterAveragePriceTypeCommand(CalculaterAveragePriceType calculater) => CalculaterAveragePricaType = calculater;

        /// <summary>
        /// Implemented method. 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int Calculate(string type) => CalculaterAveragePricaType.CalculateAveragePriceType(type);
    }
}
