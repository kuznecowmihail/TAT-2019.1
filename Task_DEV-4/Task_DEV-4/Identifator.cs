using System;
using System.IO;
using System.Text;

namespace Task_DEV_4
{
    /// <summary>
    /// Base abstract class.
    /// </summary>
    public abstract class Identificator
    {
        public string MyGuid { get; set; }
        public string Description { get; protected set; }
        protected Random random;

        /// <summary>
        /// Constructor of Identificator.
        /// </summary>
        public Identificator()
        {
            random = new Random(DateTime.Now.Millisecond);
            MyGuid = MyGuid.GuidToString();
            Description = GetText(256);
        }

        /// <summary>
        /// Method read file and write to string and select part of text for description and other material.
        /// </summary>
        /// <param name="restriction">material size limit</param>
        /// <returns></returns>
        public string GetText(int restriction = 10)
        {
            int numberFirstElement;
            int numberLastElement;
            StringBuilder line = new StringBuilder();
            StreamReader reader = new StreamReader("../../text.txt");
            string partLine = string.Empty;
            // Read from file text.txt and add to line.
            while (partLine != null)
            {
                partLine = reader.ReadLine();
                if (partLine != null)
                {
                    line.Append(partLine);
                }
            }
            reader.Close();
            // Convert StringBuilde to string.
            string text = line.ToString();
            numberFirstElement = random.Next(0, text.Length);
            numberLastElement = random.Next(numberFirstElement + 1, numberFirstElement + restriction);
            // if numberLastChar is out of line, numberLastChar - index of last element of line;
            if(numberLastElement > text.Length)
            {
                numberLastElement = text.Length - 1;
            }
            return text.Substring(numberFirstElement, numberLastElement - numberFirstElement);
        }

        /// <summary>
        /// Object's ovveride method returns description.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Description: {Description}";
        }

        /// <summary>
        /// Object's ovveride method compares two object by GUID.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(Object obj)
        {
            if (obj is Identificator)
            {
                var discipline = (Identificator)obj;
                return (MyGuid == discipline.MyGuid) ? true : false;
            }
            return false;
        }

    }
}
