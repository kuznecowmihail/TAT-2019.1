using System;

namespace Task_DEV_4
{
    /// <summary>
    /// The main class of program.
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// The entry point of program.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                // Create matan discipline.
                Discipline matan = new Discipline();
                // Ouput description of matan to console.
                Console.WriteLine(matan.ToString());
                // Create physics discipline.
                Discipline physics = new Discipline();
                // Check equality GUID of matan and physics - false.
                Console.WriteLine(matan.Equals(physics));
                // Deeply clone physics to phizra.
                Discipline phizra = (Discipline)physics.Clone();
                // Check equality GUID of matan and physics - true.
                Console.WriteLine(phizra.Equals(physics));
                // Output certain lection to display.
                Console.WriteLine(matan[0]);
                Console.WriteLine(matan[2]);
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                Console.WriteLine($"Stack trace: {e.StackTrace}");
            }
        }
    }
}
