using Application.Features.AnaSayfa.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.AnaSayfa.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<NewsModel.ItemList, ItemListDto>().ReverseMap();
            CreateMap<NewsModel.Category, CategoryDto>().ReverseMap();
            CreateMap<DetailModel.NewsDetail, NewsDetailDto>().ReverseMap();
            CreateMap<DetailModel.Category, CategoryDetailDto>().ReverseMap();
        }
    }
}
