using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using USBDProperty.Models;
using USBDProperty.ViewModels;

namespace USBDProperty.Controllers
{
   [Authorize(Roles = "Agent")]
    public class AgentHomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AgentHomeController(ApplicationDbContext context)
        { 
            _context = context;
        }
        public IActionResult Index()
        {
            try
            {
                return View("Dashboard");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       
        [AllowAnonymous]
        public IActionResult AgentIndex(int id) ///All Developer show for Annonimous User
        {
            try
            {
                var data = _context.DevelopersorAgent.Where(p => p.ID == id).OrderByDescending(p => p.ID).FirstOrDefault();
                return View(data);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }             
        }
      

        [AllowAnonymous]
        public IActionResult AgentProperties()
        
        {
            //var data = _context.DevelopersorAgent.Where(p => p.ID == id).OrderByDescending(p => p.ID).FirstOrDefault();
            return View();
        }

        [AllowAnonymous]
        public JsonResult HomeAgentProject(int id) //Project list show annonymous user
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

    }
}
