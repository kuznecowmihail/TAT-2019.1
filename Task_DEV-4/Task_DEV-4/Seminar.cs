using System;
using System.Text;
using System.Collections.Generic;

namespace Task_DEV_4
{
    /// <summary>
    /// Child class is one of the discipline materials.
    /// </summary>
    class Seminar : IdentificatorBaseData, ICloneable
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
            for(int i = 0; i < random.Next(minValue, maxValue); i++)
            {
                tasks.Add(GetText());
            }

            // Number of questions and answer the questions equals.
            for (int i = 0; i < random.Next(minValue, maxValue); i++)
            {
                questions.Add(GetText());
                answerTheQuestions.Add(GetText());
            }
        }

        /// <summary>
        /// Copy contructor of seminars for clone.
        /// </summary>
        /// <param name="originalTasks">List of tasks for copy</param>
        /// <param name="originalQuestions">List of questions for copy</param>
        /// <param name="originalAnswerTheQuestions">List of answer the questions for copy</param>
        /// <param name="originalMyGuid">GUID for copy</param>
        /// <param name="originalDescription">Description for copy</param>
        public Seminar(string originalMyGuid, string originalDescription, List<string> originalTasks, List<string> originalQuestions, List<string> originalAnswerTheQuestions)
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
        /// Implemented interface method deeply copies object.
        /// </summary>
        /// <returns disciplineClone></returns>
        public object Clone()
        {
            Seminar seminarClone = new Seminar(MyGuid, Description, tasks, questions, answerTheQuestions);

            return seminarClone;
        }

        /// <summary>
        /// Method add information to StringBuilder.
        /// </summary>
        /// <param name="allInformation"></param>
        public void AddAllInformationOfSeminar(StringBuilder allInformation)
        {
            int indexOfTask = 1;
            int indexOfQuestion = 1;
            int indexOfAnswer = 1;
            allInformation.Append($"*GUID: {this.MyGuid}.\n");
            allInformation.Append($"*{this.ToString()}.\n");
            allInformation.Append("*Tasks:\n");

            foreach (var i in tasks)
            {
                allInformation.Append($"{indexOfTask}th: {i}?\n");
                indexOfTask++;
            }
            allInformation.Append("*Questions:\n");

            foreach (var i in questions)
            {
                allInformation.Append($"{indexOfQuestion}th: {i}?\n");
                indexOfQuestion++;
            }
            allInformation.Append("*Answer the questions:\n");

            foreach (var i in answerTheQuestions)
            {
                allInformation.Append($"{indexOfAnswer}th: {i}.\n");
                indexOfAnswer++;
            }
        }
    }
}
