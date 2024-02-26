namespace HoneyZoneMvc.Infrastructure.Data.Models.ViewModels
{
    public class AdminViewModel
    {
        public IEnumerable<ProductDto> ProductDtos { get; set; }
        public IEnumerable<CategoryAddViewModel> CategoryDtos { get; set; }
        public IEnumerable<OrderBasicsViewModel> OrderDtos { get; set; }

        public ProductDto ProductView { get; set; }
        public CategoryAddViewModel CategoryView { get; set; }

    }
}
