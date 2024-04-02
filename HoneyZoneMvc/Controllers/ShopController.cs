using AutoMapper;
using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.BusinessLogic.ViewModels;
using HoneyZoneMvc.BusinessLogic.ViewModels.CartProduct;
using HoneyZoneMvc.BusinessLogic.ViewModels.CategoryViewModels;
using HoneyZoneMvc.BusinessLogic.ViewModels.Delivery;
using HoneyZoneMvc.BusinessLogic.ViewModels.Order;
using HoneyZoneMvc.BusinessLogic.ViewModels.Product;
using HoneyZoneMvc.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static HoneyZoneMvc.Common.Messages.ExceptionMessages;
using static HoneyZoneMvc.Common.Messages.SuccessfulMessages;


namespace HoneyZoneMvc.Controllers
{
    /// <summary>
    /// Controller responsible for handling shop operations.
    /// </summary>
    public class ShopController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly ICartProductService cartProductService;
        private readonly IOrderService orderService;
        private readonly IDeliveryService deliveryService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private IMapper mapper;

        public ShopController(IProductService _productService,
            ICategoryService _categoryService,
            ICartProductService _cartProductService,
            IOrderService _orderService,
            IDeliveryService _deliveryService,
            IHttpContextAccessor _httpContextAccessor,
            IMapper _mapper)
        {
            productService = _productService;
            categoryService = _categoryService;
            cartProductService = _cartProductService;
            mapper = _mapper;
            orderService = _orderService;
            deliveryService = _deliveryService;
            httpContextAccessor = _httpContextAccessor;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string? category, string? searchBy, string? bestSellers)
        {
            ShopViewModel vm = new ShopViewModel();
            List<ProductAdminViewModel> products = new List<ProductAdminViewModel>();
            try
            {
                if (bestSellers != null)
                {
                    products = (await productService.GetBestSellersAsync()).Select(p => mapper.Map<ProductAdminViewModel>(p)).ToList();
                }

                else if (category != null)
                {
                    products = (await productService.GetByCategoryNameAsync(category)).ToList();
                }
                else if (searchBy != null)
                {
                    products = (await productService.SearchAsync(searchBy)).ToList();
                    var model = products.Select(p => mapper.Map<ProductShopCardViewModel>(p)).ToList();
                    return PartialView("_ProductsInShopPartialView", model);
                }
                else
                    products = (await productService.AllAsync()).ToList();

                vm.Products = mapper.Map<List<ProductShopCardViewModel>>(products);
                var categories = await categoryService.AllAsync();
                vm.Categories = categories.Select(c => new CategoryViewModel()
                {
                    Id = c.Id.ToString(),
                    Name = c.Name
                }).ToList();

                return View(vm);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpGet]
        public async Task<IActionResult> ViewProduct(string Id)
        {
            if (Id == null)
            {
                TempData["Message"] = GeneralException;
                return RedirectToAction("Error", "Home", new { statusCode = 404 });
            }
            try
            {
                var productDto = await productService.GetByIdAsync(Id);
                var vm = mapper.Map<ProductShopDetailsViewModel>(productDto);
                return View(vm);
            }
            catch (Exception)
            {
                return StatusCode(404);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            try
            {
                var productsInCookie = await cartProductService.ProductsFromCartAsync(httpContextAccessor);
                List<ProductCartViewModel> productsInCart = new List<ProductCartViewModel>();
                foreach (var item in productsInCookie)
                {
                    var product = await productService.GetByIdAsync(item.ProductId);
                    productsInCart.Add(new ProductCartViewModel()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        IsDiscounted = product.IsDiscounted,
                        Discount = product.Discount,
                        MainImageName = product.MainImageName,
                        ProductAmount = product.ProductAmount,
                        Quantity = item.Quantity
                    });
                }
                return View(productsInCart);
            }
            catch (Exception)
            {
                return StatusCode(404);
            }

        }

        [HttpGet]
        public async Task<IActionResult> AddToCart(string Id)
        {
            if (Id == null)
            {
                return StatusCode(404);
            }
            try
            {

                await cartProductService.AddCartAsync(httpContextAccessor, Id, 1);
                var productsInCookie = await cartProductService.ProductsFromCartAsync(httpContextAccessor);

                List<ProductCartViewModel> productsInCart = new List<ProductCartViewModel>();
                foreach (var item in productsInCookie)
                {
                    var product = await productService.GetByIdAsync(item.ProductId);
                    productsInCart.Add(new ProductCartViewModel()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        IsDiscounted = product.IsDiscounted,
                        Discount = product.Discount,
                        MainImageName = product.MainImageName,
                        ProductAmount = product.ProductAmount,
                        Quantity = item.Quantity
                    });
                }
                return RedirectToAction("Cart", productsInCart);
            }
            catch (Exception)
            {
                return StatusCode(404);
            }

        }
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(string id)
        {
            if (id == null)
            {
                return StatusCode(404);
            }
            try
            {
                await cartProductService.RemoveProductFromCartAsync(httpContextAccessor, id);
                return RedirectToAction(nameof(Cart));
            }
            catch (Exception)
            {
                return StatusCode(404);
            }

        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CartConfirmed(List<PostProductCartViewModel> cartProducts)
        {
            if (cartProducts.Count == 0)
            {
                TempData["Message"] = CartIsEmpty;
                return RedirectToAction(nameof(Cart));
            }
            try
            {
                await cartProductService.UpdateCartAsync(httpContextAccessor, cartProducts);

                return RedirectToAction(nameof(OrderDetails));
            }
            catch (Exception)
            {
                return StatusCode(404);
            }

        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> OrderDetails()
        {

            try
            {
                var productsInCart = await cartProductService.ProductsFromCartAsync(httpContextAccessor);
                if (productsInCart.Count() == 0)
                {

                    TempData["Message"] = CartIsEmpty;
                    return RedirectToAction(nameof(Cart));
                }
                var ordervm = new OrderDetailViewModel();
                ordervm.TotalSum = (await cartProductService.CartSumAsync(httpContextAccessor)).ToString("F2");
                ordervm.DeliveryMethods = await GetDeliveryMethods();
                return View(ordervm);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> OrderConfirmed(OrderDetailViewModel dto)
        {

            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Invalid input";
                return RedirectToAction(nameof(OrderDetails));
            }
            try
            {
                var productsInCart = await cartProductService.ProductsFromCartAsync(httpContextAccessor);
                HashSet<OrderProduct> orderProducts = new HashSet<OrderProduct>();
                if (productsInCart.Count == 0)
                {
                    TempData["Error"] = CartIsEmpty;
                    return RedirectToAction(nameof(Cart));
                }
                foreach (var productItem in productsInCart)
                {
                    var product = await productService.GetByIdAsync(productItem.ProductId);

                    orderProducts.Add(new OrderProduct()
                    {
                        ProductId = Guid.Parse(productItem.ProductId),
                        Quantity = productItem.Quantity,
                    });

                }
                OrderAddViewModel vm = new OrderAddViewModel();
                vm.OrderDetail = dto;
                vm.ClientId = GetUserId().ToString();
                vm.DeliveryMethodId = dto.DeliveryMethodId;
                vm.OrderDate = DateTime.Now;
                vm.TotalSum = double.Parse((await cartProductService.CartSumAsync(httpContextAccessor)).ToString("F2"));
                vm.OrderProducts = orderProducts;
                await orderService.AddAsync(vm);
                await cartProductService.DeleteAsync(httpContextAccessor);
            }
            catch (InvalidOperationException)
            {
                TempData["Error"] = CartIsEmpty;
                return RedirectToAction(nameof(OrderDetails));
            }
            catch (Exception)
            {
                return StatusCode(404);
            }
            TempData["Message"] = OrderAdded;
            return RedirectToAction("MyOrders", "Profile");
        }

        private Guid GetUserId()
        {
            return Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
        private async Task<IEnumerable<DeliveryMethodViewModel>> GetDeliveryMethods()
        {
            try
            {
                return await deliveryService.AllAsync();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
    }
}
