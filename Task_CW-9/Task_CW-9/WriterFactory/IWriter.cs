using System.Collections.Generic;

namespace Task9
{
    /// <summary>
    /// Interface for factory pattern.
    /// </summary>
    public interface IWriter
    {
        /// <summary>
        /// The method writes list to file.
        /// </summary>
        /// <param name="currencies"></param>
        void Write(List<Currency> currencies);
    }
}
