using System;
using System.Linq;

namespace Task_DEV_10
{
    /// <summary>
    /// The class for pattern command.
    /// </summary>
    public class ProductCommand : ICommand
    {
        Shop Shop { get; }
        ProductCreater ProductCreater { get; }
        FinderID FinderID { get; }
        XMLFileHandler XMLFileHandler { get; }
        string PathXML { get; } = "../../InformationXML/products.xml";
        public event Action<ICommand> UpdateData;

        /// <summary>
        /// Constructor of ProductCommand.
        /// </summary>
        public ProductCommand(Shop shop)
        {
            this.Shop = shop;
            this.ProductCreater = new ProductCreater();
            this.FinderID = new FinderID();
            this.XMLFileHandler = new XMLFileHandler();
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void WriteToXML()
        {
            XMLFileHandler.WriteToXML(PathXML, Shop.products);
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void AddNewElement()
        {
            Product product = ProductCreater.CreateProduct(Shop);
            Shop.AddNewElement(Shop.products, product);
            UpdateData?.Invoke(this);
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DeleteElement()
        {
            int id = FinderID.FindID(Shop.products.Select(t => t.ID).ToList());
            Product product = Shop.products.Where(t => t.ID == id).First();
            Shop.DeleteElement(Shop.products, product);
            UpdateData?.Invoke(this);
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DisplayElements()
        {
            Shop.DisplayAllInformation(Shop.products);
        }
    }
}
