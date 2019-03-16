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
        /// <returns 1>Don't have words</returns> 
        /// <returns 2>Something errors</returns>
        static int Main(string[] args)
        {
            try
            {
                if (args.Length == 0 || args[0].Length < 2)
                    throw new FormatException();
                ConverterWordToPhonemes[] converterWordToPhonemes = new ConverterWordToPhonemes[args.Length];
                for (int i = 0; i < args.Length; i++)
                {
                    converterWordToPhonemes[i] = new ConverterWordToPhonemes(args[i]);
                    Console.WriteLine(args[i] + " -> " + converterWordToPhonemes[i].ConvertWordToPhonemes());
                }
                return 0;
            }
            catch(FormatException)
            {
                Console.WriteLine("Don't have words.");
                return 1;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Something error: " + ex);
                return 2;
            }
        }
    }
}
