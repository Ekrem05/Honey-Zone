using HoneyZoneMvc.BusinessLogic.Contracts;
using HoneyZoneMvc.Contracts;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Infrastructure.Data.Models;
using HoneyZoneMvc.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.BusinessLogic.Services
{
    public class CartProductService : ICartProductService
    {
        private ApplicationDbContext dbContext;

        public CartProductService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task<bool> AddCartProductAsync(CartProductDto dto)
        {

            if (!dbContext.CartProducts.Any(cp => cp.ProductId.ToString() == dto.ProductId.ToString() && cp.ClientId.ToString() == dto.BuyerId.ToString()))
            {
                await dbContext.CartProducts.AddAsync(new CartProduct()
                {
                    ProductId = dto.ProductId,
                    ClientId = dto.BuyerId.ToString(),
                    Quantity = 1

                });
                return await dbContext.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<bool> UpdateQuantityAsync(string productId, int quantity,string userId)
        {
            var product=await dbContext.Products
                .FirstOrDefaultAsync(p => p.Id.ToString() == productId.ToString());
           var cartProduct= product.CartProducts
                .FirstOrDefault(cp => cp.ClientId == userId);
            cartProduct.Quantity= quantity;
            return await dbContext.SaveChangesAsync() > 0;

        }
    }
}
