using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.BusinessLogic.Services;
using HoneyZoneMvc.BusinessLogic.ViewModels.CategoryViewModels;
using Microsoft.AspNetCore.Mvc;
using static HoneyZoneMvc.Common.Messages.ExceptionMessages;
using static HoneyZoneMvc.Common.Messages.SuccessfulMessages;
namespace HoneyZoneMvc.Areas.Admin.Controllers
{
    public class CategoryController : BaseAdminController
    {

        private readonly ICategoryService categoryService;


        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }
        [HttpGet]
        [ActionName("Index")]
        public async Task<IActionResult> Index()
        {
            return View(await categoryService.AllAsync());
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
            catch (InvalidOperationException ex)
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
    }
}
