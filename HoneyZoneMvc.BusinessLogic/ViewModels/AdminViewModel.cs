﻿using HoneyZoneMvc.BusinessLogic.ViewModels.CategoryViewModels;
using HoneyZoneMvc.BusinessLogic.ViewModels.OrderViewModels;
using HoneyZoneMvc.BusinessLogic.ViewModels.ProductViewModels;
using HoneyZoneMvc.BusinessLogic.ViewModels.User;

namespace HoneyZoneMvc.BusinessLogic.ViewModels
{
    public class AdminViewModel
    {
        public IEnumerable<ProductAdminViewModel> Products { get; set; } = new List<ProductAdminViewModel>();
        public IEnumerable<OrderInfoViewModel> Orders { get; set; } = new List<OrderInfoViewModel>();
        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
        public IEnumerable<UserViewModel> Users { get; set; } = new List<UserViewModel>();
        public DiscountByCategoryViewModel DiscountByCategoryViewModel { get; set; } = new DiscountByCategoryViewModel();
        

    }
}