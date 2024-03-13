using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Infrastructure.ViewModels.CartProduct;
using HoneyZoneMvc.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using static HoneyZoneMvc.Constraints.DataConstants;

namespace HoneyZoneMvc.BusinessLogic.Services
{
    public class CartProductService : ICartProductService
    {
        private ApplicationDbContext dbContext;
        private IProductService productService;

        public CartProductService(ApplicationDbContext _dbContext,IProductService _productService)
        {
            dbContext = _dbContext;
            productService = _productService;
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

        public async Task DeleteCartProductAsync(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor.HttpContext.Request.Cookies.ContainsKey("Cart"))
            {
                httpContextAccessor.HttpContext.Response.Cookies.Delete("Cart");
            }
            else
            {
                throw new InvalidOperationException();
            }
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

        public async Task AddOrUpdateCart(IHttpContextAccessor httpContextAccessor,string productId, int quantity)
        {
            
                var cartItems = await GetProductsFromCart(httpContextAccessor);
                var existingCartItem = cartItems
                    .Find(item => item.ProductId == productId);

                if (existingCartItem != null)
                {
                    existingCartItem.Quantity = quantity;
                }
                else
                {
                    cartItems.Add(new PostProductCartViewModel { ProductId = productId, Quantity = quantity });
                }

                var cartCookieValue = JsonConvert.SerializeObject(cartItems);
                httpContextAccessor.HttpContext.Response.Cookies.Append("Cart", cartCookieValue, new CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddDays(3) 
                });
            
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

        public async Task<double> GetCartSumAsync(IHttpContextAccessor httpContextAccessor)
        {
            var cartProducts=await GetProductsFromCart(httpContextAccessor);
            if (cartProducts.Count==0)
            {
                throw new ArgumentNullException();
            }
            var productSum= (await productService.GetAllProductsAsync())
                .Where(p=>cartProducts.Any(cp=>cp.ProductId==p.Id))
                .Select(p=>{
                    if (p.IsDiscounted)
                    {
                        p.Price = p.Price - (p.Price * p.Discount / 100);
                    }
                    return p.Price * cartProducts.FirstOrDefault(cp => cp.ProductId == p.Id).Quantity;
                
                })
                .Sum();
            return productSum;
        }


        public async Task<List<PostProductCartViewModel>> GetProductsFromCart(IHttpContextAccessor httpContextAccessor)
        {
            var httpContext = httpContextAccessor.HttpContext;
            List<PostProductCartViewModel> cartItems = new List<PostProductCartViewModel>();
            var existingCartCookie = httpContext.Request.Cookies["Cart"];
            if (!string.IsNullOrEmpty(existingCartCookie))
            {
                cartItems = JsonConvert.DeserializeObject<List<PostProductCartViewModel>>(existingCartCookie);
            }
            return cartItems.ToList();

        }

    }
}
