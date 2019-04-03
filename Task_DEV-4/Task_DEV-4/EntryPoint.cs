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
                // Create matn discipline.
                Discipline matn = new Discipline();
                // Create physics discipline.
                Discipline physics = new Discipline();
                // Check equality GUID of matan and physics - false.
                Console.WriteLine(matn.Equals(physics));
                // Deeply clone physics to phizra.
                Discipline phizra = (Discipline)physics.Clone();
                // Check equality GUID of matan and physics - true.
                Console.WriteLine(phizra.Equals(physics));

                for(int i = 0; i < physics.listOfLectures.Count; i++)
                {
                    // Output certain lection to display. 
                    Console.WriteLine(physics[i]);
                }

                for (int i = 0; i < phizra.listOfLectures.Count; i++)
                {
                    // Output certain lection to display. 
                    Console.WriteLine(phizra[i]);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}
