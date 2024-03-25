using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.BusinessLogic.ViewModels.Statistics;
using HoneyZoneMvc.Data;
using Microsoft.EntityFrameworkCore;

namespace HoneyZoneMvc.BusinessLogic.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IOrderService orderService;
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly ApplicationDbContext context;
        public StatisticService(IOrderService _orderService
            , IProductService _productService
            , ICategoryService _categoryService
            , ApplicationDbContext _context)
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
                var productsSold = await context.OrderProducts
                    .Include(op => op.Product)
                    .Include(op => op.Product.Category)
                    .Where(x => x.Product.Category.Id.ToString() == category.Id).ToListAsync();

                    int quantityOfProductsSoldInCategory=productsSold.Sum(p=>p.Quantity);

                productsSoldbyCategory.Add(category.Name, quantityOfProductsSoldInCategory);
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
