using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* DEV-1 Task-1: вводится строка(не меньше двух символов), выводится в консоль все подпоследовательности(не меньше двух символов)
 , в которых нет повторяющихся символов, поиск подстрок идет в отдельном классе Subsequence */

namespace TAT2019.Kuzniatsou.Task1
{
    class Program
    {
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
