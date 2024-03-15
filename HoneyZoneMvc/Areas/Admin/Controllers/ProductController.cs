﻿using AutoMapper;
using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.BusinessLogic.Services;
using HoneyZoneMvc.BusinessLogic.ViewModels.CategoryViewModels;
using HoneyZoneMvc.BusinessLogic.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using static HoneyZoneMvc.Common.Messages.ExceptionMessages;
using static HoneyZoneMvc.Common.Messages.SuccessfulMessages;
namespace HoneyZoneMvc.Areas.Admin.Controllers
{
    public class ProductController : BaseAdminController
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private IMapper mapper;

        public ProductController(IProductService _productService,
            ICategoryService _categoryService,
            IMapper _mapper)
        {
            productService = _productService;
            categoryService = _categoryService;
            mapper = _mapper;
        }

        [HttpGet]
        [ActionName("All")]
        public async Task<IActionResult> All([FromQuery] AllProductsQueryModel queryModel)
        {

            AllProductsQueryModel vm
                = await productService.AllAsync(queryModel.Category,
                queryModel.SearchTerm,
                queryModel.SortBy,
                queryModel.CurrentPage,
                queryModel.ProductsPerPage);

            queryModel.TotalProductsCount = vm.TotalProductsCount;
            queryModel.Categories = vm.Categories;
            queryModel.Products = vm.Products;

            return View(queryModel);
        }

        [HttpGet]
        [ActionName("AddProduct")]
        public async Task<IActionResult> AddProductAsync()
        {
            try
            {
                ProductAddViewModel productAddViewModel = new ProductAddViewModel();
                productAddViewModel.Categories = await categoryService.AllAsync();
                return View(productAddViewModel);
            }
            catch (Exception)
            {

                TempData["Error"] = GeneralException;
                return RedirectToAction(nameof(All));
            }

        }
        
        [HttpPost]
        [ActionName("SetDiscount")]
        public async Task<IActionResult> SetDiscountAsync(ProductDiscountViewModel vm)
        {

            if (!ModelState.IsValid)
            {
                TempData["Error"] = InvalidDiscountValue;
                return RedirectToAction(nameof(All));

            }
            try
            {
                await productService.SetDiscountAsync(vm);
                TempData["Success"] = DiscountSet;
                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                TempData["Error"] = GeneralException;
                return RedirectToAction(nameof(All));
            }

        }

        [HttpPost]
        [ActionName("SetDiscountByCategory")]
        public async Task<IActionResult> SetDiscountByCategory(DiscountByCategoryViewModel vm)
        {
            if (!await categoryService.ExistsAsync(vm.CategoryId))
            {
                TempData["Error"] = CategoryMessages.InvalidCategory;
                return RedirectToAction(nameof(All));
            }
            if (!ModelState.IsValid)
            {
                TempData["Error"] = InvalidDiscountValue;
                return RedirectToAction(nameof(All));
            }
            try
            {
                await productService.SetDiscountByCategoryAsync(vm.CategoryId, vm.Discount);
                TempData["Success"] = DiscountSetByCategory;
                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                TempData["Error"] = GeneralException;
                return RedirectToAction(nameof(All));
            }

        }

        [HttpPost]
        [ActionName("CancelDiscountByCategory")]
        public async Task<IActionResult> CancelDiscountByCategory(string Id)
        {
            var products = await productService.GetByCategoryIdAsync(Id);
            if (!await categoryService.ExistsAsync(Id))
            {
                TempData["Error"] = CategoryMessages.InvalidCategory;
                return RedirectToAction(nameof(All));
            }
            try
            {
                foreach (var product in products)
                {
                    if (product.IsDiscounted)
                    {
                        await productService.RemoveDiscountAsync(product.Id.ToString());
                    }
                }
                TempData["Success"] = DiscountsByCategoryCancelled;
                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                TempData["Message"] = GeneralException;
                return RedirectToAction(nameof(All));
            }
        }

        [HttpPost]
        [ActionName("RemoveDiscount")]
        public async Task<IActionResult> RemoveDiscount(string Id)
        {
            if (Id == null)
            {
                TempData["Error"] = IdNull;
                return RedirectToAction(nameof(Index));

            }
            var product = await productService.GetByIdAsync(Id);
            if (product == null)
            {
                TempData["Error"] = ProductMessages.ProductNotFound;
                return RedirectToAction(nameof(All));
            }
            if (product.IsDiscounted == false)
            {
                TempData["Error"] = ProductMessages.DiscountCannotBeCancelled;
                return RedirectToAction(nameof(All));
            }
            try
            {
                await productService.RemoveDiscountAsync(Id);
                TempData["Success"] = DiscountRemoved;
                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                TempData["Error"] = GeneralException;
                return RedirectToAction(nameof(All));
            }
        }

        [HttpGet]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit(string Id)
        {
            if (Id == null)
            {
                TempData["Error"] = IdNull;
                return RedirectToAction(nameof(All));
            }
            var item = await productService.GetByIdAsync(Id.ToString());
            ProductEditViewModel vm = mapper.Map<ProductEditViewModel>(item);
            if (vm == null)
            {
                TempData["Error"] = ProductMessages.ProductNotFound;
                return RedirectToAction(nameof(All));
            }
            try
            {
                vm.Categories = await categoryService.AllAsync();

                return View("EditProduct", vm);
            }
            catch (Exception)
            {
                TempData["Error"] = GeneralException;
                return RedirectToAction(nameof(All));
            }
        }

        [HttpPost]
        public async Task<IActionResult> SubmitChanges(ProductEditViewModel vm)
        {
            vm.Categories = await categoryService.AllAsync();
            var categoryExists = await categoryService.ExistsAsync(vm.CategoryId);
            if (!categoryExists)
            {
                ModelState.AddModelError(string.Empty, CategoryMessages.InvalidCategory);
                vm.Categories = await categoryService.AllAsync();
                return RedirectToAction(nameof(Edit), vm.Id);
            }

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, ModelStateInvalid);
                TempData["Error"] = ModelStateInvalid;
                vm.Categories = await categoryService.AllAsync();
                return RedirectToAction(nameof(Edit), new { Id = vm.Id });
            }
            try
            {
                await productService.UpdateAsync(vm);
                TempData["Success"] = ProductUpdated;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData["Error"] = GeneralException;
                vm.Categories = await categoryService.AllAsync();
                return RedirectToAction(nameof(Edit));

            }
        }

        [HttpPost]
        [ActionName("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(string Id)
        {
            var product = await productService.GetByIdAsync(Id);
            if (product == null)
            {
                TempData["Error"] = ProductMessages.ProductNotFound;
                return RedirectToAction(nameof(Index));
            }
            try
            {
                await productService.DeleteAsync(Id);
                TempData["Success"] = ProductDeleted;
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException e)
            {
                TempData["Error"] = e.Message;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData["Error"] = GeneralException;
                return RedirectToAction(nameof(Index));
            }
        }

    }
}
