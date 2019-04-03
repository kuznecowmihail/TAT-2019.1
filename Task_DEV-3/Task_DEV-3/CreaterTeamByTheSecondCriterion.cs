using System;
using System.Linq;

namespace Task_DEV_3
{
    /// <summary>
    /// Child class chooses employees: minimum cost of team at a fixed perfomance.
    /// </summary>
    class CreaterTeamByTheSecondCriterion : CreaterTeam
    {
        /// <summary>
        /// Constructor of CreaterTeamByTheSecondCriterion.
        /// </summary>
        public CreaterTeamByTheSecondCriterion() : base() { }

        /// <summary>
        /// Override method chooses employees on simplex method.
        /// </summary>
        /// <param name="costTeam"></param>
        public override void ChooseEmployees(double perfomanceTeam)
        {
            // Optimal qualification.
            int basis;
            double coefficient = perfomanceTeam;
            double[] salary = new double[] { employees[0].GetSalary(), employees[1].GetSalary(), employees[2].GetSalary(), employees[3].GetSalary() };
            double[] perfomance = new double[] { employees[0].GetPerfomance(), employees[1].GetPerfomance(), employees[2].GetPerfomance(), employees[3].GetPerfomance() };
            SimplexMethodMinimum(out basis, ref coefficient, perfomanceTeam, salary, perfomance);
            HandleExceptionSymplexMethodMinimum(basis, coefficient, perfomanceTeam, perfomance);
        }

        /// <summary>
        /// A method finds optimal minimum costTeam solution.
        /// </summary>
        /// <param name="basis">Optimal qualification</param>
        /// <param name="coefficient">Number of optimal qualification</param>
        /// <param name="perfomanceTeam">Perfomance of company</param>
        /// <param name="perfomance"></param>
        /// <param name="salary"></param>
        public void SimplexMethodMinimum(out int basis, ref double coefficient, double perfomanceTeam, double[] salary, double[] perfomance)
        {
            // Coefficient the raio of the salary to perfomance.
            double k;
            // Minimal value of prfomance.
            double min;
            basis = Array.IndexOf(perfomance, perfomance.Max());
            min = perfomance[basis];
            coefficient /= perfomance[basis];
            k = salary[basis] / perfomance[basis];

            for (int i = 0; i < salary.Length; i++)
            {
                salary[i] = salary[i] - perfomance[i] * k;
                perfomance[i] /= min;
            }

            while (salary.Min() < 0)
            {
                basis = Array.IndexOf(salary, salary.Min());
                coefficient /= perfomance[basis];
                k = Math.Abs(salary[basis]) / perfomance[basis];
                min = perfomance[basis];

                for (int i = 0; i < salary.Length; i++)
                {
                    salary[i] = perfomance[i] * k + salary[i];
                    perfomance[i] /= min;
                }
            }
            countEmployee[basis] = (int)coefficient;
        }

        /// <summary>
        /// A method handles exception of simplex method.
        /// </summary>
        /// <param name="basis"></param>
        /// <param name="coefficient"></param>
        /// <param name="perfomanceTeam"></param>
        /// <param name="perfomance"></param>
        public void HandleExceptionSymplexMethodMinimum(int basis, double coefficient, double perfomanceTeam, double[] perfomance)
        {
            if (basis > 0)
            {
                coefficient -= (int)coefficient;
                perfomanceTeam -= perfomance[basis] * countEmployee[basis];

                while (coefficient < 1 && basis > 0)
                {
                    basis--;

                    if (perfomance[basis] <= perfomanceTeam)
                    {
                        countEmployee[basis]++;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Override method prints choosed team.
        /// </summary>
        public override void DisplayTheTeam()
        {
            {
                Console.WriteLine("Create team by the second criterion:");
                base.DisplayTheTeam();
            }
        }
    }
}
