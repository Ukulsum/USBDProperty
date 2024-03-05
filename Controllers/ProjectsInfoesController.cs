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
            try
            {
                if (User.IsInRole("Admin"))
                { 
                    var applicationDbContext = _context.ProjectsInfo.OrderByDescending(p => p.Id).Include(p => p.Developers);
                    return View(await applicationDbContext.ToListAsync());

                }
                else if (User.IsInRole("Agent"))
                {
                    var agentId = _context.DevelopersorAgent.Where(a => a.Email.Equals(User.Identity.Name)).Select(s => s.ID);
                   
                    var applicationDbContext = _context.ProjectsInfo.Where(p => p.Id.Equals(agentId)).OrderByDescending(p => p.Id);
                    return View(await applicationDbContext.ToListAsync());
                }

                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [AllowAnonymous]
        public JsonResult GetDrpProject(int devid)
        {
            try
            {                
                var project = _context.ProjectsInfo.OrderByDescending(p => p.Id)
                                                   .Where(d => d.AgentID.Equals(devid)).ToList();
                return Json(new { Data = project });
            }
            catch (Exception ex)
            {
                return Json(new { Data = ex.Message });
            }
        }

        [AllowAnonymous]
        public JsonResult GetProjects(int id)
        {
            try
            {
                var data = _context.ProjectsInfo.Where(d => d.AgentID.Equals(id));
                return Json(new { Data = data });
            }
            catch(Exception ex)
            {
                return Json(new { Data = ex.Message });
            }
        }
        [AllowAnonymous]
        public JsonResult GetProjectsVideo()
        {
            try
            {
                var data = _context.ProjectsInfo.OrderByDescending(p => p.Id).ToList();
                return Json(new { Data = data });
            }
            catch(Exception ex)
            {
                return Json(new {data = ex.Message});
            }
        }
        // GET: ProjectsInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
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
            catch (Exception ex)
            {
               return BadRequest(ex.Message);
            }
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
            try
            {
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
                        projectsInfo.LocationMap = "/Developer/LocationMap/" + fileName;
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
                        projectsInfo.ProjectVideo = "/Developer/Video/" + fileName;
                        //projectsInfo.ProjectVideo = "/Developer/Video/" + fileName;
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please provide mp4|.vlc|gif");
                        //return View(projectsInfo);
                    }
                }
                _context.Add(projectsInfo);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                ViewData["AgentID"] = new SelectList(_context.DevelopersorAgent, "ID", "CompanyName", projectsInfo.AgentID);
                return View(projectsInfo);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            //ViewData["AgentID"] = new SelectList(_context.DevelopersorAgent, "ID", "CompanyName", projectsInfo.AgentID);
            //return View(projectsInfo);
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
                ViewData["AgentID"] = new SelectList(_context.DevelopersorAgent.OrderBy(a => a.CompanyName), "ID", "CompanyName", projectsInfo.AgentID);
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
                if(projectsInfo.MapPath != null)
                {
                    string extension = Path.GetExtension(projectsInfo.MapPath.FileName).ToLower();
                    if(extension == ".jpg" || extension == ".png" || extension == ".jpeg" || extension == "..svg" || extension == ".gif")
                    {
                        string fileName = $" {projectsInfo.Title} _map {extension}";
                        string path = Path.Combine(rPath, "LocationMap", fileName);
                        using (var fileStrem = new FileStream(path, FileMode.Create))
                        {
                            await projectsInfo.MapPath.CopyToAsync(fileStrem);
                        }
                        projectsInfo.LocationMap = "/Developer/LocationMap/" + fileName;
                        if (System.IO.File.Exists(rPath))
                        {
                            System.IO.File.Delete(rPath);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please provide .jpg|.jpeg|.png");
                        return View(projectsInfo);
                    }
                }
                else
                {
                    data.LocationMap = projectsInfo.LocationMap;
                }
                if(projectsInfo.ProjectVideoPath != null)
                {
                    string extension = Path.GetExtension(projectsInfo.ProjectVideoPath.FileName).ToLower();
                    if(extension == ".mp4" || extension == ".gif" || extension == ".vlc")
                    {
                        string fileName = $" {projectsInfo.Title} _video {extension}";
                        string path = Path.Combine(rPath, "Video", fileName);
                        using(var fileStrem = new FileStream(path, FileMode.Create))
                        {
                            await projectsInfo.ProjectVideoPath.CopyToAsync(fileStrem);
                        }
                        projectsInfo.ProjectVideo = "/Developer/Video/" + fileName;
                        if (System.IO.File.Exists(rPath))
                        {
                            System.IO.File.Delete(rPath);
                        }
                    }
                    else{
                        ModelState.AddModelError("", "Please provide .jpg| .png | .jepg");
                        return View(projectsInfo);
                    }
                }
                else
                {
                    data.ProjectVideo = projectsInfo.ProjectVideo;
                }
                data.ProjectVideo = projectsInfo.ProjectVideo;
                data.ProjectName = projectsInfo.ProjectName;
                data.Title = projectsInfo.Title;
                data.Description = projectsInfo.Description;
                data.LocationMap = projectsInfo.LocationMap;
                data.AgentID = projectsInfo.AgentID;
                data.AreaID = projectsInfo.AreaID;
                data.Location = projectsInfo.Location;

                _context.Update(data);
                if(await _context.SaveChangesAsync() > 0)
                {
                    return RedirectToAction(nameof(Index));
                }


              
                ViewData["AgentID"] = new SelectList(_context.DevelopersorAgent.OrderBy(a => a.CompanyName), "ID", "CompanyName", projectsInfo.AgentID);
                return View(projectsInfo);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(projectsInfo);
            }
            
        }

        // GET: ProjectsInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: ProjectsInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
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
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool ProjectsInfoExists(int id)
        {
          return (_context.ProjectsInfo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
