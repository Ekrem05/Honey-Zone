using AutoMapper;
using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.BusinessLogic.Services;
using HoneyZoneMvc.Common.Messages;
using HoneyZoneMvc.Infrastructure.Data.Models;
using HoneyZoneMvc.BusinessLogic.ViewModels;
using HoneyZoneMvc.BusinessLogic.ViewModels.CategoryViewModels;
using HoneyZoneMvc.BusinessLogic.ViewModels.Delivery;
using HoneyZoneMvc.BusinessLogic.ViewModels.OrderViewModels;
using HoneyZoneMvc.BusinessLogic.ViewModels.ProductViewModels;
using HoneyZoneMvc.BusinessLogic.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static HoneyZoneMvc.Common.Messages.ExceptionMessages;
using static HoneyZoneMvc.Common.Messages.SuccessfulMessages;

[Authorize]
public class AdminController : Controller
{
    private readonly IProductService productService;
    private readonly ICategoryService categoryService;
    private readonly IOrderService orderService;
    private readonly IDeliveryService deliveryService;
    private readonly ICartProductService cartProductService;
    private IMapper mapper;
    //private readonly IUserService userService;
    public AdminController(IProductService _productService,
        ICategoryService _categoryService,
        IOrderService _orderService,
        IMapper _mapper,
        IDeliveryService _deliveryService,
        ICartProductService _cartProductService
        /*, IUserService _userService*/)
    {
        productService = _productService;
        categoryService = _categoryService;
        orderService = _orderService;
        deliveryService = _deliveryService;
        cartProductService = _cartProductService;
        mapper = _mapper;
        //userService = _userService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        AdminViewModel vm = new AdminViewModel();
        vm.Products = await productService.AllAsync();
        vm.Orders = await orderService.GetAllOrdersAsync();
        vm.Categories = (await categoryService.AllAsync()).Select(c => new CategoryViewModel() { Name = c.Name, Id = c.Id.ToString() });
        vm.Users = new List<UserViewModel>();
        vm.DiscountByCategoryViewModel = new DiscountByCategoryViewModel();
        vm.DiscountByCategoryViewModel.Categories = vm.Categories.Select(CategoryViewModel => new CategoryViewModel() { Name = CategoryViewModel.Name, Id = CategoryViewModel.Id });

        //vm.Users= (await userService.GetAllUsersAsync()); 
        //ADD DOWNLOADING FUNCTIONALLITY DOWNLOAD Business stats profit etc.
        return View(vm);
    }

