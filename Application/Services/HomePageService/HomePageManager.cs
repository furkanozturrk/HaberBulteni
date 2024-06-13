using Application.Features.AnaSayfa.Dtos;
using AutoMapper;

namespace Application.Services.AnaSayfaService
{
    public class HomePageManager : IHomePageService
    {
        private readonly IHomePagePublicService _homePagePublicService;
        private readonly IMapper _mapper;
        public HomePageManager(IHomePagePublicService homePagePublicService, IMapper mapper)
        {
            _homePagePublicService = homePagePublicService;
            _mapper = mapper;
        }
        public async Task<List<ItemListDto>> GetNews(string? categoryId, string? searchText)
        {
            List<ItemListDto> haberModels = new List<ItemListDto>();
            var anaSayfaData = await _homePagePublicService.GetNews();

            foreach (var item in anaSayfaData.data)
            {
                foreach (var data in item.itemList)
                {
                    haberModels.Add(_mapper.Map<ItemListDto>(data));
                }
            }
            if (string.IsNullOrEmpty(searchText))
            {
                if (categoryId == "0")
                    return haberModels.ToList();

                return haberModels.Where(x => x.category.categoryId == categoryId).ToList();
            }
            else
            {
                if (categoryId == "0")
                    return haberModels.Where(x => x.title.ToLower().Contains(searchText.ToLower())).ToList();

                return haberModels.Where(x => x.category.categoryId == categoryId && x.title.ToLower().Contains(searchText.ToLower())).ToList();
            }
        }
    }
}
