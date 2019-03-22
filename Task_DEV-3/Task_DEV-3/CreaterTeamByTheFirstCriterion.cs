using System;
using System.Linq;

namespace Task_DEV_3
{
    /// <summary>
    /// Child class chooses employees: maximum perfomance at a fixed cost.
    /// </summary>
    class CreaterTeamByTheFirstCriterion : CreaterTeam
    {
        public CreaterTeamByTheFirstCriterion() : base() { }
        /// <summary>
        /// Override method chooses employees on simplex method.
        /// </summary>
        /// <param name="costTeam"></param>
        public override void ChooseEmployees(double costTeam)
        {
            // Optimal qualification.
            int basis;
            double coefficient = costTeam;
            double[] salary = { employees[0].GetSalary(), employees[1].GetSalary(), employees[2].GetSalary(), employees[3].GetSalary() };
            double[] perfomance = { -employees[0].GetPerfomance(), -employees[1].GetPerfomance(), -employees[2].GetPerfomance(), -employees[3].GetPerfomance() };
            SimplexMethodMaximum(out basis, ref coefficient, costTeam, salary, perfomance);
            HandleExceptionSymplexMethodMaximum(basis, coefficient, costTeam, salary);
        }
        /// <summary>
        /// A method finds optimal maximum perfomance solution.
        /// </summary>
        /// <param name="basis">Optimal qualification</param>
        /// <param name="coefficient">Number of optimal qualification</param>
        /// <param name="costTeam">Money of company</param>
        /// <param name="perfomance"></param>
        /// <param name="salary"></param>
        public void SimplexMethodMaximum(out int basis, ref double coefficient, double costTeam, double[] salary, double[] perfomance)
        {
            // Minumal value of salary.
            double min;
            do
            {
                basis = Array.IndexOf(perfomance, perfomance.Min());
                min = salary[basis];
                coefficient /= Math.Abs(salary[basis]);
                for (int i = 0; i < salary.Length; i++)
                {
                    salary[i] /= min;
                    perfomance[i] = perfomance[i] - salary[i] * perfomance[basis];
                }
            } while (perfomance.Min() < 0);
            countEmployee[basis] = (int)coefficient;
        }
        /// <summary>
        /// A method handles exception of simplex method.
        /// </summary>
        /// <param name="basis"></param>
        /// <param name="coefficient"></param>
        /// <param name="costTeam"></param>
        /// <param name="salary"></param>
        public void HandleExceptionSymplexMethodMaximum(int basis, double coefficient, double costTeam, double[] salary)
        {
            // Exception of simplex method.
            if (basis > 0)
            {
                coefficient -= (int)coefficient;
                costTeam -= salary[basis] * countEmployee[basis];
                basis--;
                while (coefficient < 1 && basis > 0)
                {
                    if (salary[basis] <= costTeam)
                    {
                        countEmployee[basis]++;
                        break; ;
                    }
                    basis--;
                }
            }
        }
        /// <summary>
        /// Override method prints choosed team.
        /// </summary>
        public override void DisplayTheTeam()
        {
            Console.WriteLine("Create team by the first criterion:");
            base.DisplayTheTeam();
        }
    }
}
