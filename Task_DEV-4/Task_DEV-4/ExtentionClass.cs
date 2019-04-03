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
        /// <param name="line"></param>
        public static string GuidToString(this string line) => Guid.NewGuid().ToString();
    }
}
