using HoneyZoneMvc.Contracts;
using HoneyZoneMvc.Models.ViewModels;
using HoneyZoneMvc.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using HoneyZoneMvc.Models.Entities.Enums;
using Microsoft.EntityFrameworkCore;

    public class AdminDataController : Controller
    {
        private readonly IProductService productService;
        public AdminDataController(IProductService _productService)
        {
                productService = _productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await productService.GetAllProductsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(ProductDto product)
        {
            if (await productService.AddProductAsync(product))
            {
                return RedirectToAction("index");
            }
           return RedirectToAction("index");

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product=await productService.GetProductByIdAsync(id);
            return PartialView("EditProductPartialView", product);
        }
        [HttpPost]
        public async Task<IActionResult> SubmitChanges(ProductDto productDto) {
            if (ModelState.IsValid)
            {
                if (productDto.MainImageFile == null)
                {
                    ProductDto productBeforeUpdate = await productService.GetProductByIdAsync(productDto.Id);
                    productDto.MainImageName= productBeforeUpdate.MainImageName;

                }

                if(await productService.UpdateProductAsync(productDto)) 
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

