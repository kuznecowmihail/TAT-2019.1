using System;
using System.Xml;
using System.Collections.Generic;

namespace Task_DEV_6
{
    /// <summary>
    /// Class reed xml and return list.
    /// </summary>
    class AutoGetter
    {
        XmlDocument XmlDocument { get; }

        /// <summary>
        /// Constructor of AutoGetter.
        /// </summary>
        /// <param name="name">Name of XML</param>
        public AutoGetter(string name)
        {
            XmlDocument = new XmlDocument();
            XmlDocument.Load($"../../{name}");
        }

        /// <summary>
        /// Method returns list of auto.
        /// </summary>
        /// <returns autos></returns>
        public List<Auto> GetAuto()
        {
            int count = 0;
            List<Auto> autos = new List<Auto>();
            XmlElement xmlElement = XmlDocument.DocumentElement;

            foreach(XmlNode xmlNode in xmlElement)
            {
                // Create object of auto and write values to properties.
                Auto auto = new Auto();

                foreach (XmlNode xmlChild in xmlNode.ChildNodes)
                {
                    switch (xmlChild.Name)
                    {
                        case "brand":
                            auto.Brand = xmlChild.InnerText != string.Empty ? xmlChild.InnerText.ToLower() : throw new Exception("Brand of auto is empty");
                            continue;
                        case "model":
                            auto.Model = xmlChild.InnerText != string.Empty ? xmlChild.InnerText.ToLower() : throw new Exception("Model of auto is empty");
                            continue;
                        case "number":
                            auto.Number = Int32.TryParse(xmlChild.InnerText, out count) == true ? count : throw new Exception("Incorrect number value of the auto.");
                            continue;
                        case "price":
                            auto.Price = Int32.TryParse(xmlChild.InnerText, out count) == true ? count : throw new Exception("Incorrect price value of the auto.");
                            continue;
                        default:
                            continue;
                    }
                }
                autos.Add(auto);
            }

            return autos;
        }

        public string AutoTypeGet() => XmlDocument.DocumentElement.Name;
    }
}
