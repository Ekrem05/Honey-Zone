using AutoMapper;
using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.BusinessLogic.Services;
using HoneyZoneMvc.Common.Messages;
using HoneyZoneMvc.Infrastructure.Data.Models;
using HoneyZoneMvc.Infrastructure.ViewModels;
using HoneyZoneMvc.Infrastructure.ViewModels.CartProduct;
using HoneyZoneMvc.Infrastructure.ViewModels.CategoryViewModels;
using HoneyZoneMvc.Infrastructure.ViewModels.Delivery;
using HoneyZoneMvc.Infrastructure.ViewModels.OrderViewModels;
using HoneyZoneMvc.Infrastructure.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static HoneyZoneMvc.Common.Messages.ExceptionMessages;
using static HoneyZoneMvc.Common.Messages.SuccessfulMessages;


namespace HoneyZoneMvc.Controllers
{
    [Authorize]
    public class ShopController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly ICartProductService cartProductService;
        private readonly IOrderService orderService;
        private readonly IDeliveryService deliveryService;

        private IMapper mapper;

        public ShopController(IProductService _productService,
            ICategoryService _categoryService,
            ICartProductService _cartProductService,
            IOrderService _orderService,
            IDeliveryService _deliveryService,
            IMapper _mapper)
        {
            productService = _productService;
            categoryService = _categoryService;
            cartProductService = _cartProductService;
            mapper = _mapper;
            orderService = _orderService;
            deliveryService = _deliveryService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index(string? category,string? searchBy,string? bestSellers)
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
                    products = (await productService.GetProductsByCategoryNameAsync(category)).ToList();
                }
                else if (searchBy != null)
                {
                    products = (await productService.SearchProductsAsync(searchBy)).ToList();
                    var model = products.Select(p => mapper.Map<ProductShopCardViewModel>(p)).ToList();
                    return PartialView("_ProductsInShopPartialView", model);
                }
                else
                    products = (await productService.GetAllProductsAsync()).ToList();

                vm.Products = mapper.Map<List<ProductShopCardViewModel>>(products);
                var categories = await categoryService.GetAllCategoriesAsync();
                vm.Categories = categories.Select(c => new CategoryViewModel()
                {
                    Id = c.Id.ToString(),
                    Name = c.Name
                }).ToList();

                return View(vm);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home",new {statusCode=500});
            }
           
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ViewProduct(string Id)
        {
            if (Id == null)
            {
                TempData["Message"] = GeneralException;
                return RedirectToAction("Error", "Home", new {statusCode=404});
            }
            try
            {
                var productDto = await productService.GetProductByIdAsync(Id);
                var vm = mapper.Map<ProductShopDetailsViewModel>(productDto);
                return View(vm);
            }
            catch (Exception)
            {

                TempData["Message"] = GeneralException;
                return RedirectToAction("Error", "Home", new { statusCode = 404 });
            }
           
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            try
            {
                var productsInCart = await productService.GetUserCartAsync(GetUserId().ToString());
                return View(productsInCart);
            }
            catch (Exception)
            {
                TempData["Message"] = GeneralException;
                return RedirectToAction("Error", "Home", new { statusCode = 404 });
            }
           
        }

        [HttpGet]
        public async Task<IActionResult> AddToCart(string Id)
        {
            if (Id==null)
            {
                TempData["Message"] = GeneralException;
                return RedirectToAction("Error", "Home", new { statusCode = 404 });
            }
            try
            {
               await cartProductService.AddCartProductAsync(new CartProductViewModel()
                {
                    BuyerId = GetUserId().ToString(),
                    ProductId = Id
                });

                var productsInCart = await productService.GetUserCartAsync(GetUserId().ToString());

                return RedirectToAction("Cart", productsInCart);
            }
            catch (Exception)
            {

                TempData["Message"] = GeneralException;
                return RedirectToAction("Error", "Home", new { statusCode = 404 });
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> CartConfirmed(List<PostProductCartViewModel> cartProducts)
        {
            if (cartProducts.Count==0)
            {
                TempData["Message"] = CartIsEmpty;
                return RedirectToAction(nameof(Cart));
            }
            try
            {
                foreach (var cartProduct in cartProducts)
                {
                    await cartProductService.UpdateQuantityAsync(cartProduct.Id, cartProduct.Quantity, GetUserId().ToString());
                }

                return RedirectToAction(nameof(OrderDetails));
            }
            catch (Exception)
            {
                TempData["Message"]=GeneralException;
                return RedirectToAction("Error", "Home", new { statusCode = 404 });
            }
           
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetails()
        {
            var productsInCart = await productService.GetUserCartAsync(GetUserId().ToString());

            if (productsInCart.Count()==0)
            {

                TempData["Message"] = CartIsEmpty;
                return RedirectToAction(nameof(Cart));
            }
            try
            {
                var ordervm = new OrderDetailViewModel();
                ordervm.TotalSum = (await cartProductService.GetCartSumAsync(GetUserId().ToString())).ToString("F2");
                ordervm.DeliveryMethods = await GetDeliveryMethods();
                return View(ordervm);
            }
            catch (Exception)
            {

                TempData["Error"] = GeneralException;
                return RedirectToAction("Error", "Home", new {statusCode=500});
            }

        }

        [HttpPost]
        public async Task<IActionResult> OrderConfirmed(OrderDetailViewModel dto)
        {

            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Invalid input";
                return RedirectToAction(nameof(OrderDetails));
            }
            try
            {
                var cart = await cartProductService.GetCartByUserIdAsync(GetUserId().ToString());
                List<OrderProduct> orderProducts = new List<OrderProduct>();

                foreach (var productItem in cart)
                {
                    var product = await productService.GetProductByIdAsync(productItem.ProductId);

                    orderProducts.Add(new OrderProduct()
                    {
                        ProductId = Guid.Parse(productItem.ProductId),
                        Quantity = productItem.Quantity,
                    });

                }
                var totalSumFormated = (await cartProductService.GetCartSumAsync(GetUserId().ToString())).ToString("F2");
                double totalSum = double.Parse(totalSumFormated);
                await orderService.AddAsync(GetUserId().ToString(), totalSum, dto.DeliveryMethodId, dto, orderProducts);
                await cartProductService.DeleteCartProductAsync(GetUserId().ToString());
            }
            catch (InvalidOperationException e)
            {
                TempData["Error"] = CartIsEmpty;
                return RedirectToAction(nameof(OrderDetails));
            }
            catch (Exception e)
            {
                TempData["Error"] = GeneralException;
                return RedirectToAction("Error", "Home", new { statusCode = 404 });
            }
            TempData["Message"] = OrderAdded;
            return RedirectToAction("MyOrders","Order");
        }

        private Guid GetUserId()
        {
            return Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
        private async Task<ICollection<DeliveryMethodViewModel>> GetDeliveryMethods()
        {
            try
            {
                return await deliveryService.GetAllAsync();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
    }
}
