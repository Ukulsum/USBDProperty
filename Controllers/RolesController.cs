using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using USBDProperty.Models;

namespace USBDProperty.Controllers
{
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RolesController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager) {
                this._context = context;
            this._roleManager = roleManager;
            }
        public IActionResult Index()
        {
            return View(_roleManager.Roles);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public   async Task Create(string rname)
        {
            string msg = "";
            try
            {
                IdentityResult roleresult = null;
                roleresult = await _roleManager.CreateAsync(new IdentityRole { Name = rname });

                if (roleresult.Succeeded)
                {

                    //return RedirectToAction("Index");
                }

                else if (roleresult.Errors.Count() > 0)
                {
                    msg = DisplayError(msg, roleresult);
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            //return View();
        }
        private static string DisplayError(string msg, IdentityResult roleresult)
        {
            foreach (var er in roleresult.Errors)
            {
                msg = er.ToString();

            }

            return msg;
        }
    }
}
