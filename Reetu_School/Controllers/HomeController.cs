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
        public IActionResult Dashboard()
        {
            return View();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUploadingData([FromBody] DeleteUploadingData req)
        {
            var data = await _mediator.Send(req);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> SendEnquiry([FromBody] SendEnquiry obj)
        {
            var data = await _mediator.Send(obj);
            return Ok(data);
        }
        public IActionResult MasterUserRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> InsertUserRole([FromBody] InsertUserRole obj)
        {
            var data = await _mediator.Send(obj);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetUserRoleDetails(int Id)
        {
            var data = await _mediator.Send(new GetUserRoleDetails { Id = Id });
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUserRole([FromBody] DeleteUserRole obj)
        {
            var data = await _mediator.Send(obj);
            return Ok(data);
        }
        public IActionResult Country()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> InsertCountry([FromBody] InsertCountry obj)
        {
            var data = await _mediator.Send(obj);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetCountry(int Id)
        {
            var data = await _mediator.Send(new GetCountry { Id = Id });
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> BindCountry()
        {
            var data = await _mediator.Send(new BindCountry {});
            return Ok(data);
        }
        public IActionResult City()
        {
            return View();
        }
        public IActionResult State()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> InsertState([FromBody] InsertState req)
        {
            var data = await _mediator.Send(req);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetState(int Id)
        {
            var data = await _mediator.Send(new GetState { Id = Id });
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> InsertCity([FromBody] InsertCity req)
        {
            var data = await _mediator.Send(req);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetCity(int Id)
        {
            var data = await _mediator.Send(new GetCity { Id = Id });
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteState([FromBody] DeleteState obj)
        {
            var data = await _mediator.Send(obj);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCity([FromBody] DeleteCity obj)
        {
            var data = await _mediator.Send(obj);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> BindState(int CountryId)
        {
            var data = await _mediator.Send(new BindState {CountryId = CountryId });
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> BindCity(int StateId)
        {
            var data = await _mediator.Send(new BindCity {StateId = StateId });
            return Ok(data);
        }
        public IActionResult MasterAndroidService()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddServices([FromBody] AddServices AddServices)
        {
            var data = await _mediator.Send(AddServices);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> GetServiceDetails(GetServiceDetails obj)
        {
            var data = await _mediator.Send(obj);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteService([FromBody] DeleteService obj)
        {
            var data = await _mediator.Send(obj);
            return Ok(data);
        }
        public IActionResult AssignService()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BindCompany(int Id)
        {
            var data = await _mediator.Send(new BindCompany { Id = Id });
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> AssignService(AssignService obj)
        {
            var data = await _mediator.Send(obj);
            return Ok(data);
        }
    }
}