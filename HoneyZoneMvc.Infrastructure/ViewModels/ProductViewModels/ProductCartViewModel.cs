namespace HoneyZoneMvc.Infrastructure.ViewModels.ProductViewModels
{
    public class ProductCartViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public bool IsDiscounted { get; set; }
        public double Discount { get; set; }
        public string MainImageName { get; set; } = string.Empty;
        public string ProductAmount { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
