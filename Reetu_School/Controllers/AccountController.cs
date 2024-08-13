using Microsoft.AspNetCore.Mvc;
using MediatR;
using Reetu_School.Models;
using Serilog;

namespace Reetu_School.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;
        private IHttpContextAccessor _httpContextAccessor;
        public AccountController(IMediator mediator, IHttpContextAccessor httpContextAccessor) 

        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] SignUp SignUp)
        {
            var data = await _mediator.Send(SignUp);
            return Ok(data);
        }
       // [HttpGet]

        //public async Task<IActionResult> GetSignUpDetail(int Id)
        //{
        //    var data = await _mediator.Send(new GetSignUpDetail { Id = Id });
        //        return Ok(data);
        //}
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login Login)
        {
            var data = await _mediator.Send(Login);
            return Ok(data);
        }
    }
}
