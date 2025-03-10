using AspNetCoreGeneratedDocument;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reetu_School.Models;

namespace Reetu_School.Controllers
{
    public class CustomerController : Controller
    {
        private readonly Mediator _mediator;
        public CustomerController(Mediator mediator)
        {
            _mediator = mediator;
        }
        public IActionResult AddtoCart()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult ViewCart()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomerProfileDetail(int Id)
        {
            var data = await _mediator.Send(new GetCustomerProfileDetail 
            { Id = Id });
            return Ok(data);
        }
    }
}
