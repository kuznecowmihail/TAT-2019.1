using System;
using System.Linq;

namespace Task_DEV_10
{
    /// <summary>
    /// The class for pattern command.
    /// </summary>
    public class ManufacturerCommand : ICommand
    {
        public event Action<ICommand> UpdateData;
        Shop Shop { get; }
        ManufacturerCreater HandlerManufacturer { get; }
        FinderID FinderID { get; }
        XMLFileHandler XMLFileHandler { get; }
        string PathXML { get; } = "../../InformationXML/manufacturers.xml";

        /// <summary>
        /// Constructor of ManufacturerCommand.
        /// </summary>
        public ManufacturerCommand(Shop shop)
        {
            this.Shop = shop;
            this.HandlerManufacturer = new ManufacturerCreater();
            this.FinderID = new FinderID();
            this.XMLFileHandler = new XMLFileHandler();
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void WriteToXML()
        {
            XMLFileHandler.WriteToXML(PathXML, Shop.manufacturers);
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void AddNewElement()
        {
            Manufacturer manufacturer = HandlerManufacturer.CreateManufacturer(Shop.manufacturers);
            Shop.AddNewElement(Shop.manufacturers, manufacturer);
            UpdateData?.Invoke(this);
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DeleteElement()
        {
            int id = FinderID.FindID(Shop.manufacturers.Select(t => t.ID).ToList());

            if (Shop.products.Where(t => t.ManufacturerID == id).Count() == 0)
            {
                Manufacturer manufacturer = Shop.manufacturers.Where(t => t.ID == id).First();
                Shop.DeleteElement(Shop.manufacturers, manufacturer);
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
            Shop.DisplayAllInformation(Shop.manufacturers);
        }
    }
}
