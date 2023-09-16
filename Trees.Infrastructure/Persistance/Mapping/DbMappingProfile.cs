using AutoMapper;
using Trees.Core.Entities;
using Trees.Infrastructure.Persistance.Models;

namespace Trees.Infrastructure.Persistance.Mapping
{
    public class DbMappingProfile : Profile
    {
        public DbMappingProfile()
        {
            CreateMap<AssemblyMethodModel, AssemblyMethod>();
            CreateMap<ImgModel, Img>();
            CreateMap<LegModel, Leg>();
            CreateMap<LocationModel, Location>();
            CreateMap<MaterialModel, Material>();
            CreateMap<ReviewModel, Review>();
            CreateMap<BrandModel, Brand>();
            CreateMap<TreeModel, TreeModel>();
        }
    }
}
