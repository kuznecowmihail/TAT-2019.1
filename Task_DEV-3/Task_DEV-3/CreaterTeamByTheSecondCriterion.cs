using System;
using System.Linq;

namespace Task_DEV_3
{
    /// <summary>
    /// Child class chooses employees: minimum cost of team at a fixed perfomance.
    /// </summary>
    class CreaterTeamByTheSecondCriterion : CreaterTeam
    {
        public CreaterTeamByTheSecondCriterion() : base() { }
        /// <summary>
        /// Override method chooses employees on simplex method.
        /// </summary>
        /// <param name="costTeam"></param>
        public override void ChooseEmployees(double perfomanceTeam)
        {
            double[] commonPerfomance = new double[] { employees[0].GetPerfomance(), employees[1].GetPerfomance(), employees[2].GetPerfomance(), employees[3].GetPerfomance() };
            double coefficient = perfomanceTeam;
            double[] salary = new double[] { employees[0].GetSalary(), employees[1].GetSalary(), employees[2].GetSalary(), employees[3].GetSalary() };
            double[] perfomance = new double[] { employees[0].GetPerfomance(), employees[1].GetPerfomance(), employees[2].GetPerfomance(), employees[3].GetPerfomance() };
            int basis;
            double k;
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
            // Exception of simplex method.
            if (basis > 0)
            {
                coefficient -= (int)coefficient;
                perfomanceTeam -= commonPerfomance[basis] * countEmployee[basis];
                while (coefficient < 1 && basis > 0)
                {
                    basis--;
                    if (commonPerfomance[basis] <= perfomanceTeam)
                    {
                        countEmployee[basis]++;
                        break; ;
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
