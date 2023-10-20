using AutoMapper;
using Trees.Core.Entities;
using Trees.Infrastructure.Persistance.Models;

namespace Trees.Infrastructure.Persistance.Mapping
{
    public class DbMappingProfile : Profile
    {
        public DbMappingProfile()
        {
            CreateMap<AssemblyMethodModel, AssemblyMethod>().ReverseMap();
            CreateMap<ImgModel, Img>().ReverseMap();
            CreateMap<LegModel, Leg>().ReverseMap();
            CreateMap<LocationModel, Location>().ReverseMap();
            CreateMap<MaterialModel, Material>().ReverseMap();
            CreateMap<ReviewModel, Review>().ReverseMap();
            CreateMap<BrandModel, Brand>().ReverseMap();
            CreateMap<TreeModel, TreeModel>().ReverseMap();
        }
    }
}
