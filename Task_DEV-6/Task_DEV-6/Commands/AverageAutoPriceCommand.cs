﻿namespace Task_DEV_6
{
    /// <summary>
    /// Child class for pattern command calls method to calculate average price all autos.
    /// </summary>
    public class AverageAutoPriceCommand : ICommand
    {
        AverageAutoPrice AverageAutoPrice { get; }

        /// <summary>
        /// Constructor of AverageAutoPriceCommand.
        /// </summary>
        /// <param name="averageAutoPrice"></param>
        public AverageAutoPriceCommand(AverageAutoPrice averageAutoPrice)
        {
            this.AverageAutoPrice = averageAutoPrice;
        }

        /// <summary>
        /// Implemented method. 
        /// </summary>
        /// <param name="type"></param>
        public void DisplayInformation(string type) => AverageAutoPrice.DisplayAveragePrice();

        /// <summary>
        /// Implemented method. 
        /// </summary>
        public void DisplayAutoTypes() => AverageAutoPrice.DisplayAutoTypes();

        /// <summary>
        /// Implemented method. 
        /// </summary>
        /// <param name="type"></param>
        public bool IsContains(string type) => AverageAutoPrice.IsContains(type);
    }
}
