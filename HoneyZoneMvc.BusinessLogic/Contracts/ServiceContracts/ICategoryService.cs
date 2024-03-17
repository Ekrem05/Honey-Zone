using HoneyZoneMvc.BusinessLogic.Contracts.SubContracts;
using HoneyZoneMvc.BusinessLogic.ViewModels.CategoryViewModels;

namespace HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts
{
    public interface ICategoryService:IAddable<CategoryAddViewModel>
        ,IUpdateAble<CategoryAddViewModel>
        ,IDeletable
        ,IReadable<CategoryViewModel>
    {
        Task<bool> ExistsAsync(string Id);
    }
}
