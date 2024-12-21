using Microsoft.AspNetCore.Mvc;

namespace Reetu_School.Controllers
{
    public class CustomerController : Controller
    {
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
    }
}
