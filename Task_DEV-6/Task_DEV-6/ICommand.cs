namespace Task_DEV_6
{
    /// <summary>
    /// Interface for pattern command.
    /// </summary>
    interface ICommand
    {
        /// <summary>
        /// Calls the method for calculate.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        int Calculate(string type = "");
    }
}
