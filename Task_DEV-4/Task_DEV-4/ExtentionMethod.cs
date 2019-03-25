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
        public static void GuidToString(this string str, Identificator identifator)
        {
            Guid guid = Guid.NewGuid();
            identifator.MyGuid = guid.ToString();
        }
    }
}
