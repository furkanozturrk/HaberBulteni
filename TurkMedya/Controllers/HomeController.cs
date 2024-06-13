using Application.Features.AnaSayfa.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TurkMedya.Models;

namespace TurkMedya.Controllers
{
    public class HomeController : Controller
    {
        private IMediator _mediator;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
         
        public async Task<IActionResult> Index(int? pageNum, string? category = "0", string searchText = "")
        {
            var pageSize = 5;
            var pageNumber = pageNum ?? 1;

            var result = await _mediator.Send(new FilterNewsByParamsQuery() { CategoryId = category, SearchText = searchText });

            var pagedNews = result.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            var dashBoard = new HomeViewModel
            {
                News = pagedNews,
                PageNumber = pageNumber,
                TotalPages = (int)Math.Ceiling((double)result.Count / pageSize),
                SelectedValue = category,
                SelectedKey = searchText,
            };

            return View(dashBoard);
        }

        public async Task<JsonResult> Detail(string? detayId)
        {
            var details = new HomeViewModel
            {
                Detay = await _mediator.Send(new GetNewsDetailByIdQuery() { DetailId = detayId }),
            };

            return Json(details.Detay);
        }


    }
}
