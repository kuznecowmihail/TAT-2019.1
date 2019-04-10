namespace Task_DEV_6
{
    /// <summary>
    /// Class have properties of auto.
    /// </summary>
    public class Auto
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Number { get; set; }
        public int Price { get; set; }

        /// <summary>
        /// Constructor of Auto.
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="model"></param>
        /// <param name="number"></param>
        /// <param name="price"></param>
        public Auto(string brand, string model, int number, int price)
        {
            Brand = brand;
            Model = model;
            Number = number;
            Price = price;
        }
    }
}
