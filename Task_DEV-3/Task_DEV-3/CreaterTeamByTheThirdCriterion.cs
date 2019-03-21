using System;

namespace Task_DEV_3
{
    /// <summary>
    /// Child class chooses employees: minimum number of people at a fixed perfomance.
    /// </summary>
    class CreaterTeamByTheThirdCriterion : CreaterTeam
    {
        public CreaterTeamByTheThirdCriterion() : base() { }
        /// <summary>
        /// Override method chooses employees.
        /// </summary>
        /// <param name="perfomanceTeam"></param>
        public override void ChooseEmployees(double perfomanceTeam)
        {
            int i = employees.Length - 1;
            while (perfomanceTeam > 0 && i >= 0)
            {
                if (perfomanceTeam > employees[i].GetPerfomance())
                {
                    countEmployee[i]++;
                    perfomanceTeam -= employees[i].GetPerfomance();
                }
                else
                {
                    i--;
                }
            }
        }
        /// <summary>
        /// Override method prints choosed team.
        /// </summary>
        public override void DisplayTheTeam()
        {
            {
                Console.WriteLine("Create team by the third criterion:");
                base.DisplayTheTeam();
            }
        }
    }
}
