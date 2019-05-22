namespace Task_DEV_10
{
    /// <summary>
    /// The class for pattern command.
    /// </summary>
    public class ProductCommand : ICommand
    {
        Shop Shop { get; }
        ProductCreater ProductCreater { get; }
        FinderID FinderID { get; }

        /// <summary>
        /// Constructor of ProductCommand.
        /// </summary>
        public ProductCommand(Shop shop)
        {
            this.Shop = shop;
            this.ProductCreater = new ProductCreater(Shop);
            this.FinderID = new FinderID(Shop);
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void ReadAndFillElements()
        {
            Shop.ReadAndWriteProduct();
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void UpdateJsonFile()
        {
            Shop.UpdateProductJsonFile();
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void AddNewElement()
        {
            Shop.AddNewProduct(ProductCreater.CreateProduct());
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DeleteElement()
        {
            Shop.DeleteProduct(FinderID.FindProductID());
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DisplayElements()
        {
            Shop.DisplayProducts();
        }
    }
}