    [HttpGet]
    [ActionName("Products")]
    public async Task<IActionResult> Products([FromQuery] AllProductsQueryModel queryModel)
    {

        AllProductsQueryModel vm
            = await productService.AllAsync(queryModel.Category, 
            queryModel.SearchTerm, 
            queryModel.SortBy,
            queryModel.CurrentPage,
            queryModel.ProductsPerPage);
        
        queryModel.TotalProductsCount = vm.TotalProductsCount;
        queryModel.Categories = vm.Categories;
        queryModel.Products = vm.Products;

        return View(queryModel);
    }
    [HttpGet]
    [ActionName("AddProduct")]
    public async Task<IActionResult> AddProductAsync()
    {
        try
        {
            ProductAddViewModel productAddViewModel = new ProductAddViewModel();
            productAddViewModel.Categories = await categoryService.AllAsync();
            return View(productAddViewModel);
        }
        catch (Exception)
        {

            TempData["Error"] = GeneralException;
            return RedirectToAction(nameof(Index));
        }     
       
    }
    [HttpPost]
    [ActionName("AddProduct")]
    public async Task<IActionResult> AddProductAsync(ProductAddViewModel productvm)
    {
        var categoryExists = await categoryService.ExistsAsync(productvm.CategoryId);
        if (!categoryExists)
        {
            ModelState.AddModelError(string.Empty, CategoryMessages.InvalidCategory);
        }

        if (!ModelState.IsValid)
        {
            ModelState.AddModelError(string.Empty, ModelStateInvalid);
            productvm.Categories = await categoryService.AllAsync();
            return View(productvm);
        }
        try
        {
            await productService.AddAsync(productvm);
            TempData["Success"] = ProductAdded;
            return RedirectToAction(nameof(Products));
        }
        catch (Exception)
        {
            TempData["Error"] = GeneralException;
            productvm.Categories = await categoryService.AllAsync();
            return View(productvm);
        }

    }
    [HttpPost]
    [ActionName("AddProductCategory")]
    public async Task<IActionResult> AddProductCategoryAsync(CategoryAddViewModel productvm)
    {
        var categories = await categoryService.AllAsync();
       
        if (categories.Any(c => c.Name == productvm.Name))
        {
            TempData["Error"] = CategoryMessages.CategoryExists;
            return RedirectToAction(nameof(Index));
        }
        try
        {
            TempData["Success"] = CategoryAdded;
            await categoryService.AddAsync(productvm);
            return RedirectToAction(nameof(Index));
        }
        catch(InvalidOperationException ex)
        {
            TempData["Error"] = ex.Message;
            return RedirectToAction(nameof(Index));
        }
        catch (Exception)
        {
            TempData["Error"] = GeneralException;
            return RedirectToAction(nameof(Index));
        }


    }
    [HttpPost]
    [ActionName("SetDiscount")]
    public async Task<IActionResult> SetDiscountAsync(ProductDiscountViewModel vm)
    {

        if (!ModelState.IsValid)
        {
            TempData["Error"] = InvalidDiscountValue;
            return RedirectToAction(nameof(Index));

        }
        try
        {
            await productService.SetDiscountAsync(vm);
            TempData["Success"]= DiscountSet;
            return RedirectToAction(nameof(Index));
        }
        catch (Exception)
        {
            TempData["Error"] = GeneralException;
            return RedirectToAction(nameof(Index));
        }

    }
    [HttpPost]
    [ActionName("SetDiscountByCategory")]
    public async Task<IActionResult> SetDiscountByCategory(DiscountByCategoryViewModel vm)
    {
        if (!await categoryService.ExistsAsync(vm.CategoryId))
        {
            TempData["Error"] = CategoryMessages.InvalidCategory;
            return RedirectToAction(nameof(Index));
        }
        if (!ModelState.IsValid)
        {
            TempData["Error"] = InvalidDiscountValue;
            return RedirectToAction(nameof(Index));
        }
        try
        {
            await productService.SetDiscountByCategoryAsync(vm.CategoryId, vm.Discount);
            TempData["Success"] = DiscountSetByCategory;
            return RedirectToAction(nameof(Index));
        }
        catch (Exception)
        {
            TempData["Error"] = GeneralException;
            return RedirectToAction(nameof(Index));
        }

    }
    [HttpPost]
    [ActionName("CancelDiscountByCategory")]
    public async Task<IActionResult> CancelDiscountByCategory(string Id)
    {
        var products = await productService.GetByCategoryIdAsync(Id);
        if (!await categoryService.ExistsAsync(Id))
        {
            TempData["Error"] = CategoryMessages.InvalidCategory;
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
            TempData["Success"] = DiscountsByCategoryCancelled;
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
            TempData["Error"] = IdNull;
            return RedirectToAction(nameof(Index));

        }
        var product = await productService.GetByIdAsync(Id);
        if (product == null)
        {
            TempData["Error"] = ProductMessages.ProductNotFound;
            return RedirectToAction(nameof(Index));
        }
        if (product.IsDiscounted == false)
        {
            TempData["Error"] = ProductMessages.DiscountCannotBeCancelled;
            return RedirectToAction(nameof(Index));
        }
        try
        {
            await productService.RemoveDiscountAsync(Id);
            TempData["Success"] = DiscountRemoved;
            return RedirectToAction(nameof(Index));
        }
        catch (Exception)
        {
            TempData["Error"] = GeneralException;
            return RedirectToAction(nameof(Index));
        }




    }
    [HttpGet]
    [ActionName("Edit")]
    public async Task<IActionResult> Edit(string Id)
    {
        if (Id == null)
        {
            TempData["Error"] = IdNull;
            return RedirectToAction(nameof(Index));
        }
        var item = await productService.GetByIdAsync(Id.ToString());
        ProductEditViewModel vm=mapper.Map<ProductEditViewModel>(item);
        if (vm == null)
        {
            TempData["Error"] = ProductMessages.ProductNotFound;
            return RedirectToAction(nameof(Index));
        }
        try
        {
            vm.Categories = await categoryService.AllAsync();
            
            return View("EditProduct", vm);
        }
        catch (Exception)
        {
            TempData["Error"] = GeneralException;
            return RedirectToAction(nameof(Index));
        }
    }
    [HttpPost]
    public async Task<IActionResult> SubmitChanges(ProductEditViewModel vm)
    {
        vm.Categories=await categoryService.AllAsync();
        var categoryExists = await categoryService.ExistsAsync(vm.CategoryId);
        if (!categoryExists)
        {
            ModelState.AddModelError(string.Empty, CategoryMessages.InvalidCategory);
            vm.Categories = await categoryService.AllAsync();
            return RedirectToAction(nameof(Edit),vm.Id);
        }

        if (!ModelState.IsValid)
        {
            ModelState.AddModelError(string.Empty, ModelStateInvalid);
            TempData["Error"] = ModelStateInvalid;
            vm.Categories = await categoryService.AllAsync();
            return RedirectToAction(nameof(Edit),new {Id =vm.Id});
        }
        try
        {
            await productService.UpdateAsync(vm);
            TempData["Success"] = ProductUpdated;
            return RedirectToAction(nameof(Index));
        }
        catch (Exception)
        {
            TempData["Error"] = GeneralException;
            vm.Categories = await categoryService.AllAsync();
            return RedirectToAction(nameof(Edit));

        }
    }
    
