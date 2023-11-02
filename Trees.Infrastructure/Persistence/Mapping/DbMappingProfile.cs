using AutoMapper;
using Trees.Core.Models;
using Trees.Infrastructure.Persistence.Entities;

namespace Trees.Infrastructure.Persistence.Mapping
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
            CreateMap<TreeEntity, TreeEntity>().ReverseMap();
        }
    }
}
