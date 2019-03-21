namespace Task_DEV_3
{
    class Company
    {
        /// <summary>
        /// The class makes the team order to choose the team.
        /// </summary>
        public Company() { }
        /// <summary>
        /// A method gives the command to choose team.
        /// </summary>
        /// <param name="createrTeam"></param>
        /// <param name="value">Criterion of choose</param>
        public void GetEmployees(CreaterTeam createrTeam, double value)
        {
            createrTeam.ChooseEmployees(value);
            createrTeam.DisplayTheTeam();
        }
    }
}
