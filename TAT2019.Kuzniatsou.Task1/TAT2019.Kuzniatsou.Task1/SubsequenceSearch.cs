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
            string outputLine = string.Empty;
            // List of all subsequences.
            List<string> subSequences = new List<string>();
            // Index of first and last element.
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
                            outputLine += inputLine[indexLast];
                        }
                        break;
                    }
                    // Comrarison of elements.
                    if (inputLine[indexLast] != inputLine[indexLast + 1])
                    {
                        // Add element to subsequence.
                        outputLine += inputLine[indexLast];
                    }
                    else
                    {
                        if ((indexLast - indexFirst) > 0) 
                        {
                            outputLine += inputLine[indexLast];
                        }
                        break;
                    }
                }
                if (outputLine != String.Empty)
                {
                    // Add subsequence to list.
                    subSequences.Add(outputLine);
                    // Find and add all combinationss of this subsequence.
                    for (int i = 0; i < outputLine.Length; i++)
                        for (int j = outputLine.Length - 1; j > i; j--)
                        {
                            // Select subsequence in this subsequence.
                            string subLine = outputLine.Substring(i, j - i + 1);
                            // Check for availability.
                            if (!subSequences.Contains(subLine) && subLine.Length >= 2)
                            {
                                // Add subsequence in list.
                                subSequences.Add(subLine);
                            }
                        }
                }
                indexFirst = indexLast + 1;
                outputLine = string.Empty;
            }
            while (indexFirst < inputLine.Length - 1);
            OutputOnDisplay(subSequences);
        }

        /// <summary>
        /// a method that prints subsequences
        /// </summary>
        public void OutputOnDisplay(List<string> line) 
        {
            foreach (string i in line)
                Console.WriteLine(i);
        }
    }
}
