using System;
using System.Linq;

namespace Task_DEV_10
{
    /// <summary>
    /// The class for pattern command.
    /// </summary>
    public class DeliveryCommand : ICommand
    {
        Shop Shop { get; }
        DeliveryCreater HandlerDelivery { get; }
        FinderID FinderID { get; }
        XMLFileHandler XMLFileHandler { get; }
        string PathXML { get; } = "../../InformationXML/deliveries.xml";
        public event Action<ICommand> UpdateData;

        /// <summary>
        /// Constructor of DeliveryCommand.
        /// </summary>
        public DeliveryCommand(Shop shop)
        {
            this.Shop = shop;
            this.HandlerDelivery = new DeliveryCreater();
            this.FinderID = new FinderID();
            this.XMLFileHandler = new XMLFileHandler();
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void WriteToXML()
        {
            XMLFileHandler.WriteToXML(PathXML, Shop.deliveries);
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void AddNewElement()
        {
            Delivery delivery = HandlerDelivery.CreateDelivery(Shop.deliveries);
            Shop.AddNewElement(Shop.deliveries, delivery);
            UpdateData?.Invoke(this);
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DeleteElement()
        {
            int id = FinderID.FindID(Shop.deliveries.Select(t => t.ID).ToList());

            if (Shop.products.Where(t => t.DeliveryID == id).Count() == 0)
            {
                Delivery delivery = Shop.deliveries.Where(t => t.ID == id).First();
                Shop.DeleteElement(Shop.deliveries, delivery);
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
            Shop.DisplayAllInformation(Shop.deliveries);
        }
    }
}
