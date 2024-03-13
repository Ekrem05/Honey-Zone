using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Infrastructure.ViewModels.CartProduct;
using HoneyZoneMvc.Infrastructure.Data.Models;
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
        public async Task AddCartProductAsync(CartProductViewModel dto)
        {
            if (dto == null)
            {
                throw new InvalidOperationException();
            }
            if(!dbContext.Products.Any(p=>p.Id.ToString()==dto.ProductId))
            {
                throw new InvalidOperationException();
            }
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
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteCartProductAsync(string userId)
        {
            if (userId == null)
            {
                throw new ArgumentNullException();
            }
            var cartProduct = await dbContext.CartProducts
                .Where(cp => cp.ClientId == userId)
                .ToListAsync();
            if (cartProduct==null)
            {
                throw new ArgumentNullException();
            }
            var productsWithThisCart = await dbContext.Products
                .Include(p => p.CartProducts)
                .Where(p => p.CartProducts.Any(cp => cp.ClientId == userId)).ToListAsync();
            if (productsWithThisCart == null)
            {
                throw new InvalidOperationException();
            }
            productsWithThisCart.ForEach(p => p.CartProducts.Remove(cartProduct.FirstOrDefault(cp => cp.ProductId == p.Id)));
            dbContext.CartProducts.RemoveRange(cartProduct);
            await dbContext.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<CartProductViewModel>> GetCartByUserIdAsync(string userId)
        {
            if (userId == null)
            {
                throw new ArgumentNullException();
            }
            var cart = await dbContext.CartProducts
                .Where(cp => cp.ClientId == userId)
                .Select(cp => new CartProductViewModel()
                {
                    BuyerId = userId,
                    ProductId = cp.ProductId.ToString(),
                    Quantity = cp.Quantity
                })
                .ToListAsync();
            if (cart==null)
            {
                throw new InvalidOperationException();
            }
            return cart;
        }

        public async Task UpdateQuantityAsync(string productId, int quantity, string userId)
        {
            if (userId == null)
            {
                throw new ArgumentNullException();
            }
            if (productId == null)
            {
                throw new ArgumentNullException();
            }
            var product = await dbContext.Products
                .Include(p => p.CartProducts)
                .FirstOrDefaultAsync(p => p.Id.ToString() == productId);

            if (product == null) { throw new ArgumentNullException(); }

            var cartProduct = product.CartProducts
                 .FirstOrDefault(cp => cp.ClientId == userId);

            if (cartProduct == null) { throw new ArgumentNullException(); }

            cartProduct.Quantity = quantity;
             await dbContext.SaveChangesAsync();

        }
        public async Task<double> GetCartSumAsync(string userId)
        {
            if (userId == null)
            {
                throw new ArgumentNullException();
            }
            return await dbContext.CartProducts
                .Where(cp => cp.ClientId == userId)
                .Select(cp => (cp.Product.Price - ((cp.Product.Price * cp.Product.Discount) / 100)) * cp.Quantity)
                .SumAsync();
        }

    }
}
