using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using USBDProperty.Models;

namespace USBDProperty.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        //public JsonResult Getlocation(int aid)
        //{
        //    var record = _context.PropertyDetails.OrderBy(c => c.Location)
        //                                    .Where(d => d.AreaId.Equals(aid)).ToList();
        //    return Json(record);
        //}

        public IActionResult Index()
        {
            ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "AreaName");
            ViewData["PropertyInfoId"] = new SelectList(_context.PropertyDetails, "PropertyInfoId", "Location");
            //ViewData["PropertyInfoId"] = new SelectList(_context.PropertyDetails, "PropertyInfoId", "location");
            //ViewData["PropertyInfoId"] = new SelectList(_context.PropertyDetails.OrderBy(c => c.Location)
            //               .Where(d => d.Area.AreaId.Equals(aid)).ToList(), "PropertyInfoId", "Location");
            //var record = _context.

            return View();
        }


        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}