using System;

namespace Task_DEV_2_
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
        /// <returns 0>Normal start of program</returns>
        /// <returns 1>incorrected words</returns> 
        /// <returns 2>Letter is null</returns>
        /// <returns 3>Something errors</returns>
        static int Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    throw new Exception("Don't have words.");
                }
                ConverterWordToPhonemes converterWordToPhonemes = new ConverterWordToPhonemes();
                for (int i = 0; i < args.Length; i++)
                {
                    Console.WriteLine(args[i] + " -> " + converterWordToPhonemes.ConvertWordToPhonemes(args[i]));
                }
                return 0;
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"Error: {e.Message}.");
                return 1;
            }
            catch(NullReferenceException e)
            {
                Console.WriteLine($"Error: {e.Message}.");
                return 2;
            }
            catch(Exception e)
            {
                Console.WriteLine($"Something error: {e.Message}");
                return 3;
            }
        }
    }
}