    [HttpGet]
    [ActionName("OrderInformation")]
    public async Task<IActionResult> OrderInformation(string Id)
    {
        if (Id==null)
        {
            TempData["Message"] = IdNull;
            return RedirectToAction(nameof(Index));
        }
        try
        {
            var orderInfo = await orderService.GetOrderDetailsAsync(Id);
            return View(orderInfo);
        }
        catch (Exception)
        {
            TempData["Error"] = OrderMessages.OrderNotFound;
            return RedirectToAction(nameof(Index));
        }
    }

   
    [HttpGet]
    [ActionName("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus(string Id)
    {
        try
        {
            var order = await orderService.GetOrderByIdAsync(Id);
            return View(order);
        }
        catch (Exception)
        {
            TempData["Error"] = GeneralException;
            return RedirectToAction("Error", "Home", new { statusCode = 404 });
        }
    }
    [HttpPost]
    [ActionName("ChangeStatus")]
    public async Task<IActionResult> ChangeStatus(ChangeOrderStatusViewModel vm)
    {
        try
        {
            await orderService.ChangeStatusAsync(vm);
            TempData["Success"] = OrderStatusChanged;
            return RedirectToAction(nameof(Index));
        }
        catch (Exception e)
        {
            TempData["Error"] = e.Message;
            return RedirectToAction(nameof(Index));
        }

    }

    [HttpPost]
    [ActionName("DeleteOrder")]
    public async Task<IActionResult> DeleteOrder(string Id)
    {
        if(Id==null)
        {
            TempData["Error"] = IdNull;
            return RedirectToAction(nameof(Index));
        }
        try
        {      
            await orderService.DeleteOrderAsync(Id);
            TempData["Success"] = OrderDeleted;
            return RedirectToAction(nameof(Index));
        }
        catch (Exception e)
        {

            TempData["Error"] = e.Message;
            return RedirectToAction(nameof(Index));
        }
       
    }

    [HttpPost]
    [ActionName("DeleteCategory")]
    public async Task<IActionResult> DeleteCategory(string Id)
    {
        if (!await categoryService.ExistsAsync(Id))
        {
            TempData["Error"] = CategoryMessages.InvalidCategory;
            return RedirectToAction(nameof(Index));
        }
        try
        {
            await categoryService.DeleteAsync(Id);
            TempData["Success"] = CategoryDeleted;
            return RedirectToAction(nameof(Index));
        }
        catch (InvalidOperationException e)
        {
            TempData["Error"] = e.Message;
            return RedirectToAction(nameof(Index));
        }
        catch (Exception)
        {
            TempData["Error"] = GeneralException;
            return RedirectToAction(nameof(Index));
        }

    }
    [HttpPost]
    [ActionName("DeleteProduct")]
    public async Task<IActionResult> DeleteProduct(string Id)
    {
        var product = await productService.GetByIdAsync(Id);
        if (product==null)
        {
            TempData["Error"] = ProductMessages.ProductNotFound;
            return RedirectToAction(nameof(Index));
        }
        try
        {
            await productService.DeleteAsync(Id);
            TempData["Success"] = ProductDeleted;
            return RedirectToAction(nameof(Index));
        }
        catch (InvalidOperationException e)
        {
            TempData["Error"] = e.Message;
            return RedirectToAction(nameof(Index));
        }
        catch (Exception)
        {
            TempData["Error"] = GeneralException;
            return RedirectToAction(nameof(Index));
        }
    }

    private Guid GetUserId()
    {
        return Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
    }
}

