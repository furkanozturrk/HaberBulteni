using Application.Features.AnaSayfa.Dtos;
using Application.Services.DetayPublicService;
using AutoMapper;

namespace Application.Services.DetayService
{
    public class DetailManager : IDetailService
    {
        private readonly IDetailPublicService _detailPublicService;
        private readonly IMapper _mapper;
        public DetailManager(IDetailPublicService detailPublicService, IMapper mapper)
        {
            _detailPublicService = detailPublicService;
            _mapper = mapper;
        }
        public async Task<NewsDetailDto> GetDetailAsync(string? DetayId)
        {
            var detayData = await _detailPublicService.DetailAsync();
            if (detayData.data.newsDetail.itemId == DetayId)
                return _mapper.Map<NewsDetailDto>(detayData.data.newsDetail);

            return new NewsDetailDto();
        }
    }
}
