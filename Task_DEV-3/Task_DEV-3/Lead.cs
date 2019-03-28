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
        public Lead(int salary, int perfomance) : base(salary, perfomance)
        {
            name = "Lead";
        }

        public Lead() : this(1000, 350) { }
    }
}
