using Domain.Entities;

namespace Application.Services.DetayPublicService
{
    public interface IDetailPublicService
    {
        Task<DetailModel> DetailAsync();
    }
}
