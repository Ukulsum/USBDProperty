using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        //public IActionResult About(DeveloperPropertyVm developerPropertyVm)
        //{
        //    return View();
        //}

        public IActionResult AgentIndex(int id)
        {
            var data = _context.DevelopersorAgent.Where(p => p.ID == id).OrderByDescending(p=>p.ID).FirstOrDefault();
            
            return View(data);
        }

        public JsonResult HomeAgentProject(int id)
        {
            try
            {
                var projectsData = _context.ProjectsInfo.Where(p => p.AgentID == id)
                                                        .OrderByDescending(p => p.Id)
                                                        .Include(p => p.Developers)
                                                        .Include(p => p.Area)
                                                        .ToList();                            

                return Json(new { data = projectsData });
            }
            catch(Exception ex)
            {
                return Json(new { data = "No record" });
            }
        }

        //public JsonResult Save(DeveloperPropertyVm developerPropertyVm)
        //{
        //    return Json()
        //}
    }
}
