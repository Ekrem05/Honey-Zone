namespace HoneyZoneMvc.Infrastructure.ViewModels.ProductViewModels
{
    public class ProductCartViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsDiscounted { get; set; }
        public double Discount { get; set; }
        public string MainImageName { get; set; }
        public string ProductAmount { get; set; }
        public int Quantity { get; set; }
    }
}
