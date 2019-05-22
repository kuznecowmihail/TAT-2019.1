namespace Task_DEV_10
{
    /// <summary>
    /// The class for pattern command.
    /// </summary>
    public class ManufacturerCommand : ICommand
    {
        Shop Shop { get; }
        ManufacturerCreater HandlerManufacturer { get; }
        FinderID FinderID { get; }

        /// <summary>
        /// Constructor of ManufacturerCommand.
        /// </summary>
        public ManufacturerCommand(Shop shop)
        {
            this.Shop = shop;
            this.HandlerManufacturer = new ManufacturerCreater();
            this.FinderID = new FinderID(Shop);
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void ReadAndFillElements()
        {
            Shop.ReadAndWriteManufacturer();
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void UpdateJsonFile()
        {
            Shop.UpdateManufacturerJsonFile();
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void AddNewElement()
        {
            Shop.AddNewManufacturer(HandlerManufacturer.CreateManufacturer());
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DeleteElement()
        {
            Shop.DeleteManufacturer(FinderID.FindManufacturerID());
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DisplayElements()
        {
            Shop.DisplayManufacturers();
        }
    }
}
