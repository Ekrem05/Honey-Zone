namespace HoneyZoneMvc.BusinessLogic.ViewModels.Product
{
    public class ProductsOrderedUserViewModel
    {
        public bool IsDiscounted { get; set; }
        public string DiscountedPrice { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public string Quantity { get; set; } = string.Empty;
        public string ProductAmount { get; set; } = string.Empty;
    }
}
