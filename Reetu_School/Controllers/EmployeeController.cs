using Microsoft.AspNetCore.Mvc;

namespace Reetu_School.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
