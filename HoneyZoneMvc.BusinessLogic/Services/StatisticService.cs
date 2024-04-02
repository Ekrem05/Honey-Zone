using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.BusinessLogic.ViewModels.Statistics;
using HoneyZoneMvc.Data;
using Microsoft.EntityFrameworkCore;

namespace HoneyZoneMvc.BusinessLogic.Services
{
    public class StatisticService : IStatisticService
    {

        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly ApplicationDbContext context;
        public StatisticService(IProductService _productService
            , ICategoryService _categoryService
            , ApplicationDbContext _context)
        {
            productService = _productService;
            categoryService = _categoryService;
            context = _context;
        }

        /// <summary>
        /// This method returns how many products are sold by category
        /// </summary>
        /// <returns></returns>
        public async Task<CategoryStatisticsViewModel> CategoryStatisticsAsync()
        {
            var categories = await categoryService.AllAsync();
            Dictionary<string, int> productsSoldbyCategory = new Dictionary<string, int>();
            foreach (var category in categories)
            {
                var productsSold = await context.OrderProducts
                    .Include(op => op.Product)
                    .Include(op => op.Product.Category)
                    .Where(x => x.Product.Category.Id.ToString() == category.Id).ToListAsync();

                int quantityOfProductsSoldInCategory = productsSold.Sum(p => p.Quantity);

                productsSoldbyCategory.Add(category.Name, quantityOfProductsSoldInCategory);
            }
            return new CategoryStatisticsViewModel
            {
                Categories = categories.Select(x => x.Name).ToArray(),
                ProductsSoldInCategory = productsSoldbyCategory
            };

        }

        /// <summary>
        /// This method returns how units are in stock for each product
        /// </summary>
        /// <returns></returns>
        public async Task<StockStatisticsViewModel> StockStatisticsAsync()
        {
            var products = await productService.AllAsync();
            Dictionary<string, int> kvp = new Dictionary<string, int>();
            foreach (var item in products)
            {
                kvp[item.Name] = item.QuantityInStock;
            }
            return new StockStatisticsViewModel
            {
                ProductsInStockPair = kvp
            };
        }

    }
}
