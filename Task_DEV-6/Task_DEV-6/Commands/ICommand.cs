namespace Task_DEV_6
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
        void DisplayInformation(string type);

        /// <summary>
        /// Calls the method for display auto type.
        /// </summary>
        void DisplayAutoTypes();

        /// <summary>
        /// Method returns true if the type of auto existences. 
        /// </summary>
        /// <param name="type">Auto type</param>
        /// <returns></returns>
        bool IsContains(string type);
    }
}
