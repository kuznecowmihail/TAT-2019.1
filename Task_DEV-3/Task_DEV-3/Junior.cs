namespace Task_DEV_3
{
    /// <summary>
    /// Child class of Emloyee.
    /// </summary>
    class Junior : Employee
    {
        public Junior(int salary, int perfomance) : base(salary, perfomance)
        {
            name = "Junior";
        }

        public Junior() : this(500, 100) { }
    }
}
