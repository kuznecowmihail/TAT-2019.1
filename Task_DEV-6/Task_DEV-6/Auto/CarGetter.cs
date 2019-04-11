using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Task_DEV_6
{
    /// <summary>
    /// Class singleton write cars to list from xml.
    /// </summary>
    class CarGetter
    {
        string NameXML { get; }
        public IEnumerable<Auto> Cars { get; }
        static CarGetter carGetter;

        /// <summary>
        /// Private constructor of AutoGetter.
        /// </summary>
        /// <param name="name">Name XML</param>
        private CarGetter(string name)
        {
            NameXML = name;
            Cars = GetAuto();
        }

        /// <summary>
        /// Returns object of class.
        /// </summary>
        /// <returns>object of AutoGetter</returns>
        public static CarGetter GetCarGetter(string name)
        {
            if (carGetter == null)
            {
                carGetter = new CarGetter(name);
            }

            return carGetter;
        }

        /// <summary>
        /// Method returns list of auto.
        /// </summary>
        /// <returns autos>List of autos</returns>
        public IEnumerable<Auto> GetAuto()
        {
            XDocument xDoc = new XDocument();
            xDoc = XDocument.Load($"../../{NameXML}.xml");
            return xDoc.Element("autos").Elements("auto").Select(t => new Auto(
                t.Element("brand").Value != string.Empty ? t.Element("brand").Value.ToLower() : throw new Exception("Brand is Empty."),
                t.Element("model").Value != string.Empty ? t.Element("model").Value.ToLower() : throw new Exception("Model is Empty."),
                Int32.TryParse(t.Element("number").Value, out int number) ? number : throw new Exception("Incorrect number value of the auto."),
                Int32.TryParse(t.Element("price").Value, out int price) ? price : throw new Exception("Incorrect price value of the auto.")
                ));
        }
    }
}
