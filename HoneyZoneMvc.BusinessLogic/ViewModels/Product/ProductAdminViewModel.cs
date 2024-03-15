namespace HoneyZoneMvc.BusinessLogic.ViewModels.Product
{
    public class ProductAdminViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string CategoryId { get; set; } = string.Empty;

        public double Price { get; set; }

        public bool IsDiscounted { get; set; }

        public double Discount { get; set; }

        public string Description { get; set; } = null!;

        public int TimesOrdered { get; set; }

        public int QuantityInStock { get; set; }

        public string ProductAmount { get; set; } = string.Empty;

        public string MainImageName { get; set; } = string.Empty;

        public string[] Images { get; set; } = null!;

    }
}
