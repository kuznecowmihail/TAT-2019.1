namespace Task_DEV_3
{
    /// <summary>
    /// Child class of Emloyee.
    /// </summary>
    class Lead : Employee
    {
        public Lead() : base(1000, 350)
        {
            name = "Lead";
        }
    }
}
