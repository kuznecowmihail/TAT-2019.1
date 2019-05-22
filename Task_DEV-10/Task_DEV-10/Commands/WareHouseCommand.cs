namespace Task_DEV_10
{
    /// <summary>
    /// The class for pattern command.
    /// </summary>
    class WareHouseCommand : ICommand
    {
        Shop Shop { get; }
        WareHouseCreater HandlerWareHouse { get; }
        FinderID FinderID { get; }

        /// <summary>
        /// Constructor of WareHouseCommand.
        /// </summary>
        /// <param name="shop"></param>
        public WareHouseCommand(Shop shop)
        {
            this.Shop = shop;
            this.HandlerWareHouse = new WareHouseCreater();
            this.FinderID = new FinderID(Shop);
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void ReadAndFillElements()
        {
            Shop.ReadAndWriteWareHouse();
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void UpdateJsonFile()
        {
            Shop.UpdateWareHouseJsonFile();
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void AddNewElement()
        {
            Shop.AddNewWareHouse(HandlerWareHouse.CreateWareHouse());
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DeleteElement()
        {
            Shop.DeleteWareHouse(FinderID.FindWareHouseID());
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DisplayElements()
        {
            Shop.DisplayWareHouses();
        }
    }
}
