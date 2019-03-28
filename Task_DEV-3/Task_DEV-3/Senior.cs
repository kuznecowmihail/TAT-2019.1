namespace Task_DEV_3
{
    /// <summary>
    /// Child class of Emloyee.
    /// </summary>
    class Senior : Employee
    {
        /// <summary>
        /// Constructor of Senior.
        /// </summary>
        /// <param name="salary"></param>
        /// <param name="perfomance"></param>
        public Senior(int salary, int perfomance) : base(salary, perfomance)
        {
            name = "Senior";
        }

        public Senior() : this(800, 300) { }
    }
}
