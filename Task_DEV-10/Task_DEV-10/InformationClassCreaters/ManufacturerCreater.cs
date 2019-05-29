using System;
using System.Linq;
using System.Collections.Generic;

namespace Task_DEV_10
{
    /// <summary>
    /// The class creates new manufacturer
    /// </summary>
    public class ManufacturerCreater : BaseInformationCreater
    {
        /// <summary>
        /// Method creates object of manufacturer, fill his and return.
        /// </summary>
        /// <returns>Object of address</returns>
        public Manufacturer CreateManufacturer(List<Manufacturer> manufacturers)
        {
            Manufacturer manufacturer = new Manufacturer();

            Console.WriteLine("Enter ID:");
            manufacturer.ID = GetIntNewID(manufacturers.Select(t => t.ID).ToList());

            Console.WriteLine("Enter name:");
            manufacturer.Name = GetStringValue();

            Console.WriteLine("Enter registrasion address ID:");
            manufacturer.RegistrasionAddressID = GetIntValue();

            Console.WriteLine("Enter country:");
            manufacturer.Country = GetStringValue();

            return manufacturer;
        }
    }
}