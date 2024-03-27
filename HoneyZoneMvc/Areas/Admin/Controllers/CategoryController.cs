using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.BusinessLogic.ViewModels.CategoryViewModels;
using Microsoft.AspNetCore.Mvc;
using static HoneyZoneMvc.Common.Messages.ExceptionMessages;
using static HoneyZoneMvc.Common.Messages.SuccessfulMessages;
namespace HoneyZoneMvc.Areas.Admin.Controllers
{
    /// <summary>
    /// Controller responsible for handling administrative operations related to categories.
    /// </summary>
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
            try
            {
                return View(await categoryService.AllAsync());
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Home", new { e });
            }
        }

        [HttpPost]
        [ActionName("AddCategory")]
        public async Task<IActionResult> AddCategoryAsync(CategoryAddViewModel productvm)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = CategoryMessages.InvalidCategory;
                return RedirectToAction(nameof(Index));
            }
            try
            {
                await categoryService.AddAsync(productvm);
                TempData["Success"] = CategoryAdded;
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentNullException e)
            {
                TempData["Error"] = e.Message;
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException e)
            {
                TempData["Error"] = e.Message;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Home", new { e });
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
            catch (ArgumentNullException e)
            {
                TempData["Error"] = e.Message;
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException e)
            {
                TempData["Error"] = e.Message;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Home", new { e });
            }

        }
    }
}
