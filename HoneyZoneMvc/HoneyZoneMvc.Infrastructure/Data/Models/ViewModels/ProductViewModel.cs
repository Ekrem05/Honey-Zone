﻿namespace HoneyZoneMvc.Infrastructure.Data.Models.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<ProductDto> ProductDtos { get; set; }
        public IEnumerable<CategoryDto> CategoryDtos { get; set; }
        public ProductDto ProductView { get; set; }
        public CategoryDto CategoryView { get; set; }

    }
}
