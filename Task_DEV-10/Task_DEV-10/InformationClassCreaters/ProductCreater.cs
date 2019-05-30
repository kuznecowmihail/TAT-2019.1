using System;
using System.Linq;

namespace Task_DEV_10
{
    /// <summary>
    /// The class creates new product.
    /// </summary>
    public class ProductCreater : BaseInformationCreater
    {
        /// <summary>
        /// Method creates object of product, fill his and return.
        /// Check that new product has existing delivery, manufacturer, address, warehouse.
        /// </summary>
        /// <returns>Object of address</returns>
        public Product CreateProduct(Shop shop)
        {
            Product product = new Product();

            Console.WriteLine("Enter ID:");
            product.ID = GetIntNewID(shop.products.Select(t => t.ID).ToList());

            Console.WriteLine("Enter name:");
            product.Name = GetStringValue();

            Console.WriteLine("Enter number:");
            product.Number = GetIntValue();

            Console.WriteLine("Enter manufacturer date:");
            product.ManufactureDate = GetStringValue();

            Console.WriteLine("Enter existing address ID:");
            product.AddressID = GetIntExistingID(shop.addresses.Select(t => t.ID).ToList());

            Console.WriteLine("Enter existing delivery ID:");
            product.DeliveryID = GetIntExistingID(shop.deliveries.Select(t => t.ID).ToList());

            Console.WriteLine("Enter existing manufacturer ID:");
            product.ManufacturerID = GetIntExistingID(shop.manufacturers.Select(t => t.ID).ToList());

            Console.WriteLine("Enter existing ware house ID:");
            product.WareHouseID = GetIntExistingID(shop.wareHouses.Select(t => t.ID).ToList());

            return product;
        }
    }
}