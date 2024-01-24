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
                    Category = product.Category.ToString(),
                    MainImageName= product.MainImageName
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
                MainImageName=product.MainImageFile.FileName
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
                Category = product.Category.ToString(),
                MainImageName = product.MainImageName
            };
            return PartialView("EditProductPartialView", ProductDto);
        }
        [HttpPost]
        public IActionResult SubmitChanges(ProductDto productDto) {
            bool result = false;
            if (ModelState.IsValid)
            {
                if (productDto.MainImageFile == null)
            {
                string productCurrentImageName = productService.GetProductById(productDto.Id).MainImageName;
                result = productService.UpdateProduct(new Product()
                {
                    Id = productDto.Id,
                    Name = productDto.Name,
                    Price = productDto.Price,
                    Description = productDto.Description,
                    ProductQuantity = productDto.ProductQuantity,
                    Category = Enum.Parse<Category>(productDto.Category),
                    QuantityInStock = productDto.QuantityInStock,
                    MainImageName= productCurrentImageName

                });
            }
            else
            {
                result = productService.UpdateProduct(new Product()
                {
                    Id = productDto.Id,
                    Name = productDto.Name,
                    Price = productDto.Price,
                    Description = productDto.Description,
                    ProductQuantity = productDto.ProductQuantity,
                    Category = Enum.Parse<Category>(productDto.Category),
                    QuantityInStock = productDto.QuantityInStock,
                    MainImageName = productDto.MainImageFile.FileName
                });
            }
               
            }
            if (result)
            {
                return RedirectToAction("Index");
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

