using Application.Features.AnaSayfa.Dtos;

namespace Application.Services.DetayService
{
    public interface IDetailService
    {
        Task<NewsDetailDto> GetDetailAsync(string? DetayId);
    }
}
