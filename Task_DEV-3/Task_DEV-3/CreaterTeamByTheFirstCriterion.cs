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
            double coefficient = costTeam;
            double[] commonSalary = { employees[0].GetSalary(), employees[1].GetSalary(), employees[2].GetSalary(), employees[3].GetSalary() };
            double[] salary = { employees[0].GetSalary(), employees[1].GetSalary(), employees[2].GetSalary(), employees[3].GetSalary() };
            double[] productivity = { -employees[0].GetPerfomance(), -employees[1].GetPerfomance(), -employees[2].GetPerfomance(), -employees[3].GetPerfomance() };
            int basis;
            double min;
            do
            {
                basis = Array.IndexOf(productivity, productivity.Min());
                min = salary[basis];
                coefficient /= Math.Abs(salary[basis]);
                for (int i = 0; i < salary.Length; i++)
                {
                    salary[i] /= min;
                    productivity[i] = productivity[i] - salary[i] * productivity[basis];
                }
            } while (productivity.Min() < 0);
            countEmployee[basis] = (int)coefficient;
            // Exception of simplex method.
            if(basis > 0)
            {
                coefficient -= (int)coefficient;
                costTeam -= commonSalary[basis] * countEmployee[basis];
                basis--;
                while (coefficient < 1 && basis > 0)
                {
                    if (commonSalary[basis] <= costTeam)
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
