using System;

namespace Task_DEV_3
{
    /// <summary>
    /// Class creates team on one of the three criteria.
    /// </summary>
    class CreaterTeam
    {
        protected Employee[] employees;
        protected int sizeOfQualification = 4;
        protected int[] countEmployee;
        
        public CreaterTeam()
        {
            sizeOfQualification = 4;
            countEmployee = new int[sizeOfQualification];
            employees = new Employee[sizeOfQualification];
            employees[0] = new Junior();
            employees[1] = new Middle();
            employees[2] = new Senior();
            employees[3] = new Lead();
        }
        /// <summary>
        /// Virtual method chooses employees.
        /// </summary>
        /// <param name="value">Criterion of choose</param>
        virtual public void ChooseEmployees(double value) { }
        /// <summary>
        /// Virtual method prints choosed team.
        /// </summary>
        virtual public void DisplayTheTeam()
        {
            for(int i = 0; i < sizeOfQualification; i++)
            {
                Console.WriteLine(i +") " + employees[i].GetName() + " : " + countEmployee[i]);
            }
            // Reset values for the next operation.
            for(int i = 0; i < countEmployee.Length; i++)
            {
                countEmployee[i] = 0;
            }
        }
    }
}
