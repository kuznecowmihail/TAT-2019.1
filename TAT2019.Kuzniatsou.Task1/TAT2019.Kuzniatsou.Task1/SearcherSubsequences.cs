using System;
using System.Collections.Generic;

namespace TAT2019.Kuzniatsou.Task1
{
    /// <summary>
    /// class that finds and prints subsequences of non-repeating symbols.
    /// </summary>
    class SearcherSubsequences
    {
        private string inputLine;

        public SearcherSubsequences(string line)
        {
            inputLine = line;
        }
        /// <summary>
        /// A method that finds adds subsequences in list.
        /// </summary>
        /// <returns>
        /// listAllSubsequences - list consisting of all subsequences (two or more symbols)
        /// in which there are no two consecutive repeated symbols.
        /// </returns>
        public List<string> SearchSubsequences()
        {
            // Subsequence between repeating symbols.
            var subsequence = string.Empty;
            // List of all subsequences.
            var listAllSubsequences = new List<string>();
            // Index of first and last subsequnce element.
            var indexFirst = 0;
            var indexLast = 0;
            do
            {
                GetSubsequenceBetweenRepeatingSymbols(ref indexFirst, ref indexLast, ref subsequence);
                if (subsequence != String.Empty)
                {
                    AddSubsequencesFromSubsequenceInList(subsequence, ref listAllSubsequences);
                }
                // Put indexFirst to indexLast.
                indexFirst = indexLast + 1;
                subsequence = string.Empty;
            }
            while (indexFirst < inputLine.Length - 1);
            return listAllSubsequences;
        }
        /// <summary>
        /// a method that finds subsequence between repeating symbols in inputLine.
        /// </summary>
        /// <param name="indexFirst">Index of first subsequnce element</param>
        /// <param name="indexLast">Index of last subsequnce element</param>
        /// <param name="subsequence">Subsequence between repeating symbols</param>
        public void GetSubsequenceBetweenRepeatingSymbols(ref int indexFirst, ref int indexLast, ref string subsequence)
        {
            for (indexLast = indexFirst; indexLast < inputLine.Length; indexLast++)
            {
                // Exeption for last element.
                if (indexLast == inputLine.Length - 1)
                {
                    // Check on adding the previous element to add the next element.
                    if ((indexLast - indexFirst) > 0)
                    {
                        subsequence += inputLine[indexLast];
                    }
                    break;
                }
                // Comrarison of elements.
                if (inputLine[indexLast] != inputLine[indexLast + 1])
                {
                    // Add element to subsequence.
                    subsequence += inputLine[indexLast];
                }
                else
                {
                    if ((indexLast - indexFirst) > 0)
                    {
                        subsequence += inputLine[indexLast];
                    }
                    break;
                }
            }
        }
        /// <summary>
        /// A method that adds subsequences in list.
        /// </summary>
        /// <param name="subsequence">Subsequence between repeating symbols</param>
        /// <param name="listAllSubsequences">List of all subsequences</param>
        public void AddSubsequencesFromSubsequenceInList(string subsequence, ref List<string> listAllSubsequences)
        {
            // Subsequences in subsequence.
            var subsequenceOfSubsequence = string.Empty;
            // Add subsequence to list.
            listAllSubsequences.Add(subsequence);
            // Find and add all combinationss of this subsequence.
            for (var i = 0; i < subsequence.Length; i++)
                for (var j = subsequence.Length - 1; j > i; j--)
                {
                    // Select subsequence in this subsequence.
                    subsequenceOfSubsequence = subsequence.Substring(i, j - i + 1);
                    // Check for availability.
                    if (!listAllSubsequences.Contains(subsequenceOfSubsequence) && subsequenceOfSubsequence.Length >= 2)
                    {
                        // Add subsequence in list.
                        listAllSubsequences.Add(subsequenceOfSubsequence);
                    }
                }
        }
        /// <summary>
        /// A method that prints all subsequences.
        /// </summary>
        /// <param name="line">Line to print</param>
        public void PrintSubsequences(List<string> line)
        {
            foreach (var i in line)
                Console.WriteLine(i);
        }
    }
}
