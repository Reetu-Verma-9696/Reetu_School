using Microsoft.AspNetCore.Mvc;
using MediatR;
using Reetu_School.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using static Reetu_School.Common.DataLayer;

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
            if (User.Identity.IsAuthenticated)
            {
                var Identity = (ClaimsIdentity)User.Identity;
                string UserRole = Identity.Claims.Where(c => c.Type == ClaimTypes.Role).SingleOrDefault().Value.ToString();
                if(UserRole == "Admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if(UserRole == "Employee")
                {
                    return RedirectToAction("Index", "Employee");
                }
                else if (UserRole == "Customer")
                {
                    return RedirectToAction("Index", "Customer");
                }
                else 
                {
                    return RedirectToAction("SignOut");
                }
            }
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult SignUPList()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] SignUp SignUp)
        {
            var data = await _mediator.Send(SignUp);
            return Ok(data);
        }
        [HttpGet]

        public async Task<IActionResult> GetSignUpDetail(int Id)
        {
            var data = await _mediator.Send(new GetSignUpDetail { Id = Id });
            return Ok(data);
        }

        //for Login
        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login Login, string returnUrl = "")
        {
            var data = (dynamic)null;
            data = await _mediator.Send(Login);
            if (data.responseCode == 200)
            {
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    var result = new { data = data, returnURL = returnUrl };
                    data = ResponseResult.SuccessResponse("Success", result);
                }
                else
                {
                    var result = new { data = data, returnURL = "0" };
                    data = ResponseResult.SuccessResponse("Success", result);
                }
            }
            return Ok(data);
        }
        [HttpDelete]
        public async Task <IActionResult> DeleteCommand([FromBody] DeleteCommand DeleteCommand)
        {
            var data = await _mediator.Send(DeleteCommand);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> BindMasterGroupDetails(int Id)
        {
            var data = await _mediator.Send(new BindMasterGroupDetails { Id = Id });
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> SaveGroupDetails([FromBody] SaveGroupDetails SaveGroupDetails)
        {
            var data = await _mediator.Send(SaveGroupDetails);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> AssignDashboard()
        {
            var data = await _mediator.Send(new AssignDashboard());
            return PartialView(data);
        }
        [HttpPost]
        public async Task<IActionResult> SaveEmpData([FromBody] SaveEmpData SaveEmpData)
        {
            var data = await _mediator.Send(SaveEmpData);
            return Ok(data);
        }
        //for signUp
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegistrationCommand([FromBody] RegistrationCommand obj)
        {
            var data = await _mediator.Send(obj);
            return Ok(data);
        }
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSignUpRecord([FromBody] DeleteSignUpRecord req)
        {
            var data = await _mediator.Send(req);
            return Ok(data);
        }
       

    }
}
