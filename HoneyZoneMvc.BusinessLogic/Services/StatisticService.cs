using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.BusinessLogic.ViewModels.Statistics;
using HoneyZoneMvc.Data;
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
                var products = await productService.GetByCategoryIdAsync(category.Id);
                Dictionary<string, int> productsSoldInCategory = new Dictionary<string, int>();
                foreach (var product in products)
                {

                    var productsSold = context.OrderProducts.GroupBy(op => op.ProductId)
                        .Select(g => new
                        {
                            ProductId = g.Key,
                            Quantity = g.Sum(x => x.Quantity)
                        }).Where(x => x.ProductId.ToString() == product.Id).FirstOrDefault();

                    if (productsSold != null) 
                    { 
                        productsSoldInCategory.Add(product.Name, productsSold.Quantity); 
                    }

                }
                productsSoldbyCategory.Add(category.Name, productsSoldInCategory.Sum(x => x.Value));
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
