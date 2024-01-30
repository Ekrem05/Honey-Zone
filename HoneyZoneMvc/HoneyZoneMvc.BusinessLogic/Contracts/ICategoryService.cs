﻿using HoneyZoneMvc.Infrastructure.Data.Models;

namespace HoneyZoneMvc.Contracts
{
    public interface ICategoryService
    {

         Task<bool> AddCategoryAsync(CategoryDto category);
         Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
         Task<bool> UpdateCategoryAsync(CategoryDto category);
         Task<bool> DeleteCategoryAsync(int Id);
        Task<CategoryDto> GetCategoryByName(string name);

    }
}
