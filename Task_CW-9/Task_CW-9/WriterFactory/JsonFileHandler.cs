using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Task9
{
    /// <summary>
    /// The class hadles json file.
    /// </summary>
    public class JsonFileHandler : IWriter
    {
        readonly string currenciesPath;

        /// <summary>
        /// Constructor of JsonFileHandler.
        /// </summary>
        /// <param name="path"></param>
        public JsonFileHandler(string path)
        {
            this.currenciesPath = $"../../Information/{path}";
        }

        /// <summary>
        /// The method writes data to json file.
        /// </summary>
        public void Write(List<Currency> currencies)
        {
            DataContractJsonSerializer jsonFormatter;

            using (var fileStream = new FileStream(currenciesPath, FileMode.OpenOrCreate))
            {
                jsonFormatter = new DataContractJsonSerializer(typeof(List<Currency>));
                jsonFormatter.WriteObject(fileStream, currencies);
            }
        }
    }
}
