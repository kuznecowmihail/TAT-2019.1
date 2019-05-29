using System;
using System.Text;
using System.Collections.Generic;

namespace TAT2019.Kuzniatsou.Task1
{
    /// <summary>
    /// class that finds and prints subsequences of non-repeating symbols.
    /// </summary>
    class SearcherSubsequences
    {
        string InputLine { get; }

        /// <summary>
        /// Constructor of SearcherSubsequences.
        /// </summary>
        /// <param name="line"></param>
        public SearcherSubsequences(string line)
        {
            InputLine = line;
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
            // List of all subsequences.
            var listAllSubsequences = new List<string>();
            // Index of first and last subsequnce element.
            var indexFirst = 0;
            var indexLast = 0;

            do
            {
                // Subsequence between repeating symbols.
                string subsequence = GetSubsequenceBetweenRepeatingSymbols(ref indexFirst, ref indexLast);

                if (subsequence != String.Empty)
                {
                    AddSubsequencesFromSubsequenceToList(subsequence, listAllSubsequences);
                }
                // Put indexFirst to indexLast.
                indexFirst = indexLast + 1;
            }
            while (indexFirst < InputLine.Length - 1);

            return listAllSubsequences;
        }

        /// <summary>
        /// a method that finds subsequence between repeating symbols in inputLine.
        /// </summary>
        /// <param name="indexFirst">Index of first subsequnce element</param>
        /// <param name="indexLast">Index of last subsequnce element</param>
        /// <param name="subsequence">Subsequence between repeating symbols</param>
        public string GetSubsequenceBetweenRepeatingSymbols(ref int indexFirst, ref int indexLast)
        {
            StringBuilder subsequence = new StringBuilder();

            for (indexLast = indexFirst; indexLast < InputLine.Length; indexLast++)
            {
                subsequence.Append(InputLine[indexLast]);

                // Exception for last element or reapiting elements.
                if (indexLast == InputLine.Length - 1 || InputLine[indexLast] == InputLine[indexLast + 1])
                {
                    break;
                }
            }

            return subsequence.ToString();
        }

        /// <summary>
        /// A method that adds subsequences to list.
        /// </summary>
        /// <param name="subsequence">Subsequence between repeating symbols</param>
        /// <param name="listAllSubsequences">List of all subsequences</param>
        public void AddSubsequencesFromSubsequenceToList(string subsequence, List<string> listAllSubsequences)
        {
            // Add subsequence to list.
            listAllSubsequences.Add(subsequence);

            // Find and add all combinationss of this subsequence.
            for (var i = 0; i < subsequence.Length; i++)
            {
                for (var j = subsequence.Length - 1; j > i; j--)
                {
                    // Select subsequence in this subsequence.
                    string subsequenceOfSubsequence = subsequence.Substring(i, j - i + 1);

                    // Check for availability.
                    if (!listAllSubsequences.Contains(subsequenceOfSubsequence) && subsequenceOfSubsequence.Length >= 2)
                    {
                        // Add subsequence in list.
                        listAllSubsequences.Add(subsequenceOfSubsequence);
                    }
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
            {
                Console.WriteLine(i);
            }
        }
    }
}