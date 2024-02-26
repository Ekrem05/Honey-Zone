﻿using HoneyZoneMvc.Infrastructure.Data.Models.ViewModels;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface ICategoryService
    {

        Task<bool> AddCategoryAsync(CategoryAddViewModel category);
        Task<IEnumerable<CategoryAddViewModel>> GetAllCategoriesAsync();
        Task<bool> UpdateCategoryAsync(CategoryAddViewModel category);
        Task<bool> DeleteCategoryAsync(int Id);
        Task<CategoryAddViewModel> GetCategoryById(string name);

    }
}
