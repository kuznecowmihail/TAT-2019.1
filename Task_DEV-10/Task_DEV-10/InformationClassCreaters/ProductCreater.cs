using System;

namespace Task_DEV_10
{
    /// <summary>
    /// The class creates new product.
    /// </summary>
    public class ProductCreater
    {
        Shop Shop { get; }
        Product Product { get; }
        bool existenceID;
        bool existenceNumber;
        bool existenceAddressID;
        bool existenceDeliveryID;
        bool existenceManufacturerID;
        bool existenceWareHouseID;

        /// <summary>
        /// Constructor of HandlerProduct.
        /// </summary>
        public ProductCreater(Shop shop)
        {
            this.Shop = shop;
            this.Product = new Product();
        }

        /// <summary>
        /// Method creates object of product, fill his and return.
        /// </summary>
        /// <returns>Object of address</returns>
        public Product CreateProduct()
        {
            Console.WriteLine("Enter ID:");

            while (existenceID == false)
            {
                if (Int32.TryParse(Console.ReadLine(), out int id))
                {
                    Product.ID = id;
                    existenceID = true;
                }
                else
                {
                    Console.WriteLine("Try again! Incorrect value");
                }
            }

            Console.WriteLine("Enter name:");
            Product.Name = Console.ReadLine();

            Console.WriteLine("Enter number:");

            while (existenceNumber == false)
            {
                if (Int32.TryParse(Console.ReadLine(), out int number))
                {
                    Product.Number = number;
                    existenceNumber = true;
                }
                else
                {
                    Console.WriteLine("Try again! Incorrect value");
                }
            }

            Console.WriteLine("Enter manufacturer date:");
            Product.ManufactureDate = Console.ReadLine();

            Console.WriteLine("Enter existing address ID:");

            while (existenceAddressID == false)
            {
                if (Int32.TryParse(Console.ReadLine(), out int addressID))
                {
                    foreach (var address in Shop.Addresses)
                    {
                        if (address.ID == addressID)
                        {
                            Product.AddressID = addressID;
                            existenceAddressID = true;

                            break;
                        }
                    }
                    Console.WriteLine("This address don't exists. Try again!");
                }
                else
                {
                    Console.WriteLine("Try again! Incorrect value");
                }
            }


            Console.WriteLine("Enter existing delivery ID:");

            while (existenceDeliveryID == false)
            {
                if (Int32.TryParse(Console.ReadLine(), out int deliveryID))
                {
                    foreach (var delivery in Shop.Deliveries)
                    {
                        if (delivery.ID == deliveryID)
                        {
                            Product.DeliveryID = deliveryID;
                            existenceDeliveryID = true;

                            break;
                        }
                        Console.WriteLine("This delivery don't exist. Try again!");
                    }
                }
                else
                {
                    Console.WriteLine("Try again! Incorrect value");
                }
            }

            Console.WriteLine("Enter existing manufacturer ID:");

            while (existenceManufacturerID == false)
            {
                if (Int32.TryParse(Console.ReadLine(), out int manufacturerID))
                {
                    foreach (var manufacturer in Shop.Manufacturers)
                    {
                        if (manufacturer.ID == manufacturerID)
                        {
                            Product.ManufacturerID = manufacturerID;
                            existenceManufacturerID = true;

                            break;
                        }
                        Console.WriteLine("This manufacturer don't exists. Try again!");
                    }
                }
                else
                {
                    Console.WriteLine("Try again! Incorrect value");
                }
            }

            Console.WriteLine("Enter existing ware house ID:");

            while (existenceWareHouseID == false)
            {
                if (Int32.TryParse(Console.ReadLine(), out int wareHouseID))
                {
                    foreach (var wareHouse in Shop.WareHouses)
                    {
                        if (wareHouse.ID == wareHouseID)
                        {
                            Product.WareHouseID = wareHouseID;
                            existenceWareHouseID = true;
                        }
                    }
                    Console.WriteLine("This warehouse don't exists. Try again!");
                }
                else
                {
                    Console.WriteLine("Try again! Incorrect value");
                }
            }

            return Product;
        }
    }
}
