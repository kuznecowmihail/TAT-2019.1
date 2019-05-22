using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Task_DEV_10
{
    /// <summary>
    /// Class manages products.
    /// </summary>
    public class Shop
    {
        public List<Product> Products { get; private set; }
        public List<Delivery> Deliveries { get; private set; }
        public List<Address> Addresses { get; private set; }
        public List<Manufacturer> Manufacturers { get; private set; }
        public List<WareHouse> WareHouses { get; private set; }

        /// <summary>
        /// Constructor of Shop.
        /// </summary>
        public Shop()
        {
            this.Products = new List<Product>();
            this.Deliveries = new List<Delivery>();
            this.Addresses = new List<Address>();
            this.Manufacturers = new List<Manufacturer>();
            this.WareHouses = new List<WareHouse>();
        }

        /// <summary>
        /// Method read json file and write to product list.
        /// </summary>
        public void ReadAndWriteProduct()
        {
            DataContractJsonSerializer jsonFormatter;

            using (var fileStream = new FileStream("../../Information/products.json", FileMode.OpenOrCreate))
            {
                jsonFormatter = new DataContractJsonSerializer(typeof(List<Product>));
                this.Products = (List<Product>)jsonFormatter.ReadObject(fileStream);
            }
        }

        /// <summary>
        /// Method read json file and write to delivery list.
        /// </summary>
        public void ReadAndWriteDelivery()
        {
            DataContractJsonSerializer jsonFormatter;

            using (var fileStream = new FileStream("../../Information/deliveries.json", FileMode.OpenOrCreate))
            {
                jsonFormatter = new DataContractJsonSerializer(typeof(List<Delivery>));
                this.Deliveries = (List<Delivery>)jsonFormatter.ReadObject(fileStream);
            }
        }

        /// <summary>
        /// Method read json file and write to address list.
        /// </summary>
        public void ReadAndWriteAddress()
        {
            DataContractJsonSerializer jsonFormatter;

            using (var fileStream = new FileStream("../../Information/addresses.json", FileMode.OpenOrCreate))
            {
                jsonFormatter = new DataContractJsonSerializer(typeof(List<Address>));
                this.Addresses = (List<Address>)jsonFormatter.ReadObject(fileStream);
            }
        }

        /// <summary>
        /// Method read json file and write to manufacturer list.
        /// </summary>
        public void ReadAndWriteManufacturer()
        {
            DataContractJsonSerializer jsonFormatter;

            using (var fileStream = new FileStream("../../Information/manufacturers.json", FileMode.OpenOrCreate))
            {
                jsonFormatter = new DataContractJsonSerializer(typeof(List<Manufacturer>));
                this.Manufacturers = (List<Manufacturer>)jsonFormatter.ReadObject(fileStream);
            }
        }

        /// <summary>
        /// Method read json file and write to ware house list.
        /// </summary>
        public void ReadAndWriteWareHouse()
        {
            DataContractJsonSerializer jsonFormatter;

            using (var fileStream = new FileStream("../../Information/warehouses.json", FileMode.OpenOrCreate))
            {
                jsonFormatter = new DataContractJsonSerializer(typeof(List<WareHouse>));
                this.WareHouses = (List<WareHouse>)jsonFormatter.ReadObject(fileStream);
            }
        }

        /// <summary>
        /// Method updates product json file.
        /// </summary>
        public void UpdateProductJsonFile()
        {
            DataContractJsonSerializer jsonFormatter;

            using (var fileStream = new FileStream("../../Information/goods.json", FileMode.Truncate))
            {
                jsonFormatter = new DataContractJsonSerializer(typeof(List<Product>));
                jsonFormatter.WriteObject(fileStream, Products);
            }
        }

        /// <summary>
        /// Method updates delivery json file.
        /// </summary>
        public void UpdateDeliveryJsonFile()
        {
            DataContractJsonSerializer jsonFormatter;

            using (var fileStream = new FileStream("../../Information/deliveries.json", FileMode.Truncate))
            {
                jsonFormatter = new DataContractJsonSerializer(typeof(List<Delivery>));
                jsonFormatter.WriteObject(fileStream, this.Deliveries);
            }
        }

        /// <summary>
        /// Method updates manufacturer json file.
        /// </summary>
        public void UpdateManufacturerJsonFile()
        {
            DataContractJsonSerializer jsonFormatter;

            using (var fileStream = new FileStream("../../Information/manufacturers.json", FileMode.Truncate))
            {
                jsonFormatter = new DataContractJsonSerializer(typeof(List<Manufacturer>));
                jsonFormatter.WriteObject(fileStream, this.Manufacturers);
            }
        }

        /// <summary>
        /// Method updates address json file.
        /// </summary>
        public void UpdateAddressJsonFile()
        {
            DataContractJsonSerializer jsonFormatter;

            using (var fileStream = new FileStream("../../Information/addresses.json", FileMode.Truncate))
            {
                jsonFormatter = new DataContractJsonSerializer(typeof(List<Address>));
                jsonFormatter.WriteObject(fileStream, this.Addresses);
            }
        }

        /// <summary>
        /// Method updates ware house json file.
        /// </summary>
        public void UpdateWareHouseJsonFile()
        {
            DataContractJsonSerializer jsonFormatter;

            using (var fileStream = new FileStream("../../Information/warehouses.json", FileMode.Truncate))
            {
                jsonFormatter = new DataContractJsonSerializer(typeof(List<WareHouse>));
                jsonFormatter.WriteObject(fileStream, this.WareHouses);
            }
        }

        /// <summary>
        /// Method adds new product.
        /// </summary>
        /// <param name="product"></param>
        public void AddNewProduct(Product product)
        {
            Products.Add(product);
        }

        /// <summary>
        /// Method deletes product with such id.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteProduct(int id)
        {
            foreach (var product in Products)
            {
                if (product.ID == id)
                {
                    Products.Remove(product);

                    return;
                }
            }
        }

        /// <summary>
        /// Method displays products to console.
        /// </summary>
        public void DisplayProducts()
        {
            foreach (var product in Products)
            {
                Console.WriteLine("________________________");
                Console.WriteLine($"ID: {product.ID}");
                Console.WriteLine($"Name: {product.Name}");
                Console.WriteLine($"Number: {product.Number}");
                Console.WriteLine($"Manufacturer ID: {product.ManufacturerID}");
                Console.WriteLine($"Ware House ID: {product.WareHouseID}");
                Console.WriteLine($"Delivery ID: {product.DeliveryID}");
                Console.WriteLine($"Address ID: {product.AddressID}");
                Console.WriteLine($"Manufacture Date: {product.ManufactureDate}");
            }
            Console.WriteLine("________________________");
        }

        /// <summary>
        /// Method adds new address to list.
        /// </summary>
        /// <param name="address"></param>
        public void AddNewAddress(Address address)
        {
            Addresses.Add(address);
        }

        /// <summary>
        /// Method deletes address.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteAddress(int id)
        {
            if (CheckOnUsingtoProduct(id) == false)
            {
                foreach (var address in Addresses)
                {
                    if (address.ID == id)
                    {
                        Addresses.Remove(address);

                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Method displays addresses to console.
        /// </summary>
        public void DisplaAddresses()
        {
            foreach (var address in Addresses)
            {
                Console.WriteLine("________________________");
                Console.WriteLine($"ID: {address.ID}");
                Console.WriteLine($"Country: {address.Country}");
                Console.WriteLine($"City: {address.City}");
                Console.WriteLine($"Street: {address.Street}");
                Console.WriteLine($"House Number: {address.HouseNumber}");
            }
            Console.WriteLine("________________________");
        }

        /// <summary>
        /// Method adds new delivery to list.
        /// </summary>
        /// <param name="delivery"></param>
        public void AddNewDelivery(Delivery delivery)
        {
            Deliveries.Add(delivery);
        }

        /// <summary>
        /// Method deletes delivery.
        /// </summary>
        public void DeleteDelivery(int id)
        {
            if (CheckOnUsingtoProduct(id) == false)
            {
                foreach (var delivery in Deliveries)
                {
                    if (delivery.ID == id)
                    {
                        Deliveries.Remove(delivery);

                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Method displays deliveries to console.
        /// </summary>
        public void DisplayDeliveries()
        {
            foreach (var delivery in Deliveries)
            {
                Console.WriteLine("________________________");
                Console.WriteLine($"ID: {delivery.ID}");
                Console.WriteLine($"Description: {delivery.Description}");
                Console.WriteLine($"Delivery Date: {delivery.DeliveryDate}");
            }
            Console.WriteLine("________________________");
        }

        /// <summary>
        /// Method adds new manufacturer.
        /// </summary>
        /// <param name="manufacturer"></param>
        public void AddNewManufacturer(Manufacturer manufacturer)
        {
            Manufacturers.Add(manufacturer);
        }

        /// <summary>
        /// Merthod deletes manufacturer.
        /// </summary>
        public void DeleteManufacturer(int id)
        {
            if (CheckOnUsingtoProduct(id) == false)
            {
                foreach (var manufacturer in Manufacturers)
                {
                    if (manufacturer.ID == id)
                    {
                        Manufacturers.Remove(manufacturer);

                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Method displays manufacturers to console.
        /// </summary>
        public void DisplayManufacturers()
        {
            foreach (var manufacturer in Manufacturers)
            {
                Console.WriteLine("________________________");
                Console.WriteLine($"ID: {manufacturer.ID}");
                Console.WriteLine($"Name: {manufacturer.Name}");
                Console.WriteLine($"Registrasion Address ID: {manufacturer.RegistrasionAddressID}");
                Console.WriteLine($"Country: {manufacturer.Country}");
            }
            Console.WriteLine("________________________");
        }

        /// <summary>
        /// Method ads new ware house.
        /// </summary>
        /// <param name="wareHouse"></param>
        public void AddNewWareHouse(WareHouse wareHouse)
        {
            WareHouses.Add(wareHouse);
        }

        /// <summary>
        /// Method deletes ware house.
        /// </summary>
        public void DeleteWareHouse(int id)
        {
            if (CheckOnUsingtoProduct(id) == false)
            {
                foreach (var wareHouse in WareHouses)
                {
                    if (wareHouse.ID == id)
                    {
                        WareHouses.Remove(wareHouse);

                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Method displays ware houses to console.
        /// </summary>
        public void DisplayWareHouses()
        {
            foreach (var wareHouse in WareHouses)
            {
                Console.WriteLine("________________________");
                Console.WriteLine($"ID: {wareHouse.ID}");
                Console.WriteLine($"Name: {wareHouse.Name}");
                Console.WriteLine($"Address ID: {wareHouse.AddressID}");
            }
            Console.WriteLine("________________________");
        }

        /// <summary>
        /// Method checks that this id use in some product.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckOnUsingtoProduct(int id)
        {
            foreach (var product in Products)
            {
                if (product.AddressID == id)
                {
                    Console.WriteLine("Sorry, this address using for product! Before delete this product!");

                    return true;
                }
            }

            return false;
        }
    }
}