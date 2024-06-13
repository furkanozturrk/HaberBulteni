using Application.Services.AnaSayfaService;
using Application.Services.DetayPublicService;
using Infrastructure.Adapters.AnaSayfaService;
using Infrastructure.Adapters.DetayService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IHomePagePublicService, HomePageServiceAdapter>();
            services.AddScoped<IDetailPublicService, DetailServiceAdapter>();
            return services;
        }
    }
}
