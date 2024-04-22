using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using USBDProperty.Models;
using USBDProperty.ViewModels;

namespace USBDProperty.Controllers
{
    [Authorize(Roles = "Admin,Super Admin")        ]
    public class AdminController : Controller
    {
        public readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Dashboard()
        {
            var propertyVM = new PropertyViewModel
            {
                AgentID = _context.DevelopersorAgent.Count(),
                ProjectId = _context.DevelopersorAgent.Count( ),
                PropertyInfoId = _context.PropertyDetails.Count( )
            };
            return View(propertyVM);
        }
    }
}
