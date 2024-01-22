using HoneyZoneMvc.Contracts;
using HoneyZoneMvc.Models.ViewModels;
using HoneyZoneMvc.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using HoneyZoneMvc.Models.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace HoneyZoneMvc.Controllers
{
    public class AdminDataController : Controller
    {
        private readonly IProductService productService;
        public AdminDataController(IProductService _productService)
        {
                productService = _productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products=productService.GetAllProducts();
            List<ProductDto> productsDto = new List<ProductDto>();
            foreach (var product in products)
            {
                productsDto.Add(new ProductDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    QuantityInStock = product.QuantityInStock,
                    ProductQuantity = product.ProductQuantity,
                    Category = product.Category.ToString()

                });
            }
            return View(productsDto);
        }

        [HttpPost]
        public IActionResult Add(ProductDto product)
        {
            if (productService.AddProduct(new Product()
            {
                Name = product.Name,
                Category = Enum.Parse<Category>(product.Category),
                Price = product.Price,
                Description = product.Description,
                QuantityInStock = product.QuantityInStock,
                ProductQuantity = product.ProductQuantity,
            }))
            {
                return RedirectToAction("index");
            }
           return RedirectToAction("index");

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product=productService.GetProductById(id);
            var ProductDto = new ProductDto()
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                QuantityInStock = product.QuantityInStock,
                ProductQuantity = product.ProductQuantity,
                Category = product.Category.ToString()
            };
            return PartialView("EditProductPartialView", ProductDto);
        }
        [HttpPost]
        public IActionResult SubmitChanges(ProductDto productDto) {
            bool result = false;
            if (ModelState.IsValid)
            {
               result=productService.UpdateProduct(new Product()
                {
                    Id = productDto.Id,
                    Name = productDto.Name,
                    Price = productDto.Price,
                    Description = productDto.Description,
                    ProductQuantity = productDto.ProductQuantity,
                    Category = Enum.Parse<Category>(productDto.Category),
                    QuantityInStock = productDto.QuantityInStock,
                });
            }
            if (result)
            {
                return RedirectToAction("Index");
            }
            return Content("Unexpected Error");
        
        }
    }
}
