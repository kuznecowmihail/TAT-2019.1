namespace Task_DEV_10
{
    /// <summary>
    /// Interface for pattern command.
    /// </summary>
    interface ICommand
    {
        /// <summary>
        /// The method reads file and fill objects.
        /// </summary>
        void ReadAndFillElements();

        /// <summary>
        /// Method updates json file.
        /// </summary>
        void UpdateJsonFile();

        /// <summary>
        /// Method adds new element.
        /// </summary>
        void AddNewElement();

        /// <summary>
        /// Method deletes element.
        /// </summary>
        void DeleteElement();

        /// <summary>
        /// Method display elements.
        /// </summary>
        void DisplayElements();
    }
}
