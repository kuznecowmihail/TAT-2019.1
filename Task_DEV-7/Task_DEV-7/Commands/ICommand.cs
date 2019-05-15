using System.Collections.Generic;

namespace Task_DEV_7
{
    /// <summary>
    /// Interface for pattern command.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Calls the method for display information.
        /// </summary>
        /// <param name="type">ppart of request for parameter if this need</param>
        void DisplayInformation();

        /// <summary>
        /// Returns all types of auto.
        /// </summary>
        /// <returns></returns>
        List<string> GetAutoTypes();

        /// <summary>
        /// Sets auto properties.
        /// </summary>
        /// <param name="autoType"></param>
        void SetProperties(string autoType, string autoBrand);
    }
}