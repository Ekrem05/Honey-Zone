namespace HoneyZoneMvc.Infrastructure.ViewModels.ProductViewModels
{
    public class ProductShopDetailsViewModel
    {
        public Guid Id { get; set; } = Guid.Empty;

        public string Name { get; set; } = string.Empty;

        public double Price { get; set; }

        public bool IsDiscounted { get; set; }

        public double Discount { get; set; }

        public string Description { get; set; } = string.Empty;

        public int QuantityInStock { get; set; }

        public string MainImageName { get; set; } = string.Empty;

        public string MainImageUrl { get; set; } = string.Empty;

        public ICollection<string> ImagesNames { get; set; } = new List<string>();



    }
}
