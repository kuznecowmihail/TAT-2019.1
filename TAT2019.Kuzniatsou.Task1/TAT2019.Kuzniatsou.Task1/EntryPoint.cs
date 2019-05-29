using System;

namespace TAT2019.Kuzniatsou.Task1
{
    /// <summary>
    /// The main class.
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">Arguments from command line</param>
        /// <returns 0>Normal program start</returns>
        /// <returns 1>String contains less than 2 elements</returns>
        /// <returns 2>Something errors</returns>
        static int Main(string[] args)
        {
            try
            {
                if (args[0].Length < 2 && args.Length < 2)
                {
                    throw new FormatException();
                }
                var subsequences = new SearcherSubsequences(args[0]);
                subsequences.PrintSubsequences(subsequences.SearchSubsequences());

                return 0;
            }
            catch(FormatException)
            {
                Console.WriteLine("String contains less than 2 elements");

                return 1;
            }
            catch(Exception)
            {
                Console.WriteLine("Something error");

                return 2;
            }
        }
    }
}
