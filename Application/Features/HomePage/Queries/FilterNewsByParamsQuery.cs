using Application.Features.AnaSayfa.Dtos;
using Application.Services.AnaSayfaService;
using MediatR;

namespace Application.Features.AnaSayfa.Queries
{
    public class FilterNewsByParamsQuery : IRequest<List<ItemListDto>>
    {
        public string? CategoryId { get; set; }
        public string? SearchText { get; set; }
        public class GetAnaSayfaQueryHandler : IRequestHandler<FilterNewsByParamsQuery, List<ItemListDto>>
        {
            private readonly IHomePageService _anaSayfaService;
            public GetAnaSayfaQueryHandler(IHomePageService anaSayfaService)
            {
                _anaSayfaService = anaSayfaService;
            }
            public async Task<List<ItemListDto>> Handle(FilterNewsByParamsQuery request, CancellationToken cancellationToken)
            {
                return await _anaSayfaService.GetNews(request.CategoryId, request.SearchText);
            }
        }
    }
}
