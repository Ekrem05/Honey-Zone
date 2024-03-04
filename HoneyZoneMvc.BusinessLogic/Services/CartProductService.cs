using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Infrastructure.ViewModels.CartProduct;
using HoneyZoneMvc.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HoneyZoneMvc.BusinessLogic.Services
{
    public class CartProductService : ICartProductService
    {
        private ApplicationDbContext dbContext;

        public CartProductService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task<bool> AddCartProductAsync(CartProductViewModel dto)
        {
            var product = await dbContext.Products
              .Include(s => s.CartProducts)
              .FirstOrDefaultAsync(s => s.Id.ToString() == dto.ProductId);

            if (!product.CartProducts.Any(c => c.ClientId == dto.BuyerId.ToString()))
            {
                product.CartProducts.Add(new CartProduct()
                {
                    ProductId = Guid.Parse(dto.ProductId),
                    ClientId = dto.BuyerId.ToString(),
                    Quantity = dto.Quantity

                });
                return await dbContext.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<bool> DeleteCartProductAsync(string userId)
        {
            var cartProduct = await dbContext.CartProducts
                .Where(cp => cp.ClientId == userId)
                .ToListAsync();

            var productsWithThisCart = await dbContext.Products
                .Include(p => p.CartProducts)
                .Where(p => p.CartProducts.Any(cp => cp.ClientId == userId)).ToListAsync();
            productsWithThisCart.ForEach(p => p.CartProducts.Remove(cartProduct.FirstOrDefault(cp => cp.ProductId == p.Id)));
            dbContext.CartProducts.RemoveRange(cartProduct);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<CartProductViewModel>> GetCartByUserIdAsync(string userId)
        {
            var cart = await dbContext.CartProducts
                .Where(cp => cp.ClientId == userId)
                .Select(cp => new CartProductViewModel()
                {
                    BuyerId = userId,
                    ProductId = cp.ProductId.ToString(),
                    Quantity = cp.Quantity
                })
                .ToListAsync();
            return cart;
        }

        public async Task<bool> UpdateQuantityAsync(string productId, int quantity, string userId)
        {
            var product = await dbContext.Products
                .Include(p => p.CartProducts)
                .FirstOrDefaultAsync(p => p.Id.ToString() == productId);
            var cartProduct = product.CartProducts
                 .FirstOrDefault(cp => cp.ClientId == userId);
            cartProduct.Quantity = quantity;
            return await dbContext.SaveChangesAsync() > 0;

        }
        public async Task<double> GetCartSumAsync(string userId)
        {
            return await dbContext.CartProducts
                .Where(cp => cp.ClientId == userId)
                .Select(cp => (cp.Product.Price - ((cp.Product.Price * cp.Product.Discount) / 100)) * cp.Quantity)
                .SumAsync();
        }

    }
}
