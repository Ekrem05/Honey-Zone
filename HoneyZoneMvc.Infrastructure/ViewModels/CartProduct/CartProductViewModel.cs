namespace HoneyZoneMvc.Infrastructure.ViewModels.CartProduct
{
    public class CartProductViewModel
    {
        public string ProductId { get; set; } = string.Empty;
        public string BuyerId { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
