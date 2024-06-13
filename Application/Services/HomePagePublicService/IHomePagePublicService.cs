using Domain.Entities;

namespace Application.Services.AnaSayfaService
{
    public interface IHomePagePublicService
    {
        Task<NewsModel> GetNews();
    }
}
