using HoneyZoneMvc.Infrastructure.Data.Models;

namespace HoneyZoneMvc.Contracts
{
    public interface ICategoryService
    {

         Task<bool> AddCategoryAsync(CategoryDto product);
         Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
         Task<bool> UpdateCategoryAsync(CategoryDto product);
         Task<bool> DeleteCategoryAsync(int Id);
        Task<CategoryDto> GetCategoryByName(string name);

    }
}
