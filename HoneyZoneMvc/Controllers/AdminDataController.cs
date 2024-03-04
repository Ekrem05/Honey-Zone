using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.Infrastructure.ViewModels;
using HoneyZoneMvc.Infrastructure.ViewModels.CategoryViewModels;
using HoneyZoneMvc.Infrastructure.ViewModels.OrderViewModels;
using HoneyZoneMvc.Infrastructure.ViewModels.ProductViewModels;
using HoneyZoneMvc.Infrastructure.ViewModels.User;
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
        vm.Orders = await orderService.GetAllOrdersAsync();
        vm.Categories = (await categoryService.GetAllCategoriesAsync()).Select(c => new CategoryViewModel() { Name = c.Name, Id = c.Id.ToString() });
        vm.Users = new List<UserViewModel>();
        vm.DiscountByCategoryViewModel = new DiscountByCategoryViewModel();
        vm.DiscountByCategoryViewModel.Categories = vm.Categories.Select(CategoryViewModel => new CategoryViewModel() { Name = CategoryViewModel.Name, Id = CategoryViewModel.Id });
        vm.ErrorMessage = ErrorMessage;
        //vm.Users= (await userService.GetAllUsersAsync()); 
        //ADD DOWNLOADING FUNCTIONALLITY DOWNLOAD Business stats profit etc.
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
        if (ModelState.IsValid)
        {
            if (await productService.AddProductAsync(productvm))
            {
                return RedirectToAction("index");
            }
        }
        return RedirectToAction("index");

    }
    [HttpPost]
    [ActionName("AddProductCategory")]
    public async Task<IActionResult> AddProductCategoryAsync(CategoryAddViewModel productvm)
    {
        var categories = await categoryService.GetAllCategoriesAsync();
        if (categories.Any(c => c.Name == productvm.Name))
        {
            return RedirectToAction("index", new { ErrorMessage = "Категорията вече съществува!" });
        }
        await categoryService.AddCategoryAsync(productvm);

        return RedirectToAction("index");

    }
    [HttpPost]
    [ActionName("SetDiscount")]
    public async Task<IActionResult> SetDiscountAsync(ProductDiscountViewModel vm)
    {
        if (await productService.SetDiscountAsync(vm))
        {
            return RedirectToAction("index");
        }
        return RedirectToAction("index");

    }
    [HttpPost]
    [ActionName("SetDiscountByCategory")]
    public async Task<IActionResult> SetDiscountByCategory(DiscountByCategoryViewModel vm)
    {
        if (ModelState.IsValid)
        {
            if (await productService.SetDiscountByCategoryAsync(vm.CategoryId, vm.Discount))
            {
                return RedirectToAction("index");
            }
        }
        return RedirectToAction("index", new { ErrorMessage = "Неуспешно!" });

    }
    [HttpPost]
    [ActionName("CancelDiscountByCategory")]
    public async Task<IActionResult> CancelDiscountByCategory(string Id)
    {
        var products = await productService.GetProductsByCategoryIdAsync(Id);
        foreach (var product in products)
        {
            if (product.IsDiscounted)
            {
                await productService.RemoveDiscountAsync(product.Id.ToString());
            }
        }
        return RedirectToAction("index");

    }
    [HttpPost]
    [ActionName("RemoveDiscount")]
    public async Task<IActionResult> RemoveDiscount(string Id)
    {
        var product = await productService.GetProductByIdAsync(Id);
        if (product.IsDiscounted == false)
        {
            return RedirectToAction("index", new { ErrorMessage = "Не може да премахнете промоцията на продукт, който няма промоция!" });
        }
        await productService.RemoveDiscountAsync(Id);

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

        return RedirectToAction("Edit", new { Id = vm.Id.ToString() });

    }
    [HttpGet]
    [ActionName("OrderInformation")]
    public async Task<IActionResult> OrderInformation(string Id)
    {
        var orderInfo = await orderService.GetOrderDetailsAsync(Id);
        return View(orderInfo);
    }
    [HttpGet]
    [ActionName("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus(string Id)
    {
        var order = await orderService.GetOrderByIdAsync(Id);
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
        if (Id != null && order != null)
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
            return RedirectToAction(nameof(Index));
        }
        return RedirectToAction(nameof(Index), new { ErrorMessage = "Продуктът все още се използва в поръчка!" });
    }



}

