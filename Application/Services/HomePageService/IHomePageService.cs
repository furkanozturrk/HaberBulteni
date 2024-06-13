using Application.Features.AnaSayfa.Dtos;

namespace Application.Services.AnaSayfaService
{
    public interface IHomePageService
    {
        Task<List<ItemListDto>> GetNews(string? categoryId, string? searchText);
    }
}
