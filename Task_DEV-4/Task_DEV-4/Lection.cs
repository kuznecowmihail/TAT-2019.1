using System;
using System.Collections.Generic;

namespace Task_DEV_4
{
    /// <summary>
    /// Class is one of the discipline materials compares discipline and clone discipline.
    /// </summary>
    class Lecture : Identificator, ICloneable
    {
        string material;
        Presentation presentation;
        // Composition: seminars and laboratory lessons cannot exist without lection.
        public List<Seminar> ListOfSeminars { get; }
        public List<LaboratoryLesson> ListOfLaboratoryLessons { get; }

        /// <summary>
        /// Constructor for Lecture.
        /// </summary>
        public Lecture() : base()
        {
            material = GetText(100000);
            presentation = new Presentation();
            presentation.Uri = $"{GetText()}.com";
            presentation.format = new Format();
            presentation.format = (Format)random.Next(0, 2);
            ListOfSeminars = new List<Seminar>();
            ListOfLaboratoryLessons = new List<LaboratoryLesson>();
            // Add seminars and laboratory lessons to list.
            for (int i =0; i < random.Next(1, 5); i++)
            {
                ListOfSeminars.Add(new Seminar());
            }
            for (int i = 0; i < random.Next(1, 5); i++)
            {
                ListOfLaboratoryLessons.Add(new LaboratoryLesson());
            }
        }

        /// <summary>
        /// Copy contructor of Lecture.
        /// </summary>
        /// <param name="originalSeminars">List of discipline seminars for copy</param>
        /// <param name="originalLaboratories">List of discipline laboratory lessons for copy</param>
        /// <param name="originalMyGuid">GUID for copy</param>
        /// <param name="originalDescription">Description for copy</param>
        public Lecture(List<Seminar> originalSeminars, List<LaboratoryLesson> originalLaboratories, string originalMyGuid, string originalDescription)
        {
            MyGuid = originalMyGuid;
            Description = originalDescription;
            ListOfSeminars = new List<Seminar>();
            ListOfLaboratoryLessons = new List<LaboratoryLesson>();
            foreach (var i in originalSeminars)
            {
                ListOfSeminars.Add((Seminar)i.Clone());
            }
            foreach (var i in originalLaboratories)
            {
                ListOfLaboratoryLessons.Add((LaboratoryLesson)i.Clone());
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
                var lection = (Identificator)obj;
                return (MyGuid == lection.MyGuid) ? true : false;

            }
            return false;
        }

        /// <summary>
        /// Implemented interface method deeply copies object.
        /// </summary>
        /// <returns disciplineClone></returns>
        public object Clone()
        {
            Lecture lectionClone = new Lecture(ListOfSeminars, ListOfLaboratoryLessons, MyGuid, Description);
            return lectionClone;
        }
    }
}
