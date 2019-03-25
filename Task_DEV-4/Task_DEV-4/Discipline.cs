using System;
using System.Collections.Generic;

namespace Task_DEV_4
{
    /// <summary>
    /// Class creates lectures for the discipline, compares discipline and clone discipline.
    /// </summary>
    class Discipline : Identificator, ICloneable
    {
        // Composition: lectures cannot exist without discipline.
        List<Lecture> lectures;

        /// <summary>
        /// Constructor of discipline.
        /// </summary>
        public Discipline() : base()
        {
            lectures = new List<Lecture>();
            // Add random number of lectures to list.
            for(int i = 0; i < random.Next(5, 10); i++)
            {
                lectures.Add(new Lecture());
            }
        }

        /// <summary>
        /// Copy contructor of discipline.
        /// </summary>
        /// <param name="orginalLections">List of discipline lectures for copy</param>
        /// <param name="originalMyGuid">GUID for copy</param>
        /// <param name="originalDescription">Description for copy</param>
        public Discipline(List<Lecture> orginalLections, string originalMyGuid, string originalDescription)
        {
            MyGuid = originalMyGuid;
            Description = originalDescription;
            lectures = new List<Lecture>();
            foreach (var i in orginalLections)
            {
                lectures.Add((Lecture)i.Clone());
            }
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

        /// <summary>
        /// Implemented interface method deeply copies object.
        /// </summary>
        /// <returns disciplineClone></returns>
        public object Clone()
        {
            Discipline disciplineClone = new Discipline(lectures, MyGuid, Description);
            return disciplineClone;
        }

        /// <summary>
        /// Indexer return to displa certain lecture and her seminars and laboratory lessons.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string this[int index]
        {
            get
            {
                return $"{index + 1}th lection: \n*seminars - {lectures[index].ListOfSeminars.Count}, \n*laboratories - {lectures[index].ListOfLaboratoryLessons.Count}.\n";
            }
        }
    }
}
