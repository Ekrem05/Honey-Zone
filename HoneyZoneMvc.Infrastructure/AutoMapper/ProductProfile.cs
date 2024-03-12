using AutoMapper;
using HoneyZoneMvc.Infrastructure.Data.Models;
using HoneyZoneMvc.Infrastructure.ViewModels.ProductViewModels;

namespace HoneyZoneMvc.Infrastructure.AutoMapper
{
    public class ProductProfile:Profile
    {

        public ProductProfile()
        {
            CreateMap<ProductAdminViewModel, ProductShopCardViewModel>()
             .ForMember(dest => dest.IsAvailable, opt => opt.MapFrom(src => src.QuantityInStock > 0));

            CreateMap<Product, ProductAdminViewModel>()
                    .ForMember(m=>m.Images,map=>map.MapFrom(vm=>vm.Images.Select(x=>x.Name)));
        }
    }
}
