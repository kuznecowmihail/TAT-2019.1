namespace Task_DEV_3
{
    /// <summary>
    /// Child class of Emloyee.
    /// </summary>
    class Lead : Employee
    {
        public Lead(int salary, int perfomance) : base(salary, perfomance)
        {
            name = "Lead";
        }

        public Lead() : this(1000, 350) { }
    }
}
