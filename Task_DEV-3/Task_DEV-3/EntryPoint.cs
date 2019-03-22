using System;

namespace Task_DEV_3
{
    /// <summary>
    /// The main class of program.
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// The entry point of program.
        /// </summary>
        /// <param name="args">Args are criterions of choose team</param>
        static void Main(string[] args)
        {
            try
            {
                if(args.Length < 3)
                {
                    throw new FormatException("there is not enough elements.");
                }
                Company epam = new Company();
                switch(Convert.ToInt32(args[0]))
                {
                    case 1:
                        CreaterTeam firstCriterion = new CreaterTeamByTheFirstCriterion();
                        epam.GetEmployees(firstCriterion, 5500);
                        return;
                    case 2:
                        CreaterTeam secondCriterion = new CreaterTeamByTheSecondCriterion();
                        epam.GetEmployees(secondCriterion, 2400);
                        return;
                    case 3:
                        CreaterTeam thirdCriterion = new CreaterTeamByTheThirdCriterion();
                        epam.GetEmployees(thirdCriterion, 2400);
                        return;
                    default:
                        Console.WriteLine("there is not such criterion.");
                        return;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}
