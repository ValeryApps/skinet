using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
   public class AutoMapperProfiles : Profile
   {
      public AutoMapperProfiles()
      {
         CreateMap<Product, ProductToReturnDto>()
         .ForMember(d => d.ProductBrand, o => o.MapFrom(
               src => src.ProductBrand.Name
           ))
         .ForMember(t => t.ProductType, o => o.MapFrom(
               src => src.ProductType.Name
           ))
           .ForMember(dest => dest.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
      }
   }
}