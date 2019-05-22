using System;

namespace Task_DEV_10
{
    public class FinderID
    {
        Shop Shop { get; }

        public FinderID(Shop shop)
        {
            this.Shop = shop;
        }

        public int FindProductID()
        {
            bool existenceID = false;
            int request = 0;

            while (existenceID == false)
            {
                Console.WriteLine("Enter existing ID: ");
                Int32.TryParse(Console.ReadLine(), out request);

                foreach (var product in Shop.Products)
                {
                    if (request == product.ID)
                    {
                        existenceID = true;

                        break;
                    }
                }
            }

            return request;
        }

        public int FindAddressID()
        {
            bool existenceID = false;
            int request = 0;

            while (existenceID == false)
            {
                Console.WriteLine("Enter existing ID: ");
                Int32.TryParse(Console.ReadLine(), out request);

                foreach (var address in Shop.Addresses)
                {
                    if (request == address.ID)
                    {
                        existenceID = true;

                        break;
                    }
                }
            }

            return request;
        }

        public int FindDeliveryID()
        {
            bool existenceID = false;
            int request = 0;

            while (existenceID == false)
            {
                Console.WriteLine("Enter existing ID: ");
                Int32.TryParse(Console.ReadLine(), out request);

                foreach (var delivery in Shop.Deliveries)
                {
                    if (request == delivery.ID)
                    {
                        existenceID = true;

                        break;
                    }
                }
            }

            return request;
        }

        public int FindManufacturerID()
        {
            bool existenceID = false;
            int request = 0;

            while (existenceID == false)
            {
                Console.WriteLine("Enter existing ID: ");
                Int32.TryParse(Console.ReadLine(), out request);

                foreach (var manufacturer in Shop.Manufacturers)
                {
                    if (request == manufacturer.ID)
                    {
                        existenceID = true;

                        break;
                    }
                }
            }

            return request;
        }

        public int FindWareHouseID()
        {
            bool existenceID = false;
            int request = 0;

            while (existenceID == false)
            {
                Console.WriteLine("Enter existing ID: ");
                Int32.TryParse(Console.ReadLine(), out request);

                foreach (var wareHouse in Shop.WareHouses)
                {
                    if (request == wareHouse.ID)
                    {
                        existenceID = true;

                        break;
                    }
                }
            }

            return request;
        }
    }
}
