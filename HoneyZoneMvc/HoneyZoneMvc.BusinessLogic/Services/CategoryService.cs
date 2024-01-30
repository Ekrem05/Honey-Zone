using HoneyZoneMvc.Contracts;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Infrastructure.Data.Models;
using HoneyZoneMvc.Infrastructure.Data.Models.Entities;
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
        public async Task<bool> AddCategoryAsync(CategoryDto category)
        {
            if (category == null)
            {
                throw new ArgumentNullException();
            }
            dbContext.Categories.Add(new Category() { Name = category.Name});
            if (await dbContext.SaveChangesAsync()>0)
            {
                return true;
            }
            return false;
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

        public Task<bool> UpdateCategoryAsync(CategoryDto category)
        {
            throw new NotImplementedException();
        }
    }
}
