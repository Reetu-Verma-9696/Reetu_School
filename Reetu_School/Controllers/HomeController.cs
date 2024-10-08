using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reetu_School.Models;
using System.Diagnostics;

namespace Reetu_School.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        private IHttpContextAccessor _httpContextAccessor;
        public HomeController(IMediator mediator, IHttpContextAccessor httpContextAccessor)

        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult UploadingData()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadingData([FromBody] UploadingData obj)
        {
            var data = await _mediator.Send(obj);
            return Ok(data);  
        }
        [HttpGet]
        public async Task<IActionResult>GetUploadingData(int Id)
        {
            var data = await _mediator.Send(new GetUploadingData { Id = Id});
            return Ok(data);
        }
    }
}