using System;
using System.Linq;

namespace Task_DEV_10
{
    /// <summary>
    /// The class for pattern command.
    /// </summary>
    class WareHouseCommand : ICommand
    {
        Shop Shop { get; }
        WareHouseCreater HandlerWareHouse { get; }
        FinderID FinderID { get; }
        XMLFileHandler XMLFileHandler { get; }
        string PathXML { get; } = "../../InformationXML/warehouses.xml";
        public event Action<ICommand> UpdateData;

        /// <summary>
        /// Constructor of WareHouseCommand.
        /// </summary>
        /// <param name="shop"></param>
        public WareHouseCommand(Shop shop)
        {
            this.Shop = shop;
            this.HandlerWareHouse = new WareHouseCreater();
            this.FinderID = new FinderID();
            this.XMLFileHandler = new XMLFileHandler();
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void WriteToXML()
        {
            XMLFileHandler.WriteToXML(PathXML, Shop.wareHouses);
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void AddNewElement()
        {
            WareHouse wareHouse = HandlerWareHouse.CreateWareHouse(Shop.wareHouses);
            Shop.AddNewElement(Shop.wareHouses, wareHouse);
            UpdateData?.Invoke(this);
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DeleteElement()
        {
            int id = FinderID.FindID(Shop.wareHouses.Select(t => t.ID).ToList());

            if (Shop.products.Where(t => t.WareHouseID == id).Count() == 0)
            {
                WareHouse wareHouse = Shop.wareHouses.Where(t => t.ID == id).First();
                Shop.DeleteElement(Shop.wareHouses, wareHouse);
                UpdateData?.Invoke(this);
            }
            else
            {
                Console.WriteLine("Sorry, this id using in products, before delete product!");
            }
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DisplayElements()
        {
            Shop.DisplayAllInformation(Shop.wareHouses);
        }
    }
}
