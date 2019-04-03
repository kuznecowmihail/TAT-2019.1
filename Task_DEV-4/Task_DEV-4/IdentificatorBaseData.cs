using System;
using System.IO;
using System.Text;
using System.Threading;

namespace Task_DEV_4
{
    /// <summary>
    /// Base abstract class of Discipline, Lecture, Seminar and LaboratoryLesson.
    /// </summary>
    public abstract class IdentificatorBaseData
    {
        public string MyGuid { get; protected set; }
        public string Description { get; protected set; }
        protected static string Text { get; private set; }
        protected Random random;
        private const int restriction = 256;
        protected const int minValue = 1;
        protected const int maxValue = 5;

        /// <summary>
        /// Constructor of IdentificatorBaseData.
        /// </summary>
        public IdentificatorBaseData()
        {
            random = new Random(DateTime.Now.Millisecond);
            MyGuid = MyGuid.GuidToString();
            Description = GetText(restriction);
        }

        /// <summary>
        /// Method returns text from file.
        /// </summary>
        /// <returns line.ToString()></returns>
        public string AddTextFromFile()
        {
            StringBuilder line = new StringBuilder();
            StreamReader reader = new StreamReader("../../text.txt");
            string partLine = string.Empty;

            if (reader.ReadLine() == null)
            {
                throw new Exception("File is empty.");
            }

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
            return line.ToString();
        }

        /// <summary>
        /// Method select part of text for description and other material.
        /// </summary>
        /// <param name="restriction">material size limit</param>
        /// <returns></returns>
        public string GetText(int restriction = 10)
        {
            int numberFirstElement;
            int numberLastElement;

            if (Text == null)
            {
                Text = AddTextFromFile();
            }
            // Set the edges of the text.
            numberFirstElement = random.Next(0, Text.Length);
            // Sleep for random value;
            Thread.Sleep(1);
            numberLastElement = random.Next(numberFirstElement + 1, numberFirstElement + restriction);

            // if numberLastChar is out of line, numberLastChar - index of last element of line;
            if (numberLastElement > Text.Length)
            {
                numberLastElement = Text.Length - 1;
            }

            // Choose part of text for other material.
            return Text.Substring(numberFirstElement, numberLastElement - numberFirstElement);
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
            if (obj is IdentificatorBaseData)
            {
                var discipline = (IdentificatorBaseData)obj;

                return (MyGuid == discipline.MyGuid);
            }

            return false;
        }
    }
}

