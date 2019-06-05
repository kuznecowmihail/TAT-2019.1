using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Task9
{
    /// <summary>
    /// The method handles xml file.
    /// </summary>
    public class XmlFileHandler : IWriter
    {
        readonly string currenciesPath;

        /// <summary>
        /// Constructor of XmlFileHandler.
        /// </summary>
        /// <param name="path"></param>
        public XmlFileHandler(string path)
        {
            this.currenciesPath = $"../../Information/{path}";
        }

        /// <summary>
        /// The method writes data to xml file.
        /// </summary>
        public void Write(List<Currency> currencies)
        {
            XmlSerializer xmlFormatter;

            using (var fileStream = new FileStream(currenciesPath, FileMode.OpenOrCreate))
            {
                xmlFormatter = new XmlSerializer(typeof(List<Currency>));
                xmlFormatter.Serialize(fileStream, currencies);
            }
        }
    }
}
