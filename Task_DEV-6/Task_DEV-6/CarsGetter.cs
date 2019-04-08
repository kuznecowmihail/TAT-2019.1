using System;
using System.Collections.Generic;
using System.Xml;

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
        /// <param name="name"></param>
        public CarsGetter(string name)
        {
            XmlDocument = new XmlDocument();
            XmlDocument.Load($"../../{name}");
        }

        /// <summary>
        /// Method returns list of cars.
        /// </summary>
        /// <returns cars></returns>
        public List<Car> GetCars()
        {
            List<Car> cars = new List<Car>();
            XmlElement xmlElement = XmlDocument?.DocumentElement;
            string brand = string.Empty;
            string model = string.Empty;
            int number = 0;
            int price = 0;

            foreach(XmlNode xmlNode in xmlElement)
            {
                foreach(XmlNode xmlChild in xmlNode.ChildNodes)
                {
                    if(xmlChild.Name == "brand")
                    {
                        brand = xmlChild.InnerText;
                        continue;
                    }
                    
                    if(xmlChild.Name == "model")
                    {
                        model = xmlChild.InnerText;
                        continue;
                    }

                    if(xmlChild.Name == "number")
                    {
                        if (!Int32.TryParse(xmlChild.InnerText, out number))
                        {
                            throw new Exception("Incorrect count value");
                        }
                        continue;
                    }

                    if(xmlChild.Name == "price")
                    {
                        if (!Int32.TryParse(xmlChild.InnerText, out price))
                        {
                            throw new Exception("Incorrect count value");
                        }
                        continue;
                    }
                }
                cars.Add(new Car(brand, model, number, price));
            }

            return cars;
        }
    }
}
