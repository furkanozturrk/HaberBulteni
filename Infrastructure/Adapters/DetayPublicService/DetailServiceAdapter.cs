using Application.Services.DetayPublicService;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Infrastructure.Adapters.DetayService
{
    public class DetailServiceAdapter : IDetailPublicService
    {
        private readonly IConfiguration _configuration;
        public DetailServiceAdapter(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<DetailModel> DetailAsync()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var uri = new Uri(_configuration.GetConnectionString("Detay"));
                    var response = await httpClient.GetAsync(uri);

                    response.EnsureSuccessStatusCode();

                    var jsonString = await response.Content.ReadAsStringAsync();
                    var deseriazlizedData = JsonSerializer.Deserialize<DetailModel>(jsonString);

                    return deseriazlizedData;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hata oluştu: {ex.Message}");
                    return new DetailModel();
                }
            }
        }
    }
}
