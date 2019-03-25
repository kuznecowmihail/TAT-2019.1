using System;

namespace Task_DEV_4
{
    /// <summary>
    /// Class is one of the discipline materials compares discipline and clone discipline.
    /// </summary>
    class LaboratoryLesson : Identificator
    {
        /// <summary>
        /// Constructor of class.
        /// </summary>
        public LaboratoryLesson() : base() { }

        /// <summary>
        /// Copy contructor of laboratoryLesson.
        /// </summary>
        /// <param name="originalMyGuid">GUID for copy</param>
        /// <param name="originalDescription">Description for copy</param>
        public LaboratoryLesson(string originalMyGuid, string originalDescription)
        {
            MyGuid = originalMyGuid;
            Description = originalDescription;
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
                var laboratory = (Identificator)obj;
                return (MyGuid == laboratory.MyGuid) ? true : false;
            }
            return false;
        }

        /// <summary>
        /// Implemented interface method deeply copies object.
        /// </summary>
        /// <returns disciplineClone></returns>
        public object Clone()
        {
            LaboratoryLesson laboratoryClone = new LaboratoryLesson(MyGuid, Description);
            return laboratoryClone;
        }
    }
}
