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
        /// <returns 0>Normal program start</returns>
        /// <returns 1>Something errors</returns>
        static int Main(string[] args)
        {
            try
            {
                ConverterWordToPhonemes[] converterWordToPhonemes = new ConverterWordToPhonemes[args.Length];
                for (int i = 0; i < converterWordToPhonemes.Length; i++)
                {
                    converterWordToPhonemes[i] = new ConverterWordToPhonemes(args[i]);
                    converterWordToPhonemes[i].PrintPhonemes(converterWordToPhonemes[i].ConvertWord());
                }
                return 0;
            }
            catch(Exception)
            {
                Console.WriteLine("Something error");
                return 1;
            }
        }
    }
}
