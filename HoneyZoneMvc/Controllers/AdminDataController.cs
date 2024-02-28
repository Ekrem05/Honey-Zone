using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.Infrastructure.Data.Models;
using HoneyZoneMvc.Infrastructure.ViewModels;
using HoneyZoneMvc.Infrastructure.ViewModels.CategoryViewModels;
using HoneyZoneMvc.Infrastructure.ViewModels.DTOs;
using HoneyZoneMvc.Infrastructure.ViewModels.OrderViewModels;
using HoneyZoneMvc.Infrastructure.ViewModels.ProductViewModels;
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
    public async Task<IActionResult> Index(string ErrorMessage)
    {
        AdminViewModel vm = new AdminViewModel();
        vm.Products = await productService.GetAllProductsAsync();
        vm.CategoryDtos = await categoryService.GetAllCategoriesAsync();
        vm.Orders = await orderService.GetAllOrdersAsync();
        vm.Categories = (await categoryService.GetAllCategoriesAsync()).Select(c=>new CategoryViewModel() { Name=c.Name, Id=c.Id.ToString()});
        vm.Users=new List<UserViewModel>();
        vm.ErrorMessage= ErrorMessage;
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
    [HttpGet]
    [ActionName("AddProductCategory")]
    public async Task<IActionResult> AddProductCategoryAsync()
    {
        return View("AddCategory");
    }
    [HttpPost]
    [ActionName("AddProductCategory")]
    public async Task<IActionResult> AddProductCategoryAsync(CategoryAddViewModel productvm)
    {
        if (await categoryService.AddCategoryAsync(productvm))
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

    [HttpPost]
    [ActionName("DeleteOrder")]
    public async Task<IActionResult> DeleteOrder(string Id)
    {
        var order = await orderService.GetOrderByIdAsync(Id);
        if (Id!=null&&order!=null)
        {
            await orderService.DeleteOrderAsync(Id);
            return RedirectToAction("Index");
        }
        return BadRequest();
    }
    [HttpPost]
    [ActionName("DeleteCategory")]
    public async Task<IActionResult> DeleteCategory(string Id)
    {
        if (await categoryService.DeleteCategoryAsync(Id))
        {
            return RedirectToAction(nameof(Index));
        }
        return RedirectToAction(nameof(Index), new { ErrorMessage = "Все още има продукти с тази категория!" });

    }
    [HttpPost]
    [ActionName("DeleteProduct")]
    public async Task<IActionResult> DeleteProduct(string Id)
    {
        if (await productService.DeleteProductAsync(Id))
        {
            return  RedirectToAction(nameof(Index));
        }
        return RedirectToAction(nameof(Index), new { ErrorMessage = "Продуктът все още се използва в поръчка!" });
    }



}

