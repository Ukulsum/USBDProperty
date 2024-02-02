using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using USBDProperty.Models;

namespace USBDProperty.Controllers
{
    [Authorize(Roles ="Admin,Agent")]
    public class ProjectsInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public ProjectsInfoesController(ApplicationDbContext context, 
            IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: ProjectsInfoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProjectsInfo.Include(p => p.Developers);
            return View(await applicationDbContext.ToListAsync());
        }
        [AllowAnonymous]
        public JsonResult GetProjects(int id)
        {
            var data = _context.ProjectsInfo.Where(d => d.AgentID.Equals(id));
            return Json(new { Data = data });
        }
        // GET: ProjectsInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProjectsInfo == null)
            {
                return NotFound();
            }

            var projectsInfo = await _context.ProjectsInfo
                .Include(p => p.Developers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectsInfo == null)
            {
                return NotFound();
            }

            return View(projectsInfo);
        }

        // GET: ProjectsInfoes/Create
        public IActionResult Create()
        {
            ViewData["AgentID"] = new SelectList(_context.DevelopersorAgent, "ID", "CompanyName");
            return View();
        }

        // POST: ProjectsInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
         
        public async Task<IActionResult> Create(ProjectsInfo projectsInfo)
        {
            //if (ModelState.IsValid)
            //{
                string wwwRootPath = "";
                string rpath = "";
                if (_environment != null)
                {
                    wwwRootPath = _environment.WebRootPath;
                    rpath = wwwRootPath + "/Developer";
                }
                else
                {
                    wwwRootPath = Directory.GetCurrentDirectory();
                    rpath = Path.Combine(wwwRootPath, "/wwwroot/Developer");
                }
                if (projectsInfo.MapPath != null)
                {
                    string extension = Path.GetExtension(projectsInfo.MapPath.FileName).ToLower();
                    if (extension == ".jpg" || extension == ".png" || extension == ".jpeg" || extension == "..svg" || extension == ".gif")
                    {
                        //string fileName = developersorAgent.CompanyName + extension;
                        string fileName = $" {projectsInfo.Title} _map {extension}";
                        string path = Path.Combine(rpath, "LocationMap", fileName);
                        using (var fileStrem = new FileStream(path, FileMode.Create))
                        {
                            await projectsInfo.MapPath.CopyToAsync(fileStrem);
                        }
                        projectsInfo.LocationMap = "~/Developer/LocationMap/" + fileName;
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please provide jpg|.jpeg|png");
                        return View(projectsInfo);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Please provide location map ");
                   // return View(projectsInfo);
                }
            if (projectsInfo.ProjectVideoPath != null)
            {
                string extension = Path.GetExtension(projectsInfo.ProjectVideoPath.FileName).ToLower();
                if (extension == ".mp4" || extension == ".gif" || extension == ".vlc")
                {
                    //string fileName = developersorAgent.CompanyName + extension;
                    string fileName = $" {projectsInfo.Title} _video {extension}";
                    string path = Path.Combine(rpath, "Video", fileName);
                    using (var fileStrem = new FileStream(path, FileMode.Create))
                    {
                        await projectsInfo.ProjectVideoPath.CopyToAsync(fileStrem);
                    }
                    projectsInfo.ProjectVideo = "~/Developer/Video/" + fileName;
                }
                else
                {
                    ModelState.AddModelError("", "Please provide mp4|.vlc|gif");
                    //return View(projectsInfo);
                }
            }
            _context.Add(projectsInfo);
               if( await _context.SaveChangesAsync()>0)
            {
                return RedirectToAction(nameof(Index));
            }
               
            //}
            ViewData["AgentID"] = new SelectList(_context.DevelopersorAgent, "ID", "CompanyName", projectsInfo.AgentID);
            return View(projectsInfo);
        }

        // GET: ProjectsInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null || _context.ProjectsInfo == null)
                {
                    return NotFound();
                }

                var projectsInfo = await _context.ProjectsInfo.FindAsync(id);
                if (projectsInfo == null)
                {
                    return NotFound();
                }
                var allprojectId = (from a in _context.Areas
                                    join c in _context.Citys on a.CityId equals c.CityId
                                    join d in _context.Divisions on c.DivisionId equals d.DivisionID
                                    join cc in _context.Countries on d.CountryId equals cc.CountryID
                                    where a.AreaId == projectsInfo.AreaID
                                    select new
                                    {
                                        DivitionId = d.DivisionID,
                                        CityId = c.CityId,
                                        CountryId = cc.CountryID
                                    }).FirstOrDefault();
                ViewData["AreaId"] = new SelectList(_context.Areas.OrderBy(a => a.AreaId), "AreaId", "AreaName", projectsInfo.AgentID);
                ViewData["CityId"] = new SelectList(_context.Citys, "CityId", "CityName", allprojectId.CityId);
                ViewData["DivisionId"] = new SelectList(_context.Divisions, "DivisionID", "DivisionName", allprojectId.DivitionId);
                ViewData["CountryId"] = new SelectList(_context.Countries, "CountryID", "CountryName", allprojectId.CountryId);
                    //ViewData["AgentID"] = new SelectList(_context.DevelopersorAgent, "ID", "Banner", projectsInfo.AgentID);
                return View(projectsInfo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: ProjectsInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProjectsInfo projectsInfo)
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,ProjectName,Location,LocationMap,AgentID")] ProjectsInfo projectsInfo)
        {
            try
            {
                if (id != projectsInfo.Id)
                {
                    return NotFound();
                }

                var data = await _context.ProjectsInfo.FindAsync(id);
                string wwwRootPath = "";
                string rPath = "";
                if (_environment != null)
                {
                    wwwRootPath = _environment.WebRootPath;
                    rPath = wwwRootPath + "/Developer";
                }
                else
                {
                    wwwRootPath = Directory.GetCurrentDirectory();
                    rPath = Path.Combine(wwwRootPath, "/wwwroot/Developer");
                }
                

                //if (modelstate.isvalid)
                //{
                //    try
                //    {
                //        _context.update(projectsinfo);
                //        await _context.savechangesasync();
                //    }
                //    catch (dbupdateconcurrencyexception)
                //    {
                //        if (!projectsinfoexists(projectsinfo.id))
                //        {
                //            return notfound();
                //        }
                //        else
                //        {
                //            throw;
                //        }
                //    }
                //    return redirecttoaction(nameof(index));
                //}
                //ViewData["AgentID"] = new SelectList(_context.DevelopersorAgent, "ID", "Banner", projectsInfo.AgentID);
                return View(projectsInfo);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction(nameof(Index));
            }
            
        }

        // GET: ProjectsInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProjectsInfo == null)
            {
                return NotFound();
            }

            var projectsInfo = await _context.ProjectsInfo
                .Include(p => p.Developers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectsInfo == null)
            {
                return NotFound();
            }

            return View(projectsInfo);
        }

        // POST: ProjectsInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProjectsInfo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProjectsInfo'  is null.");
            }
            var projectsInfo = await _context.ProjectsInfo.FindAsync(id);
            if (projectsInfo != null)
            {
                _context.ProjectsInfo.Remove(projectsInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectsInfoExists(int id)
        {
          return (_context.ProjectsInfo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
