using Microsoft.AspNetCore.Mvc;

namespace testCoreApp.Areas.Employee.Controllers

{ 
[Area("Employee")]

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
