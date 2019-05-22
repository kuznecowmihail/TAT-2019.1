namespace Task_DEV_10
{
    /// <summary>
    /// The class for pattern command.
    /// </summary>
    public class AddressCommand : ICommand
    {
        Shop Shop { get; }
        AddressCreater HandlerAddress { get; }
        FinderID FinderID { get; }

        /// <summary>
        /// Constructor of AddressCommand.
        /// </summary>
        /// <param name="shop"></param>
        public AddressCommand(Shop shop)
        {
            this.Shop = shop;
            this.HandlerAddress = new AddressCreater();
            this.FinderID = new FinderID(Shop);
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void ReadAndFillElements()
        {
            Shop.ReadAndWriteAddress();
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void UpdateJsonFile()
        {
            Shop.UpdateAddressJsonFile();
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void AddNewElement()
        {
            Shop.AddNewAddress(HandlerAddress.CreateAddress());
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DeleteElement()
        {
            Shop.DeleteAddress(FinderID.FindAddressID());
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DisplayElements()
        {
            Shop.DisplaAddresses();
        }
    }
}
