using System;

namespace Task_DEV_4
{
    /// <summary>
    /// Class extends string.
    /// </summary>
    static class ExtentionClass
    {
        /// <summary>
        /// Extension method for string assigning GUID to object.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="identifator"></param>
        public static string GuidToString(this string str)
        {
            Guid guid = Guid.NewGuid();
            //identificator.MyGuid = guid.ToString();
            return guid.ToString();
        }
    }
}
