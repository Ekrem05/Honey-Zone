﻿using HoneyZoneMvc.Infrastructure.Data.Models;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface ICartProductService
    {

        Task<bool> AddCartProductAsync(CartProductDto dto);
        Task<bool> UpdateQuantityAsync(string productId, int quantity, string userId);
        Task<IEnumerable<CartProductDto>> GetCartByUserIdAsync(string userId);
        Task<bool> DeleteCartProductAsync(string userId);

    }
}