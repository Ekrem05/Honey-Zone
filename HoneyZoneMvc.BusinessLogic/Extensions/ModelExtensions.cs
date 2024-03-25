using HoneyZoneMvc.BusinessLogic.Contracts.ExtensionContracts;

namespace HoneyZoneMvc.BusinessLogic.Extensions
{
    public static class ModelExtensions
    {
        public static string GetCategoryLabels(this ICategoryStatistic categoryStatistic)
        {
            return string.Join(", ", categoryStatistic.Categories.Select(x => $"'{x}'"));
        }
        public static string GetCategoryData(this ICategoryStatistic categoryStatistic)
        {
            List<string> values = new();

            foreach (var categoryName in categoryStatistic.Categories)
            {
                values.Add(categoryStatistic.ProductsSoldInCategory[categoryName].ToString());
            }
            return string.Join(", ", values);
        }
    }
}
