using System;
using System.Collections.Generic;

namespace Task_DEV_4
{
    /// <summary>
    /// Class is one of the discipline materials compares discipline and clone discipline.
    /// </summary>
    class Seminar : Identificator
    {
        List<string> tasks;
        List<string> questions;
        List<string> answerTheQuestions;

        /// <summary>
        /// Constructor for Seminar.
        /// </summary>
        public Seminar() : base()
        {
            tasks = new List<string>();
            questions = new List<string>();
            answerTheQuestions = new List<string>();
            // Add tasks, questions and answer the questions to list.
            for(int i = 0; i < random.Next(1,10); i++)
            {
                tasks.Add(GetText());
            }
            // Number of questions and answer the questions equals.
            for (int i = 0; i < random.Next(1, 10); i++)
            {
                questions.Add(GetText());
                answerTheQuestions.Add(GetText());
            }
        }

        /// <summary>
        /// Copy contructor of seminars.
        /// </summary>
        /// <param name="originalTasks">List of tasks for copy</param>
        /// <param name="originalQuestions">List of questions for copy</param>
        /// <param name="originalAnswerTheQuestions">List of answer the questions for copy</param>
        /// <param name="originalMyGuid">GUID for copy</param>
        /// <param name="originalDescription">Description for copy</param>
        public Seminar(List<string> originalTasks, List<string> originalQuestions, List<string> originalAnswerTheQuestions, string originalMyGuid, string originalDescription)
        {
            MyGuid = originalMyGuid;
            Description = originalDescription;
            tasks = new List<string>();
            questions = new List<string>();
            answerTheQuestions = new List<string>();
            foreach (var i in originalTasks)
            {
                tasks.Add(i);
            }
            foreach(var i in originalQuestions)
            {
                questions.Add(i);
            }
            foreach(var i in originalAnswerTheQuestions)
            {
                answerTheQuestions.Add(i);
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
                var seminar = (Identificator)obj;
                return (MyGuid == seminar.MyGuid) ? true : false;
            }
            return false;
        }

        /// <summary>
        /// Implemented interface method deeply copies object.
        /// </summary>
        /// <returns disciplineClone></returns>
        public object Clone()
        {
            Seminar seminarClone = new Seminar(tasks, questions, answerTheQuestions, MyGuid, Description);
            return seminarClone;
        }
    }
}
