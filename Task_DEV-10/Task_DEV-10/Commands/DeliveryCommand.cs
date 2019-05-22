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

        /// <summary>
        /// Constructor of DeliveryCommand.
        /// </summary>
        public DeliveryCommand(Shop shop)
        {
            this.Shop = shop;
            this.HandlerDelivery = new DeliveryCreater();
            this.FinderID = new FinderID(Shop);
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void ReadAndFillElements()
        {
            Shop.ReadAndWriteDelivery();
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void UpdateJsonFile()
        {
            Shop.UpdateDeliveryJsonFile();
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void AddNewElement()
        {
            Shop.AddNewDelivery(HandlerDelivery.CreateDelivery());
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DeleteElement()
        {
            Shop.DeleteDelivery(FinderID.FindDeliveryID());
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DisplayElements()
        {
            Shop.DisplayDeliveries();
        }
    }
}
