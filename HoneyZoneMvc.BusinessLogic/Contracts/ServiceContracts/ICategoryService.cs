using HoneyZoneMvc.Infrastructure.ViewModels.CategoryViewModels;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface ICategoryService
    {

        Task<bool> AddCategoryAsync(CategoryAddViewModel category);
        Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync();
        Task<bool> UpdateCategoryAsync(CategoryAddViewModel category);
        Task<bool> DeleteCategoryAsync(string Id);
        Task<CategoryViewModel> GetCategoryById(string name);

    }
}
