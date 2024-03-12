using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Infrastructure.Data.Models;
using HoneyZoneMvc.Infrastructure.ViewModels.CategoryViewModels;
using Microsoft.EntityFrameworkCore;
using static HoneyZoneMvc.Common.Messages.ExceptionMessages;

namespace HoneyZoneMvc.BusinessLogic.Services
{
    public class CategoryService : ICategoryService
    {
        private ApplicationDbContext dbContext;
        public CategoryService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task AddCategoryAsync(CategoryAddViewModel category)
        {
            if (category == null)
            {
                throw new ArgumentNullException();
            }
            dbContext.Categories.Add(new Category() { Name = category.Name });
           await dbContext.SaveChangesAsync();
            
        }

        public async Task<bool> CategoryExistsAsync(string Id)
        {
            return await dbContext.Categories.AnyAsync(c => c.Id.ToString() == Id);
        }

        public async Task DeleteCategoryAsync(string Id)
        {
            bool result = await dbContext.Products.AnyAsync(p => p.CategoryId.ToString() == Id);
            if (result)
            {
               throw new InvalidOperationException(CategoryMessages.CategoryCannotBeDeleted);
            }
            var category = await dbContext.Categories.FirstOrDefaultAsync(c => c.Id.ToString() == Id);
            dbContext.Categories.Remove(category);
            await dbContext.SaveChangesAsync();
            

        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync()
        {
            var models = await dbContext.Categories.ToListAsync();
            List<CategoryViewModel> categoryDto = new List<CategoryViewModel>();
            foreach (var category in models)
            {
                categoryDto.Add(new CategoryViewModel()
                {
                    Id = category.Id.ToString(),
                    Name = category.Name
                });
            }
            return categoryDto;
        }
        public async Task<CategoryViewModel> GetCategoryById(string id)
        {
            CategoryViewModel dto = new CategoryViewModel();
            var model = await dbContext.Categories.FirstOrDefaultAsync(c => c.Id.ToString() == id);
            dto.Id = model.Id.ToString();
            dto.Name = model.Name;
            return dto;
        }



        public Task UpdateCategoryAsync(CategoryAddViewModel category)
        {
            throw new NotImplementedException();
        }
    }
}
