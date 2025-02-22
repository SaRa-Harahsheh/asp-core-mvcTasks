using Microsoft.AspNetCore.Mvc;

namespace Task_Four.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminDashboard()
        {
            return View();
        }
    }
}
