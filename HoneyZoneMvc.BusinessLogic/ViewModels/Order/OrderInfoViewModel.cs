﻿using HoneyZoneMvc.BusinessLogic.ViewModels.Product;

namespace HoneyZoneMvc.BusinessLogic.ViewModels.Order
{
    public class OrderViewModel
    {
        public string Id { get; set; } = string.Empty;

        public string TotalSum { get; set; } = string.Empty;

        public string DeliveryMethod { get; set; } = string.Empty;

        public string ClientName { get; set; } = string.Empty;

        public string OrderDate { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public string ExpectedDelivery { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        public List<ProductOrderedAdminViewModel> Products { get; set; } = new List<ProductOrderedAdminViewModel>();
    }
}
