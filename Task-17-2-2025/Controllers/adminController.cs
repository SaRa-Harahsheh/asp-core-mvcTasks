using Microsoft.AspNetCore.Mvc;

namespace Task_17_2_2025.Controllers
{
    public class adminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult AdminDashboard()
        {
            return View();
        }
    }
}
