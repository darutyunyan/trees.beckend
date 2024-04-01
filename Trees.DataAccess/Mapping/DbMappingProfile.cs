using AutoMapper;
using Trees.Core.Models;
using Trees.DataAccess.Entities;

namespace Trees.DataAccess.Mapping
{
    public class DbMappingProfile : Profile
    {
        public DbMappingProfile()
        {
            CreateMap<AssemblyMethodEntity, AssemblyMethod>().ReverseMap();
            CreateMap<ImgEntity, Img>().ReverseMap();
            CreateMap<LegEntity, Leg>().ReverseMap();
            CreateMap<LocationEntity, Location>().ReverseMap();
            CreateMap<MaterialEntity, Material>().ReverseMap();
            CreateMap<ReviewEntity, Review>().ReverseMap();
            CreateMap<BrandEntity, Brand>().ReverseMap();

            CreateMap<TreeEntity, Tree>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.IsDisplay, opt => opt.MapFrom(src => src.IsDisplay))

               // .ForMember(dest => dest.Info, opt => opt.MapFrom(src => src.Info.ToArray()))
                .ForMember(dest => dest.InfoXml, opt => opt.MapFrom(src => src.Info))
                .ForMember(dest => dest.Imgs, opt => opt.MapFrom(src => src.Imgs))
                .ForMember(dest => dest.Leg, opt => opt.MapFrom(src => src.Leg))
                .ForMember(dest => dest.AssemblyMethod, opt => opt.MapFrom(src => src.AssemblyMethod))
                .ForMember(dest => dest.Material, opt => opt.MapFrom(src => src.Material))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand));

            CreateMap<Tree, TreeEntity>()
                .ForMember(dest => dest.Info, opt => opt.MapFrom(src => src.InfoXml));
        }
    }
}
