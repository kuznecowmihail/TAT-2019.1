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
        static void Main(string[] args)
        {
            if (args[0].Length < 2)
            {
                Console.WriteLine("String contains less than 2 characters");
            }
            else
            {
                Subsequence arg = new Subsequence(args[0]);
                arg.SearchSubsequences();
            }
        }
    }
}
