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
        /// <returns auto></returns>
        public List<Auto> GetAuto()
        {
            int count = 0;
            List<Auto> auto = new List<Auto>();
            XmlElement xmlElement = XmlDocument.DocumentElement;

            foreach(XmlNode xmlNode in xmlElement)
            {
                // Create object of car and write values to properties.
                Auto car = new Auto();

                foreach (XmlNode xmlChild in xmlNode.ChildNodes)
                {
                    switch (xmlChild.Name)
                    {
                        case "brand":
                            car.Brand = xmlChild.InnerText != string.Empty ? xmlChild.InnerText.ToLower() : throw new Exception("Brand of car is empty");
                            continue;
                        case "model":
                            car.Model = xmlChild.InnerText != string.Empty ? xmlChild.InnerText.ToLower() : throw new Exception("Model of car is empty");
                            continue;
                        case "number":
                            car.Number = Int32.TryParse(xmlChild.InnerText, out count) == true ? count : throw new Exception("Incorrect number value of the car.");
                            continue;
                        case "price":
                            car.Price = Int32.TryParse(xmlChild.InnerText, out count) == true ? count : throw new Exception("Incorrect price value of the car.");
                            continue;
                        default:
                            continue;
                    }
                }
                auto.Add(car);
            }

            return auto;
        }
    }
}
