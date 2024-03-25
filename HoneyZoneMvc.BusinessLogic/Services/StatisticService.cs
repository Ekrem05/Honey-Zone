using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.BusinessLogic.ViewModels.Statistics;
using HoneyZoneMvc.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.BusinessLogic.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IOrderService orderService;
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly ApplicationDbContext context;
        public StatisticService(IOrderService _orderService
            ,IProductService _productService
            ,ICategoryService _categoryService
            ,ApplicationDbContext _context)
        {
            orderService = _orderService;
            productService = _productService;
            categoryService = _categoryService;
            context = _context;
        }

        public async Task<StatisticsViewModel> CategoryStatisticsAsync()
        {
            var categories = await categoryService.AllAsync();
            Dictionary<string, int> productsSoldbyCategory = new Dictionary<string, int>();
            foreach (var category in categories)
            {
                int sumOfUnitsSold = 0;
               
                    int productsSold = await context.OrderProducts
                        .Include(op => op.Product)
                        .Include(op => op.Product.Category)
                        .Where(x => x.Product.Category.Id.ToString() == category.Id)
                        .GroupBy(op => op.ProductId)
                        .Select(result => result.Sum(x => x.Quantity)).FirstOrDefaultAsync();
  
                sumOfUnitsSold += productsSold;
                              
                productsSoldbyCategory.Add(category.Name,sumOfUnitsSold);
            }
            return new StatisticsViewModel
            {
                CategoryStatistic = new CategoryStatisticsViewModel
                {
                    Categories = categories.Select(x => x.Name).ToArray(),
                    ProductsSoldInCategory = productsSoldbyCategory
                }
            };
        }
    }
}
