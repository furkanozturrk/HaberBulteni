using Application.Features.AnaSayfa.Dtos;

namespace TurkMedya.Models
{
    public class HomeViewModel
    {
        public List<ItemListDto> News { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public string SelectedValue { get; set; }
        public string SelectedKey { get; set; }
        public NewsDetailDto Detay { get; set; }
    }
}
