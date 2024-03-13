using AutoMapper;
using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.Infrastructure.ViewModels;
using HoneyZoneMvc.Infrastructure.ViewModels.CartProduct;
using HoneyZoneMvc.Infrastructure.ViewModels.CategoryViewModels;
using HoneyZoneMvc.Infrastructure.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HoneyZoneMvc.Controllers
{
    [Authorize]
    public class ShopController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly ICartProductService cartProductService;
        private IMapper mapper;

        public ShopController(IProductService _productService,
            ICategoryService _categoryService,
            ICartProductService _cartProductService,IMapper _mapper)
        {
            productService = _productService;
            categoryService = _categoryService;
            cartProductService = _cartProductService;
            mapper = _mapper;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index(string? category,string? searchBy,string? bestSellers)
        {
            ShopViewModel vm = new ShopViewModel();
            List<ProductAdminViewModel> products = new List<ProductAdminViewModel>();
            if (bestSellers!=null)
            {
                products = (await productService.GetBestSellersAsync()).Select(p => mapper.Map<ProductAdminViewModel>(p)).ToList();
            }

            else if(category!=null)
            { 
                products = (await productService.GetProductsByCategoryNameAsync(category)).ToList();    
            }
            else if (searchBy != null)
            {
                products = (await productService.SearchProductsAsync(searchBy)).ToList();  
                var model= products.Select(p=>mapper.Map<ProductShopCardViewModel>(p)).ToList();
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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ViewProduct(string Id)
        {
            var productDto = await productService.GetProductByIdAsync(Id);
            var vm = mapper.Map<ProductShopDetailsViewModel>(productDto);

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            var productsInCart = await productService.GetUserCartAsync(GetUserId().ToString());
            return View(productsInCart);
        }


        [HttpGet]
        public async Task<IActionResult> AddToCart(string Id)
        {
            bool successfull = await cartProductService.AddCartProductAsync(new CartProductViewModel()
            {
                BuyerId = GetUserId().ToString(),
                ProductId = Id
            });

            var productsInCart = await productService.GetUserCartAsync(GetUserId().ToString());

            return RedirectToAction("Cart", productsInCart);
        }

        [HttpPost]
        public async Task<IActionResult> CartConfirmed(List<PostProductCartViewModel> cartProducts)
        {
            foreach (var cartProduct in cartProducts)
            {
                await cartProductService.UpdateQuantityAsync(cartProduct.Id, cartProduct.Quantity, GetUserId().ToString());
            }

            return RedirectToAction("OrderDetails", "Order");
        }



        private Guid GetUserId()
        {
            return Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
