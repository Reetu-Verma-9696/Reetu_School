using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reetu_School.Models;

namespace Reetu_School.Controllers
{
    public class FarmManagementController : Controller
    {
        private readonly IMediator _mediator;
        private IHttpContextAccessor _httpContextAccessor;
        public FarmManagementController(IMediator mediator, IHttpContextAccessor httpContextAccessor)

        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult AddCropDetails()
        {
            return View();
        }
        public IActionResult MemberRegistration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveMemberDetails([FromBody] SaveMemberDetailss obj)
        {
            var data = await _mediator.Send(obj);
            return Ok(data);
        }
        [HttpPost]
        public async  Task<IActionResult> GetMemberDetails(GetMemberDetails obj)
        {
            var data = await _mediator.Send(obj);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMember([FromBody] DeleteMember obj)
        {
            var data = await _mediator.Send(obj);
            return Ok(data);
        }
    }
}
