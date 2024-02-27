using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.Infrastructure.Data.Models;
using HoneyZoneMvc.Infrastructure.Data.Models.ViewModels;
using HoneyZoneMvc.Infrastructure.Data.Models.ViewModels.OrderViewModels;
using HoneyZoneMvc.Infrastructure.Data.Models.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class AdminDataController : Controller
{
    private readonly IProductService productService;
    private readonly ICategoryService categoryService;
    private readonly IOrderService orderService;
    //private readonly IUserService userService;
    public AdminDataController(IProductService _productService, ICategoryService _categoryService, IOrderService _orderService/*, IUserService _userService*/)
    {
        productService = _productService;
        categoryService = _categoryService;
        orderService = _orderService;
        //userService = _userService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        AdminViewModel vm = new AdminViewModel();
        vm.Products = await productService.GetAllProductsAsync();
        vm.CategoryDtos = await categoryService.GetAllCategoriesAsync();
        vm.Orders = await orderService.GetAllOrdersAsync();
        vm.Categories = (await categoryService.GetAllCategoriesAsync()).Select(c=>new CategoryViewModel() { Name=c.Name, Id=c.Id.ToString()});
        vm.Users=new List<UserViewModel>();
        //vm.Users= (await userService.GetAllUsersAsync()); 
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
    [HttpGet]
    [ActionName("OrderInformation")]
    public async Task<IActionResult> OrderInformation(string Id)
    {
        var orderInfo= await orderService.GetOrderDetailsAsync(Id);
        return View(orderInfo); 
    }
    [HttpGet]
    [ActionName("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus(string Id)
    {
        var order=await orderService.GetOrderByIdAsync(Id);
        return View(order);
    }
    [HttpPost]
    [ActionName("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus(ChangeOrderStatusViewModel vm)
    {
        await orderService.ChangeStatusAsync(vm);
        return RedirectToAction("Index");
    }

    [HttpGet]
    [ActionName("DeleteOrder")]
    public async Task<IActionResult> DeleteOrder(string Id)
    {
        var order = await orderService.GetOrderByIdAsync(Id);
        if (Id!=null&&order!=null)
        {
            await orderService.DeleteOrder(Id);
            return RedirectToAction("Index");
        }
        return BadRequest();
    }

    //[HttpPost]
    //public IActionResult AddImageToModel(ProductDto productDto)
    //{
    //    var product = productService.GetProductById(productDto.Id);
    //    product.
    //}
}

