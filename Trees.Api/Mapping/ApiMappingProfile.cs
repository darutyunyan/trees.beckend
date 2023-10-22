using AutoMapper;
using Trees.Api.Models.Dto.Brand;
using Trees.Core.Entities;

namespace Trees.Api.Mapping
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<BrandDto, Brand>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Brand, BrandResultDto>();
        }
    }
}
