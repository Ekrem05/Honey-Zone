using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.Common.Messages;
using HoneyZoneMvc.Infrastructure.ViewModels;
using HoneyZoneMvc.Infrastructure.ViewModels.CategoryViewModels;
using HoneyZoneMvc.Infrastructure.ViewModels.ProductViewModels;
using HoneyZoneMvc.Infrastructure.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static HoneyZoneMvc.Common.Messages.ExceptionMessages;
using static HoneyZoneMvc.Common.Messages.SuccessfulMessages;

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
        vm.Orders = await orderService.GetAllOrdersAsync();
        vm.Categories = (await categoryService.GetAllCategoriesAsync()).Select(c => new CategoryViewModel() { Name = c.Name, Id = c.Id.ToString() });
        vm.Users = new List<UserViewModel>();
        vm.DiscountByCategoryViewModel = new DiscountByCategoryViewModel();
        vm.DiscountByCategoryViewModel.Categories = vm.Categories.Select(CategoryViewModel => new CategoryViewModel() { Name = CategoryViewModel.Name, Id = CategoryViewModel.Id });

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
        var categoryExists = await categoryService.CategoryExistsAsync(productvm.CategoryId);
        if (!categoryExists)
        {
            ModelState.AddModelError(string.Empty, CategoryMessages.InvalidCategory);
        }

        if (!ModelState.IsValid)
        {
            ModelState.AddModelError(string.Empty, ModelStateInvalid);
            productvm.Categories = await categoryService.GetAllCategoriesAsync();
            return View(productvm);
        }
        try
        {
            await productService.AddProductAsync(productvm);
            TempData["Message"] = ProductAdded;
            return RedirectToAction(nameof(Index));
        }
        catch (Exception)
        {
            TempData["Message"] = GeneralException;
            productvm.Categories = await categoryService.GetAllCategoriesAsync();
            return View(productvm);
        }

    }
    [HttpPost]
    [ActionName("AddProductCategory")]
    public async Task<IActionResult> AddProductCategoryAsync(CategoryAddViewModel productvm)
    {
        var categories = await categoryService.GetAllCategoriesAsync();
       
        if (categories.Any(c => c.Name == productvm.Name))
        {
            TempData["Message"] = CategoryMessages.CategoryExists;
            return RedirectToAction(nameof(Index));
        }
        try
        {
            TempData["Message"] = CategoryAdded;
            await categoryService.AddCategoryAsync(productvm);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception)
        {
            TempData["Message"] = GeneralException;
            return RedirectToAction(nameof(Index));
        }


    }
    [HttpPost]
    [ActionName("SetDiscount")]
    public async Task<IActionResult> SetDiscountAsync(ProductDiscountViewModel vm)
    {

        if (!ModelState.IsValid)
        {
            TempData["Message"] = InvalidDiscountValue;
        }
        try
        {
            await productService.SetDiscountAsync(vm);
            TempData["Message"]= DiscountSet;
            return RedirectToAction(nameof(Index));
        }
        catch (Exception)
        {
            TempData["Message"] = GeneralException;
            return RedirectToAction(nameof(Index));
        }

    }
    [HttpPost]
    [ActionName("SetDiscountByCategory")]
    public async Task<IActionResult> SetDiscountByCategory(DiscountByCategoryViewModel vm)
    {
        if (!await categoryService.CategoryExistsAsync(vm.CategoryId))
        {
            TempData["Message"] = CategoryMessages.InvalidCategory;
            return RedirectToAction(nameof(Index));
        }
        if (!ModelState.IsValid)
        {
            TempData["Message"] = InvalidDiscountValue;
            return RedirectToAction(nameof(Index));
        }
        try
        {
            await productService.SetDiscountByCategoryAsync(vm.CategoryId, vm.Discount);
            TempData["Message"] = DiscountSetByCategory;
            return RedirectToAction(nameof(Index));
        }
        catch (Exception)
        {
            TempData["Message"] = GeneralException;
            return RedirectToAction(nameof(Index));
        }

    }
    [HttpPost]
    [ActionName("CancelDiscountByCategory")]
    public async Task<IActionResult> CancelDiscountByCategory(string Id)
    {
        var products = await productService.GetProductsByCategoryIdAsync(Id);
        if (!await categoryService.CategoryExistsAsync(Id))
        {
            TempData["Message"] = CategoryMessages.InvalidCategory;
            return RedirectToAction(nameof(Index));
        }
        try
        {
            foreach (var product in products)
            {
                if (product.IsDiscounted)
                {
                    await productService.RemoveDiscountAsync(product.Id.ToString());
                }
            }
            TempData["Message"] = SuccessfulMessages.DiscountsByCategoryCancelled;
            return RedirectToAction(nameof(Index));
        }
        catch (Exception)
        {
            TempData["Message"] = GeneralException;
            return RedirectToAction(nameof(Index));
        }




    }
    [HttpPost]
    [ActionName("RemoveDiscount")]
    public async Task<IActionResult> RemoveDiscount(string Id)
    {
        if (Id == null)
        {
            TempData["Message"] = IdNull;
            return RedirectToAction(nameof(Index));

        }
        var product = await productService.GetProductByIdAsync(Id);
        if (product == null)
        {
            TempData["Message"] = ProductMessages.ProductNotFound;
            return RedirectToAction(nameof(Index));
        }
        if (product.IsDiscounted == false)
        {
            TempData["Message"] = ProductMessages.DiscountCannotBeCancelled;
            return RedirectToAction(nameof(Index));
        }
        try
        {
            await productService.RemoveDiscountAsync(Id);
            TempData["Message"] = DiscountRemoved;
            return RedirectToAction(nameof(Index));
        }
        catch (Exception)
        {
            TempData["Message"] = GeneralException;
            return RedirectToAction(nameof(Index));
        }




    }
    [HttpGet]
    [ActionName("Edit")]
    public async Task<IActionResult> Edit(string Id)
    {
        if (Id == null)
        {
            TempData["Message"] = IdNull;
            return RedirectToAction(nameof(Index));
        }
        ProductEditViewModel item = await productService.GetProductEditByIdAsync(Id.ToString());
        if (item == null)
        {
            TempData["Message"] = ProductMessages.ProductNotFound;
            return RedirectToAction(nameof(Index));
        }
        try
        {
            item.Categories = await categoryService.GetAllCategoriesAsync();

            return View("EditProduct", item);
        }
        catch (Exception)
        {
            TempData["Message"] = GeneralException;
            return RedirectToAction(nameof(Index));
        }
    }
    [HttpPost]
    public async Task<IActionResult> SubmitChanges(ProductEditViewModel vm)
    {
        vm.Categories=await categoryService.GetAllCategoriesAsync();
        var categoryExists = await categoryService.CategoryExistsAsync(vm.CategoryId);
        if (!categoryExists)
        {
            ModelState.AddModelError(string.Empty, CategoryMessages.InvalidCategory);
            vm.Categories = await categoryService.GetAllCategoriesAsync();
            return View(RedirectToAction(nameof(Edit),vm.Id));
        }

        if (!ModelState.IsValid)
        {
            ModelState.AddModelError(string.Empty, ModelStateInvalid);
            vm.Categories = await categoryService.GetAllCategoriesAsync();
            return View(RedirectToAction(nameof(Edit),vm.Id));
        }
        try
        {
            await productService.UpdateProductAsync(vm);
            TempData["Message"] = ProductUpdated;
            return RedirectToAction(nameof(Index));
        }
        catch (Exception)
        {
            TempData["Message"] = GeneralException;
            vm.Categories = await categoryService.GetAllCategoriesAsync();
            return View(RedirectToAction(nameof(Edit)));

        }
    }
    
    [HttpPost]
    [ActionName("DeleteCategory")]
    public async Task<IActionResult> DeleteCategory(string Id)
    {
        if (!await categoryService.CategoryExistsAsync(Id))
        {
            TempData["Message"] = CategoryMessages.InvalidCategory;
            return RedirectToAction(nameof(Index));
        }
        try
        {
            await categoryService.DeleteCategoryAsync(Id);
            TempData["Message"] = CategoryDeleted;
            return RedirectToAction(nameof(Index));
        }
        catch (InvalidOperationException e)
        {
            TempData["Message"] = e.Message;
            return RedirectToAction(nameof(Index));
        }
        catch (Exception)
        {
            TempData["Message"] = GeneralException;
            return RedirectToAction(nameof(Index));
        }

    }
    [HttpPost]
    [ActionName("DeleteProduct")]
    public async Task<IActionResult> DeleteProduct(string Id)
    {
        var product = await productService.GetProductByIdAsync(Id);
        if (product==null)
        {
            TempData["Message"] = ProductMessages.ProductNotFound;
            return RedirectToAction(nameof(Index));
        }
        try
        {
            await productService.DeleteProductAsync(Id);
            TempData["Message"] = ProductDeleted;
            return RedirectToAction(nameof(Index));
        }
        catch (InvalidOperationException e)
        {
            TempData["Message"] = e.Message;
            return RedirectToAction(nameof(Index));
        }
        catch (Exception)
        {
            TempData["Message"] = GeneralException;
            return RedirectToAction(nameof(Index));
        }
    }



}

