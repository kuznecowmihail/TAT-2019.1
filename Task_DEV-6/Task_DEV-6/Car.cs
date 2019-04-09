using System;

namespace Task_DEV_6
{
    /// <summary>
    /// Class have properties of car.
    /// </summary>
    public class Car
    {
        public string Brand { get; }
        public string Model { get; }
        public int Number { get; }
        public int Price { get; }

        /// <summary>
        /// Constructor of car.
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="model"></param>
        /// <param name="number"></param>
        /// <param name="price"></param>
        public Car(string brand, string model, int number, int price)
        {
            Brand = brand != string.Empty ? brand.ToLower() : throw new Exception("Brand is empty");
            Model = model;
            Number = number;
            Price = price;
        }
    }
}
