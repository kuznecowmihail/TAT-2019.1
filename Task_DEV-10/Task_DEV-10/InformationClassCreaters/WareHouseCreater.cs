using System;
using System.Linq;
using System.Collections.Generic;

namespace Task_DEV_10
{
    /// <summary>
    /// the class creates new ware house.
    /// </summary>
    public class WareHouseCreater : BaseInformationCreater
    {
        /// <summary>
        /// Method creates object of adware housedress, fill his and return.
        /// </summary>
        /// <returns>Object of address</returns>
        public WareHouse CreateWareHouse(List<WareHouse> wareHouses)
        {
            WareHouse wareHouse = new WareHouse();

            Console.WriteLine("Enter ID:");
            wareHouse.ID = GetIntNewID(wareHouses.Select(t => t.ID).ToList());

            Console.WriteLine("Enter name:");
            wareHouse.Name = GetStringValue();

            Console.WriteLine("Enter address ID:");
            wareHouse.AddressID = GetIntValue();

            return wareHouse;
        }
    }
}
