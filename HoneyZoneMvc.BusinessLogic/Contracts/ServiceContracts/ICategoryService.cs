using HoneyZoneMvc.BusinessLogic.ViewModels.CategoryViewModels;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface ICategoryService
    {

        Task AddAsync(CategoryAddViewModel category);
        Task<IEnumerable<CategoryViewModel>> AllAsync();
        Task UpdateAsync(CategoryAddViewModel category);
        Task DeleteAsync(string Id);
        Task<CategoryViewModel> GetById(string name);
        Task<bool> ExistsAsync(string Id);

    }
}
