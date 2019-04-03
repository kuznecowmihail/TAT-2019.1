using System;

namespace Task_DEV_3
{
    /// <summary>
    /// Child class chooses employees: minimum cost of team at a fixed perfomance without Junior.
    /// </summary>
    class CreaterTeamByTheThirdCriterion : CreaterTeamByTheSecondCriterion
    {
        /// <summary>
        /// Constructor of CreaterTeamByTheThirdCriterion.
        /// </summary>
        public CreaterTeamByTheThirdCriterion() : base() { }

        /// <summary>
        /// Override method chooses employees
        /// </summary>
        /// <param name="perfomanceTeam"></param>
        public override void ChooseEmployees(double perfomanceTeam)
        {
            int basis;
            double coefficient = perfomanceTeam;
            double[] salary = new double[] { employees[1].GetSalary(), employees[2].GetSalary(), employees[3].GetSalary() };
            double[] perfomance = new double[] { employees[1].GetPerfomance(), employees[2].GetPerfomance(), employees[3].GetPerfomance() };
            SimplexMethodMinimum(out basis, ref coefficient, perfomanceTeam, salary, perfomance);
            HandleExceptionSymplexMethodMinimum(basis, coefficient, perfomanceTeam, perfomance);
        }

        /// <summary>
        /// Override method prints choosed team.
        /// </summary>
        public override void DisplayTheTeam()
        {
            Console.WriteLine("Create team by the second criterion:");
            // Start cycle from the Middle(employees[i+1], because criterion without Junior.
            for (int i = 0; i < sizeOfQualification - 1; i++)
            {
                Console.WriteLine(i  + ") " + employees[i+1].GetType().Name + " : " + countEmployee[i+1]);
            }

            // Reset values for the next operation.
            for (int i = 1; i < countEmployee.Length; i++)
            {
                countEmployee[i] = 0;
            }
        }
    }
}
