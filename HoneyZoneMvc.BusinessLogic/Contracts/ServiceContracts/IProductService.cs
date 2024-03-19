using HoneyZoneMvc.BusinessLogic.Contracts.SubContracts;
using HoneyZoneMvc.BusinessLogic.Enums;
using HoneyZoneMvc.BusinessLogic.ViewModels.Product;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface IProductService : IAddable<ProductAddViewModel>
        , IUpdateAble<ProductEditViewModel>
        , IDeletable
        , IReadable<ProductAdminViewModel>
    {
        Task<AllProductsQueryModel> AllAsync(string category, string searchTerm, ProductSorting sorting, int currentPage, int productsPerPage);
        Task<IEnumerable<ProductAdminViewModel>> GetByCategoryNameAsync(string category);
        Task<IEnumerable<ProductAdminViewModel>> GetByCategoryIdAsync(string Id);
        Task SetDiscountAsync(ProductDiscountViewModel vm);
        Task RemoveDiscountAsync(string Id);
        Task DecreaseQuantityAsync(string Id);
        Task SetDiscountByCategoryAsync(string Id, double discount);
        Task<IEnumerable<ProductAdminViewModel>> SearchAsync(string searchBy);
        Task<IEnumerable<ProductShopCardViewModel>> GetBestSellersAsync();
        Task IncreaseTotalOrdersAsync(string Id, int quantity);
    }
}
