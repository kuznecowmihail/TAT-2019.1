﻿namespace Task_DEV_6
{
    /// <summary>
    /// Interface for pattern command.
    /// </summary>
    interface ICommand
    {
        /// <summary>
        /// Calls the method for display information.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        void DisplayInformation(string type = "");
    }
}
