using Microsoft.AspNetCore.Mvc;

namespace USBDProperty.Controllers
{
    public class AgentHomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Dashboard");
        }

        public IActionResult AgentIndex()
        {
            return View();
        }
    }
}
