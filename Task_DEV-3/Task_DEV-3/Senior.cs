namespace Task_DEV_3
{
    /// <summary>
    /// Child class of Emloyee.
    /// </summary>
    class Senior : Employee
    {
        public Senior(int salary, int perfomance) : base(salary, perfomance)
        {
            name = "Senior";
        }

        public Senior() : this(800, 300) { }
    }
}
