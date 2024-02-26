using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.Infrastructure.Data.Models;
using HoneyZoneMvc.Infrastructure.Data.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class AdminDataController : Controller
{
    private readonly IProductService productService;
    private readonly ICategoryService categoryService;
    private readonly IOrderService orderService;
    public AdminDataController(IProductService _productService, ICategoryService _categoryService, IOrderService orderService)
    {
        productService = _productService;
        categoryService = _categoryService;
        this.orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        AdminViewModel vm = new AdminViewModel();
        vm.ProductDtos = await productService.GetAllProductsAsync();
        vm.CategoryDtos = await categoryService.GetAllCategoriesAsync();
        vm.OrderDtos = await orderService.GetAllOrdersAsync();
        //ADD DOWNLOADING FUNCTIONALLITY DOWNLOAD Business stats profit etc.
        vm.ProductView = new ProductDto();
        return View(vm);
    }
    [HttpGet]
    [ActionName("AddProduct")]
    public async Task<IActionResult> AddProductAsync()
    {
        
        ProductAddViewModel productAddViewModel = new ProductAddViewModel();
        productAddViewModel.Categories = await categoryService.GetAllCategoriesAsync();
        return View(productAddViewModel);

    }
    [HttpPost]
    [ActionName("AddProduct")]
    public async Task<IActionResult> AddProductAsync(ProductAddViewModel productvm)
    {
        if (await productService.AddProductAsync(productvm))
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
    [HttpGet]
    [ActionName("Edit")]
    public async Task<IActionResult> Edit(string Id)
    {
        ProductEditViewModel item = await productService.GetProductEditByIdAsync(Id.ToString());
        item.Categories = await categoryService.GetAllCategoriesAsync();

        return View("EditProduct", item);

    }
    [HttpPost]
    public async Task<IActionResult> SubmitChanges(ProductEditViewModel vm)
    {
        if (ModelState.IsValid)
        {
            if (await productService.UpdateProductAsync(vm))
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

