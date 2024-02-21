﻿using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.Infrastructure.Data.Models;
using HoneyZoneMvc.Infrastructure.Data.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class AdminDataController : Controller
{
    private readonly IProductService productService;
    private readonly ICategoryService categoryService;

    public AdminDataController(IProductService _productService, ICategoryService _categoryService)
    {
        productService = _productService;
        categoryService = _categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        AdminViewModel vm = new AdminViewModel();
        vm.ProductDtos = await productService.GetAllProductsAsync();
        vm.CategoryDtos = await categoryService.GetAllCategoriesAsync();
        vm.CategoryDtos = await categoryService.GetAllCategoriesAsync();
        //GET ORDERS AND THEN DISPLAY THEM!
        //ADD DOWNLOADING FUNCTIONALLITY DOWNLOAD Business stats profit etc.
        vm.ProductView = new ProductDto();
        return View(vm);
    }

    [HttpPost]
    [ActionName("AddProduct")]
    public async Task<IActionResult> AddProductAsync(AdminViewModel productvm)
    {
        if (await productService.AddProductAsync(productvm.ProductView))
        {
            return RedirectToAction("index");
        }
        return RedirectToAction("index");

    }
    [HttpPost]
    [ActionName("AddProductCategory")]
    public async Task<IActionResult> AddProductCategoryAsync(AdminViewModel productvm)
    {
        if (await categoryService.AddCategoryAsync(productvm.CategoryView))
        {
            return RedirectToAction("index");
        }
        return RedirectToAction("index");

    }

    [HttpPost]
    public async Task<IActionResult> SubmitChanges(AdminViewModel productvm)
    {
        if (ModelState.IsValid)
        {
            if (productvm.ProductView.MainImageFile == null)
            {
                ProductDto productBeforeUpdate = await productService.GetProductByIdAsync(productvm.ProductView.Id.ToString());
                productvm.ProductView.MainImageName = productBeforeUpdate.MainImageName;

            }

            if (await productService.UpdateProductAsync(productvm.ProductView))
            {
                return RedirectToAction("Index");
            }
        }

        return Content("Unexpected Error");

    }

    //[HttpPost]
    //public IActionResult AddImageToModel(ProductDto productDto)
    //{
    //    var product = productService.GetProductById(productDto.Id);
    //    product.
    //}
}

