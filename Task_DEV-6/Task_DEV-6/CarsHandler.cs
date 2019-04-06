using System;
using System.Collections.Generic;
using System.Xml;

namespace Task_DEV_6
{
    /// <summary>
    /// Class handle request about cars.
    /// </summary>
    public class CarsHandler
    {
        XmlDocument XmlDocument { get; }

        /// <summary>
        /// Constructor of CarsHandler.
        /// </summary>
        /// <param name="xmlDocument"></param>
        public CarsHandler(XmlDocument xmlDocument)
        {
            XmlDocument = xmlDocument;
        }

        /// <summary>
        /// Method counts number of types.
        /// </summary>
        /// <returns></returns>
        public int CountTypes()
        {
            List<string> model = new List<string>();
            XmlElement xmlElement = XmlDocument?.DocumentElement;

            foreach(XmlNode xmlNode in xmlElement)
            {
                foreach (XmlNode xmlChild in xmlNode.ChildNodes)
                {
                    if(xmlChild.Name == "brand" && !model.Contains(xmlChild.InnerText))
                    {
                        model.Add(xmlChild.InnerText);
                    }
                }
            }

            return model.Count;
        }

        /// <summary>
        /// Method counts number of all cars.
        /// </summary>
        /// <returns></returns>
        public int CountAllCars()
        {
            int number = 0; 
            XmlElement xmlElement = XmlDocument?.DocumentElement;

            foreach (XmlNode xmlNode in xmlElement)
            {
                foreach (XmlNode xmlChild in xmlNode.ChildNodes)
                {
                    if (xmlChild.Name == "number")
                    {
                        number += Int32.Parse(xmlChild.InnerText);
                    }
                }
            }

            return number;
        }

        /// <summary>
        /// Method calculate average price of all cars.
        /// </summary>
        /// <returns></returns>
        public int CalculateAveragePrice()
        {
            int averagePrice = 0;
            int price = 0;
            int number = 0;
            XmlElement xmlElement = XmlDocument?.DocumentElement;

            foreach (XmlNode xmlNode in xmlElement)
            {
                foreach (XmlNode xmlChild in xmlNode.ChildNodes)
                {
                    if (xmlChild.Name == "price")
                    {
                        price = Int32.Parse(xmlChild.InnerText);
                    }

                    if (xmlChild.Name == "number")
                    {
                        number = Int32.Parse(xmlChild.InnerText);
                    }
                }
                averagePrice += price * number;
            }

            return averagePrice / CountAllCars();
        }

        /// <summary>
        /// Method calculates average price of one of car type.
        /// </summary>
        /// <param name="type">Model of car</param>
        /// <returns></returns>
        public int CalculateAveragePricaType(string type)
        {
            int averagePrice = 0;
            int averageNumber = 0;
            int price = 0;
            int number = 0;
            bool existence = false;
            XmlElement xmlElement = XmlDocument?.DocumentElement;

            foreach (XmlNode xmlNode in xmlElement)
            {
                    foreach (XmlNode xmlChild in xmlNode.ChildNodes)
                    {
                        if (xmlChild.Name == "brand" && xmlChild.InnerText == type)
                        {
                            foreach (XmlNode xmlchild in xmlNode.ChildNodes)
                            {
                                if (xmlchild.Name == "price")
                                {
                                    price = Int32.Parse(xmlchild.InnerText);
                                }

                                if (xmlchild.Name == "number")
                                {
                                    number = Int32.Parse(xmlchild.InnerText);
                                }
                            }
                            averagePrice += number * price;
                            averageNumber += number;
                            existence = true;
                        }
                    }
            }

            return existence != false ? averagePrice / averageNumber : 0;
        }
    }
}
