using HoneyZoneMvc.Infrastructure.Data.Models.Entities;
using HoneyZoneMvc.Infrastructure.ViewModels.CategoryViewModels;
using HoneyZoneMvc.Infrastructure.ViewModels.DTOs;
using HoneyZoneMvc.Infrastructure.ViewModels.OrderViewModels;

namespace HoneyZoneMvc.Infrastructure.ViewModels
{
    public class AdminViewModel
    {
        public IEnumerable<ProductDto> Products { get; set; }
        public IEnumerable<CategoryAddViewModel> CategoryDtos { get; set; }
        public IEnumerable<OrderInfoViewModel> Orders { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; }
        public IEnumerable<UserViewModel> Users { get; set; }

        public ProductDto ProductView { get; set; }
        public CategoryAddViewModel CategoryView { get; set; }

    }
}
