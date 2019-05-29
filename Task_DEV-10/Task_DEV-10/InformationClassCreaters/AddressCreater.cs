using System;
using System.Linq;
using System.Collections.Generic;

namespace Task_DEV_10
{
    /// <summary>
    /// Class handles address.
    /// </summary>
    public class AddressCreater : BaseInformationCreater
    {
        /// <summary>
        /// Method creates object of address, fill his and return.
        /// </summary>
        /// <returns>Object of address</returns>
        public Address CreateAddress(List<Address> addresses)
        {
            Address address = new Address();

            Console.WriteLine("Enter ID:");
            address.ID = GetIntNewID(addresses.Select(t => t.ID).ToList());

            Console.WriteLine("Enter country:");
            address.Country = GetStringValue();

            Console.WriteLine("Enter city:");
            address.City = GetStringValue();

            Console.WriteLine("Enter street:");
            address.Street = GetStringValue();

            Console.WriteLine("Enter house number:");
            address.HouseNumber = GetIntValue();

            return address;
        }
    }
}