using System;
using System.Text;
using System.Collections.Generic;

namespace Task_DEV_4
{
    /// <summary>
    /// Class creates lectures for the discipline, clone discipline.
    /// </summary>
    class Discipline : IdentificatorBaseData, ICloneable
    {
        // Composition: lectures cannot exist without discipline.
        public List<Lecture> listOfLectures;

        /// <summary>
        /// Constructor of discipline.
        /// </summary>
        public Discipline() : base()
        {
            listOfLectures = new List<Lecture>();

            // Add random number of lectures to list.
            for(int i = 0; i < random.Next(minValue, maxValue); i++)
            {
                listOfLectures.Add(new Lecture());
            }
        }

        /// <summary>
        /// Copy contructor of discipline for clone.
        /// </summary>
        /// <param name="orginalLections">List of discipline lectures for copy</param>
        /// <param name="originalMyGuid">GUID for copy</param>
        /// <param name="originalDescription">Description for copy</param>
        public Discipline(string originalMyGuid, string originalDescription, List<Lecture> orginalLections)
        {
            MyGuid = originalMyGuid;
            Description = originalDescription;
            listOfLectures = new List<Lecture>();

            foreach (var i in orginalLections)
            {
                listOfLectures.Add((Lecture)i.Clone());
            }
        }
        
        /// <summary>
        /// Implemented interface method deeply copies object.
        /// </summary>
        /// <returns disciplineClone></returns>
        public object Clone()
        {
            Discipline disciplineClone = new Discipline(MyGuid, Description, listOfLectures);

            return disciplineClone;
        }

        /// <summary>
        /// Indexer return to display certain lecture and her seminars and laboratory lessons.
        /// </summary>
        /// <param name="index">Number of lection</param>
        /// <returns></returns>
        public StringBuilder this[int index]
        {
            get
            {
                return AddAllInformation(listOfLectures[index], index); ;
            }
        }

        /// <summary>
        /// Method add information to StringBuilder.
        /// </summary>
        /// <param name="listOfLectures">Lecture of discipline</param>
        /// <param name="index">Number of lecture</param>
        /// <returns allInformation></returns>
        public StringBuilder AddAllInformation(Lecture listOfLectures, int index)
        {
            StringBuilder allInformation = new StringBuilder();
            allInformation.Append("_________________________________________Lecture Content___________________________________________________________\n");
            allInformation.Append($"{index + 1}th lection: seminars - {listOfLectures.listOfSeminars.Count}, laboratories - {listOfLectures.listOfLaboratoryLessons.Count}.\n");
            allInformation.Append("|||||||||||||||||||||||||||||||||||||||Detailed Description||||||||||||||||||||||||||||||||||||||||||||||||||||||||\n");
            allInformation.Append($"---Lection {index + 1}th:\n");
            listOfLectures.AddAllInformationOfLecture(allInformation);
            allInformation.Append("_____________________________________________End___________________________________________________________________\n");

            return allInformation;
        }
    }
}
