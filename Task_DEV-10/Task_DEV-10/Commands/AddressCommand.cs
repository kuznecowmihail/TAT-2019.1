using System;
using System.Linq;

namespace Task_DEV_10
{
    /// <summary>
    /// The class for pattern command.
    /// </summary>
    public class AddressCommand : ICommand
    {
        Shop Shop { get; }
        AddressCreater HandlerAddress { get; }
        FinderID FinderID { get; }
        XMLFileHandler XMLFileHandler { get; }
        string PathXML { get; } = "../../InformationXML/addresses.xml";
        public event Action<ICommand> UpdateData;

        /// <summary>
        /// Constructor of AddressCommand.
        /// </summary>
        /// <param name="shop"></param>
        public AddressCommand(Shop shop)
        {
            this.Shop = shop;
            this.HandlerAddress = new AddressCreater();
            this.FinderID = new FinderID();
            this.XMLFileHandler = new XMLFileHandler();
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void WriteToXML()
        {
            XMLFileHandler.WriteToXML(PathXML, Shop.addresses);
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void AddNewElement()
        {
            Address address = HandlerAddress.CreateAddress(Shop.addresses);
            Shop.AddNewElement(Shop.addresses, address);
            UpdateData?.Invoke(this);
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DeleteElement()
        {
            int id = FinderID.FindID(Shop.addresses.Select(t => t.ID).ToList());

            if (Shop.products.Where(t => t.AddressID == id).Count() == 0)
            {
                Address address = Shop.addresses.Where(t => t.ID == id).First();
                Shop.DeleteElement(Shop.addresses, address);
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
            Shop.DisplayAllInformation(Shop.addresses);
        }
    }
}
