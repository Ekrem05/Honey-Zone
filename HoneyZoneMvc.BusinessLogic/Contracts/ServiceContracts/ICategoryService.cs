using HoneyZoneMvc.Infrastructure.ViewModels.CategoryViewModels;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface ICategoryService
    {

        Task AddCategoryAsync(CategoryAddViewModel category);
        Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync();
        Task UpdateCategoryAsync(CategoryAddViewModel category);
        Task DeleteCategoryAsync(string Id);
        Task<CategoryViewModel> GetCategoryById(string name);
        Task<bool> CategoryExistsAsync(string Id);

    }
}
