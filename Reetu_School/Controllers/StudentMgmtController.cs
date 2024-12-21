using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reetu_School.Models;

namespace Reetu_School.Controllers
{
    public class StudentMgmtController : Controller
    {
        private readonly IMediator _mediator;
        private IHttpContextAccessor _httpContextAccessor;
        public StudentMgmtController(IMediator mediator, IHttpContextAccessor httpContextAccessor)

        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult StudentRegistration()
        {
            return View();
        }
        public async Task<IActionResult> SaveStudentRegistration([FromBody] SaveStudentRegistration obj)
        {
            var data = await _mediator.Send(obj);
            return Ok(data);
        }
        public IActionResult StudentList()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> StudentCommandList(int Id)
        {
            var data = await _mediator.Send(new StudentCommandList { Id = Id });
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStatusList([FromBody] UpdateStatusList obj)
        {
            var data = await _mediator.Send(obj);
            return View();
        }
        public IActionResult Demo()
        {
            return View();
        }
        public IActionResult Cards()
        {
            return View();
        }
    }
}
