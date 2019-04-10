using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Task_DEV_6
{
    /// <summary>
    /// Class reed xml and return list.
    /// </summary>
    class AutoGetter
    {
        XDocument XDoc { get; }

        /// <summary>
        /// Constructor of AutoGetter.
        /// </summary>
        /// <param name="name">Name of XML</param>
        public AutoGetter(string name)
        {
            XDoc = new XDocument();
            XDoc = XDocument.Load($"../../{name}.xml");
        }

        /// <summary>
        /// Method returns list of auto.
        /// </summary>
        /// <returns autos></returns>
        public IEnumerable<Auto> GetAuto() => XDoc.Element("autos").Elements("auto").Select(t => new Auto(
                t.Element("brand").Value != string.Empty ? t.Element("brand").Value.ToLower() : throw new Exception("Brand is Empty."),
                t.Element("model").Value != string.Empty ? t.Element("model").Value.ToLower() : throw new Exception("Model is Empty."),
                Int32.TryParse(t.Element("number").Value, out int number) ? number : throw new Exception("Incorrect number value of the auto."),
                Int32.TryParse(t.Element("price").Value, out int price) ? price : throw new Exception("Incorrect price value of the auto.")
                ));
    }
}
