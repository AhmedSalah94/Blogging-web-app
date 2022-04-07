using AutoMapper;
using BloogingWebSite.Dtos;
using BloogingWebSite.Models;

namespace BloogingWebSite.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Blog, BlogDto>().ReverseMap();
            CreateMap<Blog, UpdateBlogDto>().ReverseMap();
            CreateMap<Blog, AddBlogDto>().ReverseMap();
        }
    }
}