using AutoMapper;
using HoneyZoneMvc.Infrastructure.Data.Models;
using HoneyZoneMvc.BusinessLogic.ViewModels.ProductViewModels;

namespace HoneyZoneMvc.BusinessLogic.AutoMapper
{
    public class ProductProfile:Profile
    {

        public ProductProfile()
        {
            CreateMap<ProductAdminViewModel, ProductShopCardViewModel>()
             .ForMember(dest => dest.IsAvailable, opt => opt.MapFrom(src => src.QuantityInStock > 0))
             .ReverseMap(); 

            CreateMap<ProductAdminViewModel, ProductEditViewModel>()
                .ForMember(m => m.Categories, map => map.Ignore());


            CreateMap<ProductAddViewModel, Product>()
                    .ForMember(m => m.Images, map => map.Ignore())
                    .ForMember(m => m.MainImageUrl, map => map.Ignore())
                    .ForMember(m => m.CategoryId, map => map.MapFrom(vm => Guid.Parse(vm.CategoryId)));

            CreateMap<Product, ProductAdminViewModel>()
                   .ForMember(vm => vm.Id, map => map.MapFrom(m => m.Id.ToString()))
                   .ForMember(vm => vm.MainImageName, map => map.MapFrom(m => m.MainImageUrl))
                   .ForMember(vm => vm.CategoryId, map =>map.MapFrom(m=>m.Category.Name))
                   .ForMember(vm => vm.Images, map => map.MapFrom(m => m.Images.Select(i => i.Name).ToArray()));

            CreateMap<ProductAdminViewModel, ProductShopDetailsViewModel>()
               .ForMember(m => m.ImagesNames,map=>map.MapFrom(m => m.Images.ToList()));

        }
    }
}
