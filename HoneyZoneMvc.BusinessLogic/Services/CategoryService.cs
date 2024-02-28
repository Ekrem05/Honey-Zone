﻿using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Infrastructure.Data.Models.Entities;
using HoneyZoneMvc.Infrastructure.ViewModels.CategoryViewModels;
using Microsoft.EntityFrameworkCore;

namespace HoneyZoneMvc.BusinessLogic.Services
{
    public class CategoryService : ICategoryService
    {
        private ApplicationDbContext dbContext;
        public CategoryService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task<bool> AddCategoryAsync(CategoryAddViewModel category)
        {
            if (category == null)
            {
                throw new ArgumentNullException();
            }
            dbContext.Categories.Add(new Category() { Name = category.Name });
            if (await dbContext.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteCategoryAsync(string Id)
        {
           bool result= await dbContext.Products.AnyAsync(p => p.CategoryId.ToString() == Id);
            if (result)
            {
                return false;
            }
            var category = await dbContext.Categories.FirstOrDefaultAsync(c => c.Id.ToString() == Id);
            dbContext.Categories.Remove(category);
            if (await dbContext.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
           
        }

        public async Task<IEnumerable<CategoryAddViewModel>> GetAllCategoriesAsync()
        {
            var models = await dbContext.Categories.ToListAsync();
            List<CategoryAddViewModel> categoryDto = new List<CategoryAddViewModel>();
            foreach (var category in models)
            {
                categoryDto.Add(new CategoryAddViewModel()
                {
                    Id = category.Id,
                    Name = category.Name
                });
            }
            return categoryDto;
        }
        public async Task<CategoryAddViewModel> GetCategoryById(string id)
        {
            CategoryAddViewModel dto = new CategoryAddViewModel();
            var model = await dbContext.Categories.FirstOrDefaultAsync(c => c.Id.ToString() == id);
            dto.Id = model.Id;
            dto.Name = model.Name;
            return dto;
        }


        public Task<bool> UpdateCategoryAsync(CategoryAddViewModel category)
        {
            throw new NotImplementedException();
        }
    }
}
