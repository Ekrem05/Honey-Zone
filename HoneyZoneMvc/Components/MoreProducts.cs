using AutoMapper;
using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.BusinessLogic.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;

namespace HoneyZoneMvc.Components
{
    public class MoreProducts:ViewComponent
    {
        private IProductService productService;
        private IMapper mapper;
        public MoreProducts(IProductService _productService, IMapper _mapper)
        {
            productService= _productService;
            mapper= _mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await productService.AllAsync();
            var result= mapper.Map<List<ProductShopCardViewModel>>(products);
            return View(result);
        }
    }
}
