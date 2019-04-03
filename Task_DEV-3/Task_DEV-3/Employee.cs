namespace Task_DEV_3
{
    /// <summary>
    /// Parent class.
    /// </summary>
    class Employee
    {
        protected readonly int salary;
        protected readonly int perfomance;

        /// <summary>
        /// Constructor of Employee.
        /// </summary>
        /// <param name="salary"></param>
        /// <param name="perfomance"></param>
        public Employee(int salary, int perfomance)
        {
            this.salary = salary;
            this.perfomance = perfomance;
        }

        /// <summary>
        /// A method returns salary.
        /// </summary>
        /// <returns salary></returns>
        public int GetSalary() => salary;

        /// <summary>
        /// A method returns perfomance.
        /// </summary>
        /// <returns perfomance></returns>
        public int GetPerfomance() => perfomance;
    }
}
