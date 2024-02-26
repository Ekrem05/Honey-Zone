namespace HoneyZoneMvc.Infrastructure.Data.Models.ViewModels
{
    public class AdminViewModel
    {
        public IEnumerable<ProductDto> ProductDtos { get; set; }
        public IEnumerable<CategoryDto> CategoryDtos { get; set; }
        public IEnumerable<OrderViewDto> OrderDtos { get; set; }

        public ProductDto ProductView { get; set; }
        public CategoryDto CategoryView { get; set; }

    }
}
