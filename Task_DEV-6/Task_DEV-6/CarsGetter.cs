using System;
using System.Xml;
using System.Collections.Generic;

namespace Task_DEV_6
{
    /// <summary>
    /// Class reed xml and return list.
    /// </summary>
    class CarsGetter
    {
        XmlDocument XmlDocument { get; }

        /// <summary>
        /// Constructor of CarsGetter.
        /// </summary>
        /// <param name="name">Name of XML</param>
        public CarsGetter(string name)
        {
            this.XmlDocument = new XmlDocument();
            XmlDocument.Load($"../../{name}.xml");
        }

        /// <summary>
        /// Method returns list of cars.
        /// </summary>
        /// <returns cars></returns>
        public List<Car> GetCars()
        {
            int count = 0;
            List<Car> cars = new List<Car>();
            XmlElement xmlElement = XmlDocument.DocumentElement;

            foreach(XmlNode xmlNode in xmlElement)
            {
                // Create object of car and write values to properties.
                Car car = new Car();

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
                cars.Add(car);
            }

            return cars;
        }
    }
}
