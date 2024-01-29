using HoneyZoneMvc.Contracts;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.BusinessLogic.Services
{
    public class CategoryService : ICategoryService
    {
        private ApplicationDbContext dbContext;
        public CategoryService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public Task<bool> AddCategoryAsync(CategoryDto product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCategoryAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var models = await dbContext.Categories.ToListAsync();
            List<CategoryDto> categoryDto = new List<CategoryDto>();
            foreach (var category in models)
            {
                categoryDto.Add(new CategoryDto()
                {
                    Id = category.Id,
                   Name= category.Name
                });
            }
            return categoryDto;
        }

        public async Task<CategoryDto> GetCategoryByName(string name)
        {
            CategoryDto dto=new CategoryDto();
            var model= await dbContext.Categories.FirstOrDefaultAsync(c => c.Name == name);
            dto.Id= model.Id;
            dto.Name= model.Name;
            return dto;
        }

        public Task<bool> UpdateCategoryAsync(CategoryDto product)
        {
            throw new NotImplementedException();
        }
    }
}
