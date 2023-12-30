using Microsoft.AspNetCore.Mvc;

namespace USBDProperty.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
