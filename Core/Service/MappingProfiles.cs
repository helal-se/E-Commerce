using AutoMapper;
using Domain.Entities;
using Shared.Dtos;

namespace Service
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.TypeName, option => option.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.BrandName, option => option.MapFrom(s => s.ProductBrand.Name));

            CreateMap<ProductType, ProductTypesDto>();

            CreateMap<ProductBrand, ProductBrandsDto>();
        }
    }
}
