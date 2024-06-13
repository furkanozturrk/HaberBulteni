using Application.Services.AnaSayfaService;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Infrastructure.Adapters.AnaSayfaService
{
    public class HomePageServiceAdapter : IHomePagePublicService
    {
        private readonly IConfiguration _configuration;

        public HomePageServiceAdapter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<NewsModel> GetNews()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var uri = new Uri(_configuration.GetConnectionString("Home"));
                    var response = await httpClient.GetAsync(uri);

                    response.EnsureSuccessStatusCode();

                    var jsonString = await response.Content.ReadAsStringAsync();
                    var deseriazlizedData = JsonSerializer.Deserialize<NewsModel>(jsonString);

                    // İşlenen verileri geri döndürün
                    return deseriazlizedData;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hata oluştu: {ex.Message}");
                    return new NewsModel();
                }
            }
        }
    }
}
