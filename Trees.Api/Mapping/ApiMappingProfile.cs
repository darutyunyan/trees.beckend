using AutoMapper;
using Trees.Api.Models.Dto.AssemblyMethod;
using Trees.Api.Models.Dto.Brand;
using Trees.Api.Models.Dto.Img;
using Trees.Api.Models.Dto.Leg;
using Trees.Api.Models.Dto.Location;
using Trees.Api.Models.Dto.Log;
using Trees.Api.Models.Dto.Material;
using Trees.Api.Models.Dto.Review;
using Trees.Api.Models.Dto.Tree;
using Trees.Core.Models;

namespace Trees.Api.Mapping
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<AssemblyMethodDto, AssemblyMethod>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<AssemblyMethod, AssemblyMethodResultDto>();

            CreateMap<BrandDto, Brand>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Brand, BrandResultDto>();

            CreateMap<LegDto, Leg>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Leg, LegResultDto>();

            CreateMap<MaterialDto, Material>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Material, MaterialResultDto>();

            CreateMap<ReviewDto, Review>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateTime.Parse(src.Date)))
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment));

            CreateMap<Review, ReviewResultDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment));

            CreateMap<LocationDto, Location>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Lat, opt => opt.MapFrom(src => src.Lat))
                .ForMember(dest => dest.Lng, opt => opt.MapFrom(src => src.Lng));

            CreateMap<Location, LocationResultDto>();

            CreateMap<Img, ImgResultDto>();

            CreateMap<ImgDto, Img>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Log, LogResultDto>();

            CreateMap<TreeDto, Tree>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Info, opt => opt.MapFrom(src => src.Info))
                .ForMember(dest => dest.IsDisplay, opt => opt.MapFrom(src => src.IsDisplay))
                .ForMember(dest => dest.ImgId, opt => opt.MapFrom(src => Guid.Parse(src.ImgId)))
                .ForMember(dest => dest.LegId, opt => opt.MapFrom(src =>
                    src.LegId != null ? Guid.Parse(src.LegId) : (Guid?)null))
                .ForMember(dest => dest.AssemblyMethodId, opt => opt.MapFrom(src =>
                    src.AssemblyMethodId != null ? Guid.Parse(src.AssemblyMethodId) : (Guid?)null))
                .ForMember(dest => dest.MaterialId, opt => opt.MapFrom(src =>
                    src.MaterialId != null ? Guid.Parse(src.MaterialId) : (Guid?)null))
                .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src =>
                    src.BrandId != null ? Guid.Parse(src.BrandId) : (Guid?)null));
        }
    }
}
