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
        /// <summary>
        /// This method deletes the cart cookie.
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
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

        /// <summary>
        /// This method adds a product to the cart.
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Throws exception if the product is not found in the database </exception>
        public async Task AddCartAsync(IHttpContextAccessor httpContextAccessor, string productId, int quantity)
        {
            try
            {
                await productService.GetByIdAsync(productId);
            }
            catch (Exception)
            {
                throw new InvalidOperationException();
            }


            var cartItems = await ProductsFromCartAsync(httpContextAccessor);
            var existingCartItem = cartItems
                .Find(item => item.ProductId == productId);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += quantity;
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

        /// <summary>
        /// This method removes a product from the cart.
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Throws exception if the product is not found in the database</exception>
        public async Task RemoveProductFromCartAsync(IHttpContextAccessor httpContextAccessor, string id)
        {
            var cartItems = await ProductsFromCartAsync(httpContextAccessor);
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

        /// <summary>
        /// This method updates the cart.
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="cart"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task UpdateCartAsync(IHttpContextAccessor httpContextAccessor, List<PostProductCartViewModel> cart)
        {
            foreach (var item in cart)
            {
                if (item.Quantity <= 0||await productService.GetByIdAsync(item.ProductId)==null)
                {
                    throw new InvalidOperationException();
                }
            }   
            var productsFromCookie = await ProductsFromCartAsync(httpContextAccessor);
            foreach (var item in productsFromCookie)
            {
                item.Quantity = cart.FirstOrDefault(c => c.ProductId == item.ProductId).Quantity;
            }
            var cartCookieValue = JsonConvert.SerializeObject(productsFromCookie);
            httpContextAccessor.HttpContext.Response.Cookies.Append("Cart", cartCookieValue, new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddDays(3)
            });

        }

        /// <summary>
        /// This method calculates the sum of the products in the cart.
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<double> CartSumAsync(IHttpContextAccessor httpContextAccessor)
        {
            var cartProducts = await ProductsFromCartAsync(httpContextAccessor);
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

        /// <summary>
        /// This method gets the products from the cart.
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <returns></returns>
        public async Task<List<PostProductCartViewModel>> ProductsFromCartAsync(IHttpContextAccessor httpContextAccessor)
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
