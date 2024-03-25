using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.BusinessLogic.ViewModels.CategoryViewModels;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Infrastructure.Data.Models;
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
        public async Task AddAsync(CategoryAddViewModel category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(CategoryMessages.InvalidNull);
            }
            if (await dbContext.Categories.AnyAsync(c => c.Name == category.Name))
            {
                throw new InvalidOperationException(CategoryMessages.CategoryExists);
            }
            dbContext.Categories.Add(new Category() { Name = category.Name });
            await dbContext.SaveChangesAsync();

        }

        public async Task<bool> ExistsAsync(string Id)
        {
            return await dbContext.Categories.AnyAsync(c => c.Id.ToString() == Id);
        }

        public async Task DeleteAsync(string Id)
        {
            if (Id == null)
            {
                throw new ArgumentNullException(IdNull);
            }
            bool result = await dbContext.Products.AnyAsync(p => p.CategoryId.ToString() == Id);
            if (result)
            {
                throw new InvalidOperationException(CategoryMessages.CategoryCannotBeDeleted);
            }
            var category = await dbContext.Categories.FirstOrDefaultAsync(c => c.Id.ToString() == Id);
            if (category == null)
            {
                throw new ArgumentNullException(CategoryMessages.InvalidNull);
            }
            dbContext.Categories.Remove(category);
            await dbContext.SaveChangesAsync();


        }

        public async Task<IEnumerable<CategoryViewModel>> AllAsync()
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

        public async Task<CategoryViewModel> GetByIdAsync(string id)
        {
            CategoryViewModel dto = new CategoryViewModel();
            var model = await dbContext.Categories.FirstOrDefaultAsync(c => c.Id.ToString() == id);
            dto.Id = model.Id.ToString();
            dto.Name = model.Name;
            return dto;
        }

        public Task UpdateAsync(CategoryAddViewModel category)
        {
            throw new NotImplementedException();
        }
    }
}
