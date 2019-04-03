using System;
using System.Text;

namespace Task_DEV_4
{
    /// <summary>
    /// Child class is one of the discipline materials.
    /// </summary>
    class LaboratoryLesson : IdentificatorBaseData, ICloneable
    {
        /// <summary>
        /// Constructor of class.
        /// </summary>
        public LaboratoryLesson() : base() { }

        /// <summary>
        /// Copy contructor of laboratoryLesson for clone.
        /// </summary>
        /// <param name="originalMyGuid">GUID for copy</param>
        /// <param name="originalDescription">Description for copy</param>
        public LaboratoryLesson(string originalMyGuid, string originalDescription)
        {
            MyGuid = originalMyGuid;
            Description = originalDescription;
        }

        /// <summary>
        /// Implemented interface method deeply copies object.
        /// </summary>
        /// <returns disciplineClone></returns>
        public object Clone() => new LaboratoryLesson(MyGuid, Description);

        /// <summary>
        /// Method add information to StringBuilder.
        /// </summary>
        /// <param name="allInformation"></param>
        public void AddAllInformationOfLaboratory(StringBuilder allInformation)
        {
            allInformation.Append($"*GUID: {this.MyGuid}.\n");
            allInformation.Append($"*{this.ToString()}.\n");
        }
    }
}
