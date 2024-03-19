using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.BusinessLogic.ViewModels.CartProduct;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace HoneyZoneMvc.BusinessLogic.Services
{
    public class CartProductService : ICartProductService
    {
        private IProductService productService;

        public CartProductService(IProductService _productService)
        {
            productService = _productService;
        }

        public async Task DeleteAsync(IHttpContextAccessor httpContextAccessor)
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

        public async Task AddOrUpdateCart(IHttpContextAccessor httpContextAccessor, string productId, int quantity)
        {

            var cartItems = await ProductsFromCart(httpContextAccessor);
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
        public async Task RemoveProductFromCart(IHttpContextAccessor httpContextAccessor, string id)
        {
            var cartItems = await ProductsFromCart(httpContextAccessor);
            if (!cartItems.Any(p => p.ProductId == id))
            {
                throw new InvalidOperationException();
            }
            cartItems.RemoveAll(p => p.ProductId == id);
            var cartCookieValue = JsonConvert.SerializeObject(cartItems);
            httpContextAccessor.HttpContext?.Response.Cookies.Append("Cart", cartCookieValue, new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddDays(3)
            });
        }

        public async Task<double> CartSumAsync(IHttpContextAccessor httpContextAccessor)
        {
            var cartProducts = await ProductsFromCart(httpContextAccessor);
            if (cartProducts.Count == 0)
            {
                throw new ArgumentNullException();
            }
            var productSum = (await productService.AllAsync())
                .Where(p => cartProducts.Any(cp => cp.ProductId == p.Id))
                .Select(p =>
                {
                    if (p.IsDiscounted)
                    {
                        p.Price = p.Price - (p.Price * p.Discount / 100);
                    }
                    return p.Price * cartProducts.FirstOrDefault(cp => cp.ProductId == p.Id).Quantity;

                })
                .Sum();
            return productSum;
        }


        public async Task<List<PostProductCartViewModel>> ProductsFromCart(IHttpContextAccessor httpContextAccessor)
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
