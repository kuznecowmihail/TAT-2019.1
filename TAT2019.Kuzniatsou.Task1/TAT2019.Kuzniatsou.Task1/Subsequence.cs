using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TAT2019.Kuzniatsou.Task1
{
    /// <summary>
    /// class that finds and prints subsequences of non-repeating symbols.
    /// </summary>
    class Subsequence
    {
        public string inputLine;

        public Subsequence(string line)
        {
                inputLine = line;
        }

        /// <summary>
        /// a method that finds subsequences
        /// </summary>
        public void SearchSubsequences()
        {
            // Subsequence between repeating symbols.
            string sequence = string.Empty;
            // Subsequence in sequence.
            string subsequence = string.Empty;
            // List of all subsequences.
            List<string> subSequences = new List<string>();
            // Index of first and last sequnce element.
            int indexFirst = 0;
            int indexLast = 0;
            do
            {
                for(indexLast = indexFirst; indexLast < inputLine.Length; indexLast++)
                {
                    // Exeption for last element.
                    if (indexLast == inputLine.Length - 1)
                    {
                        // Check on adding the previous element
                        // to add the next element.
                        if ((indexLast - indexFirst) > 0) 
                        {
                            sequence += inputLine[indexLast];
                        }
                        break;
                    }
                    // Comrarison of elements.
                    if (inputLine[indexLast] != inputLine[indexLast + 1])
                    {
                        // Add element to subsequence.
                        sequence += inputLine[indexLast];
                    }
                    else
                    {
                        if ((indexLast - indexFirst) > 0) 
                        {
                            sequence += inputLine[indexLast];
                        }
                        break;
                    }
                }
                if (sequence != String.Empty)
                {
                    // Add subsequence to list.
                    subSequences.Add(sequence);
                    // Find and add all combinationss of this subsequence.
                    for (int i = 0; i < sequence.Length; i++)
                        for (int j = sequence.Length - 1; j > i; j--)
                        {
                            // Select subsequence in this subsequence.
                            subsequence = sequence.Substring(i, j - i + 1);
                            // Check for availability.
                            if (!subSequences.Contains(subsequence) && subsequence.Length >= 2)
                            {
                                // Add subsequence in list.
                                subSequences.Add(subsequence);
                            }
                        }
                }
                indexFirst = indexLast + 1;
                sequence = string.Empty;
            }
            while (indexFirst < inputLine.Length - 1);
            PrintSubsequences(subSequences);
        }

        /// <summary>
        /// a method that prints subsequences
        /// </summary>
        public void PrintSubsequences(List<string> line) 
        {
            foreach (string i in line)
                Console.WriteLine(i);
        }
    }
}
