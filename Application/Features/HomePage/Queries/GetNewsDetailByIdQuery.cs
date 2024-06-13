using Application.Features.AnaSayfa.Dtos;
using Application.Services.DetayService;
using MediatR;

namespace Application.Features.AnaSayfa.Queries
{
    public class GetNewsDetailByIdQuery : IRequest<NewsDetailDto>
    {
        public string? DetailId { get; set; }
        public class GetHaberDetayQueryHandle : IRequestHandler<GetNewsDetailByIdQuery, NewsDetailDto>
        {
            private readonly IDetailService _detailService;
            public GetHaberDetayQueryHandle(IDetailService detailService)
            {
                _detailService = detailService;
            }
            public async Task<NewsDetailDto> Handle(GetNewsDetailByIdQuery request, CancellationToken cancellationToken)
            {
                return await _detailService.GetDetailAsync(request.DetailId);
            }
        }
    }
}
