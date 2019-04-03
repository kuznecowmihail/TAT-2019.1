namespace Task_DEV_3
{
    /// <summary>
    /// Child class of Emloyee.
    /// </summary>
    class Lead : Employee
    {
        /// <summary>
        /// Constructor of Lead.
        /// </summary>
        /// <param name="salary"></param>
        /// <param name="perfomance"></param>
        public Lead() : base(1000, 350) { }
    }
}
