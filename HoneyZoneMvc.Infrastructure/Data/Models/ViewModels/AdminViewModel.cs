using HoneyZoneMvc.Infrastructure.Data.Models.Entities;

namespace HoneyZoneMvc.Infrastructure.Data.Models.ViewModels
{
    public class AdminViewModel
    {
        public IEnumerable<ProductDto> Products { get; set; }
        public IEnumerable<CategoryAddViewModel> CategoryDtos { get; set; }
        public IEnumerable<OrderBasicsViewModel> Orders { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; }
        public IEnumerable<UserViewModel> Users { get; set; }

        public ProductDto ProductView { get; set; }
        public CategoryAddViewModel CategoryView { get; set; }

    }
}
