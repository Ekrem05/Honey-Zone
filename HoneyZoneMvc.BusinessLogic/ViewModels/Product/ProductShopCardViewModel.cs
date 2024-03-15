namespace HoneyZoneMvc.BusinessLogic.ViewModels.Product
{
    public class ProductShopCardViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string MainImageName { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
        public bool IsDiscounted { get; set; }
        public int QuantityInStock { get; set; }
        public double Discount { get; set; }

    }
}
