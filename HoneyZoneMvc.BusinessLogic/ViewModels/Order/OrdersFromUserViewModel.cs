﻿using HoneyZoneMvc.BusinessLogic.ViewModels.Product;

namespace HoneyZoneMvc.BusinessLogic.ViewModels.Order
{
    public class OrdersFromUserViewModel
    {
        public string TotalSum { get; set; } = string.Empty;
        public string DeliveryMethod { get; set; } = string.Empty;
        public string OrderDate { get; set; } = string.Empty;
        public string ExpectedDelivery { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public List<ProductsOrderedUserViewModel> Products { get; set; } = new List<ProductsOrderedUserViewModel>();
    }
}
