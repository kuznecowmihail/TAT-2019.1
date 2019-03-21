namespace Task_DEV_3
{
    /// <summary>
    /// Child class of Emloyee.
    /// </summary>
    class Middle : Employee
    {
        public Middle(int salary, int perfomance) : base(salary, perfomance)
        {
            name = "Middle";
        }

        public Middle() : this(700, 200) { }
    }
}
