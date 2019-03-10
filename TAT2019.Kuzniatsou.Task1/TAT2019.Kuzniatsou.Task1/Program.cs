using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAT2019.Kuzniatsou.Task1
{
    /// <summary>
    /// The main class.
    /// Contains a entry point method of program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The entry point of the program
        /// </summary>
        static int Main(string[] args)
        {
            try
            {
                if (args[0].Length < 2 && args.Length < 2)
                {
                    throw new FormatException();
                }
                Subsequence arg = new Subsequence(args[0]);
                List<string> listOfSubsequences = new List<string>();
                listOfSubsequences = arg.SearchSubsequences();
                arg.PrintSubsequences(listOfSubsequences);
                return 0;
            }
            catch(FormatException)
            {
                Console.WriteLine("String contains less than 2 elements");
                return 1;
            }
            catch (Exception)
            {
                Console.WriteLine("Something error!");
                return 2;
            }
        }
    }
}
