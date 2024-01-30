﻿using HoneyZoneMvc.Contracts;
using HoneyZoneMvc.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HoneyZoneMvc.Infrastructure.Data.Models;
using HoneyZoneMvc.Infrastructure.Data.Models.ViewModels;

public class AdminDataController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public AdminDataController(IProductService _productService,ICategoryService _categoryService)
        {
                productService = _productService;
                categoryService = _categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ProductViewModel vm= new ProductViewModel();
            vm.ProductDtos = await productService.GetAllProductsAsync();
            vm.CategoryDtos = await categoryService.GetAllCategoriesAsync();
            vm.ProductView = new ProductDto();
            return View(vm);
        }

        [HttpPost]
        [ActionName("AddProduct")]
        public async Task<IActionResult> AddProductAsync(ProductViewModel productvm)
        {
            if (await productService.AddProductAsync(productvm.ProductView))
            {
                return RedirectToAction("index");
            }
           return RedirectToAction("index");

        }
        [HttpPost]
        [ActionName("AddProductCategory")]
        public async Task<IActionResult> AddProductCategoryAsync(ProductViewModel productvm)
        {
                if (await categoryService.AddCategoryAsync(productvm.CategoryView))
                {
                    return RedirectToAction("index");
                }
            return RedirectToAction("index");

        }
    
        [HttpPost]
        public async Task<IActionResult> SubmitChanges(ProductViewModel productvm) {
            if (ModelState.IsValid)
            {
                if (productvm.ProductView.MainImageFile == null)
                {
                    ProductDto productBeforeUpdate = await productService.GetProductByIdAsync(productvm.ProductView.Id);
                    productvm.ProductView.MainImageName= productBeforeUpdate.MainImageName;

                }

                if(await productService.UpdateProductAsync(productvm.ProductView)) 
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

