using Microsoft.AspNetCore.Mvc;
using USBDProperty.Models;
using USBDProperty.ViewModels;

namespace USBDProperty.Controllers
{
    public class AgentHomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AgentHomeController(ApplicationDbContext context)
        { 
            _context = context;
        }
        public IActionResult Index()
        {
            return View("Dashboard");
        }

        public IActionResult AgentIndex(int id)
        {
            var data = _context.DevelopersorAgent.Where(p => p.ID == id).ToList();
            
            return View(data);
        }
    }
}
