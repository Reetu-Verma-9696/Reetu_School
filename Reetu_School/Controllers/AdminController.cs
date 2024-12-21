using Microsoft.AspNetCore.Mvc;

namespace Reetu_School.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
