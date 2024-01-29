using HoneyZoneMvc.Contracts;
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
            vm.ProductDtoPattern = new ProductDto();
            return View(vm);
        }

        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> AddAsync(ProductViewModel productvm)
        {
            if (await productService.AddProductAsync(productvm.ProductDtoPattern))
            {
                return RedirectToAction("index");
            }
           return RedirectToAction("index");

        }
        //[HttpGet]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var product=await productService.GetProductByIdAsync(id);
        //    ProductViewModel productvm=new ProductViewModel();
        //    productvm.ProductDtoPattern = product;
        //    return PartialView("EditProductPartialView", productvm);
        //}
        [HttpPost]
        public async Task<IActionResult> SubmitChanges(ProductViewModel productvm) {
            if (ModelState.IsValid)
            {
                if (productvm.ProductDtoPattern.MainImageFile == null)
                {
                    ProductDto productBeforeUpdate = await productService.GetProductByIdAsync(productvm.ProductDtoPattern.Id);
                    productvm.ProductDtoPattern.MainImageName= productBeforeUpdate.MainImageName;

                }

                if(await productService.UpdateProductAsync(productvm.ProductDtoPattern)) 
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

