namespace Task_DEV_3
{
    /// <summary>
    /// The class makes order to choose the team.
    /// </summary>
    class Company
    {
        public Company() { }
        /// <summary>
        /// A method gives the command to choose team.
        /// </summary>
        /// <param name="criterion">Criterion of choose</param>
        public void GetEmployees(CreaterTeam createrTeam, double criterion)
        {
            createrTeam.ChooseEmployees(criterion);
            createrTeam.DisplayTheTeam();
        }
    }
}
