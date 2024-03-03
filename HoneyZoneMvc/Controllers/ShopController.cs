﻿using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.Infrastructure.ViewModels;
using HoneyZoneMvc.Infrastructure.ViewModels.DTOs;
using HoneyZoneMvc.Infrastructure.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HoneyZoneMvc.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly ICartProductService cartProductService;


        public ShopController(IProductService _productService,
            ICategoryService _categoryService,
            ICartProductService _cartProductService)
        {
            productService = _productService;
            categoryService = _categoryService;
            cartProductService = _cartProductService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string? category)
        {
            AdminViewModel vm = new AdminViewModel();
            vm.Products = await productService.GetAllProductsAsync();
            vm.CategoryDtos = await categoryService.GetAllCategoriesAsync();
            if (category != null)
            {
                var productsCategorized = await productService.GetProductsByCategoryAsync(category);
                vm.Products = productsCategorized;
            }

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> ViewProduct(string Id)
        {
            var productDto = await productService.GetProductByIdAsync(Id);
            var vm= new ProductShopDetailsViewModel()
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Price = productDto.Price,
                Description = productDto.Description,
                QuantityInStock = productDto.QuantityInStock,
                MainImageName = productDto.MainImageName,
                ImagesNames = productDto.Images.Select(x => x.Name).ToList()
            };

            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            var productsInCart = await productService.GetUserCartAsync(GetUserId().ToString());
            return View(productsInCart);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AddToCart(string Id)
        {
            bool successfull = await cartProductService.AddCartProductAsync(new CartProductDto()
            {
                BuyerId = GetUserId().ToString(),
                ProductId = Id
            });

            var productsInCart = await productService.GetUserCartAsync(GetUserId().ToString());

            return RedirectToAction("Cart", productsInCart);
        }
        [HttpPost]
        public async Task<IActionResult> CartConfirmed(List<PostProductCart> cartProducts)
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
