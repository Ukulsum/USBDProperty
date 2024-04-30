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
    [Authorize(Roles = "Admin,Super Admin,Agent")]
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
                if (User.IsInRole("Agent"))
                {
                    var data = await _context.ProjectsInfo.Include(a => a.Developers)
                                                    .OrderByDescending(p => p.Id)
                                                    .Where(d => d.Developers.Email.Equals(User.Identity.Name))
                                                    .ToListAsync();
                    return View(data);
                }
                else if (User.IsInRole("Admin") || User.IsInRole("Super Admin"))
                {
                    var applicationDbContext = _context.ProjectsInfo.OrderByDescending(p => p.Id).Include(p => p.Developers);
                    return View(await applicationDbContext.ToListAsync());
                }


                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
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
                //if (User.IsInRole("Agent"))
                //{
                //    var data = _context.ProjectsInfo.OrderBy(p => p.ProjectName)
                //                                    .Include("Developers")
                //                                    .Where(d => d.Developers.Email.Equals(User.Identity.Name) && d.AgentID.Equals(devid)).ToList();

                //    return Json(new { Data = data });
                //}
                //else if (User.IsInRole("Admin") || User.IsInRole("Super Admin"))
                //{
                //    var data = _context.ProjectsInfo.OrderBy(p => p.ProjectName)
                //                                    .Include("Developers")
                //                                    .Where(d => d.AgentID.Equals(devid)).ToList();
                //    return Json(new { Data = data });
                //}
                //return Json(new { IsSuccess = false });
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
                var data = _context.ProjectsInfo.Where(d => d.AgentID.Equals(id))
                                                .Select(p => new { p.ProjectName, p.Id }).Distinct();
                return Json(new { Data = data });
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {
                return Json(new { data = ex.Message });
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
            if (User.IsInRole("Agent"))
            {
                ViewData["AgentID"] = new SelectList(_context.DevelopersorAgent.Where(a => a.Email.Equals(User.Identity.Name)), "ID", "CompanyName");
                return View();
            }
            else
            {
                ViewData["AgentID"] = new SelectList(_context.DevelopersorAgent, "ID", "CompanyName");
                return View();
            }
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
                }
                if (projectsInfo.ProjectVideoPath != null)
                {
                    string extension = Path.GetExtension(projectsInfo.ProjectVideoPath.FileName).ToLower();
                    if (extension == ".mp4" || extension == ".gif" || extension == ".vlc")
                    {
                        string fileName = $" {projectsInfo.Title} _video {extension}";
                        string path = Path.Combine(rpath, "Video", fileName);
                        using (var fileStrem = new FileStream(path, FileMode.Create))
                        {
                            await projectsInfo.ProjectVideoPath.CopyToAsync(fileStrem);
                        }
                        projectsInfo.ProjectVideo = "/Developer/Video/" + fileName;
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please provide mp4|.vlc|gif");
                    }
                }
                _context.Add(projectsInfo);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                if (User.IsInRole("Agent"))
                {
                    ViewData["AgentID"] = new SelectList(_context.DevelopersorAgent.Where(a => a.Email.Equals(User.Identity.Name)), "ID", "CompanyName", projectsInfo.AgentID);
                }
                else if (User.IsInRole("Admin") || User.IsInRole("Super Admin"))
                {
                    ViewData["AgentID"] = new SelectList(_context.DevelopersorAgent, "ID", "CompanyName", projectsInfo.AgentID);
                }
                return View(projectsInfo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
                if (User.IsInRole("Agent"))
                {
                    ViewData["AgentID"] = new SelectList(_context.DevelopersorAgent.Where(a => a.Email.Equals(User.Identity.Name)).OrderBy(a => a.CompanyName), "ID", "CompanyName", projectsInfo.AgentID);
                }
                else if (User.IsInRole("Admin") || User.IsInRole("Super Admin"))
                {
                    ViewData["AgentID"] = new SelectList(_context.DevelopersorAgent.OrderBy(a => a.CompanyName), "ID", "CompanyName", projectsInfo.AgentID);
                }
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
                if (projectsInfo.MapPath != null)
                {
                    if (data != null)
                    {
                        string npath = data.LocationMap.Replace("~/", "");
                        string rootpath = wwwRootPath + npath;
                        if (System.IO.File.Exists(rootpath))
                        {
                            System.IO.File.Delete(rootpath);
                        }

                        string extension = Path.GetExtension(projectsInfo.MapPath.FileName).ToLower();
                        if (extension == ".jpg" || extension == ".png" || extension == ".jpeg" || extension == "..svg" || extension == ".gif")
                        {
                            string fileName = $" {projectsInfo.Title} _map {extension}";
                            string path = Path.Combine(rPath, "LocationMap", fileName);
                            using (var fileStrem = new FileStream(path, FileMode.Create))
                            {
                                await projectsInfo.MapPath.CopyToAsync(fileStrem);
                            }
                            projectsInfo.LocationMap = "/Developer/LocationMap/" + fileName;
                        }
                        else
                        {
                            ModelState.AddModelError("", "Please provide .jpg|.jpeg|.png");
                            return View(projectsInfo);
                        }
                    }
                }
                else
                {
                    data.LocationMap = projectsInfo.LocationMap;
                }
                if (projectsInfo.ProjectVideoPath != null)
                {
                    if (data != null)
                    {
                        string vpath = data.ProjectVideo.Replace("~/", "");
                        string vrootpath = wwwRootPath + vpath;
                        if (System.IO.File.Exists(vrootpath))
                        {
                            System.IO.File.Delete(vpath);
                        }

                        string extension = Path.GetExtension(projectsInfo.ProjectVideoPath.FileName).ToLower();
                        if (extension == ".mp4" || extension == ".gif" || extension == ".vlc")
                        {
                            string fileName = $" {projectsInfo.Title} _video {extension}";
                            string path = Path.Combine(rPath, "Video", fileName);
                            using (var fileStrem = new FileStream(path, FileMode.Create))
                            {
                                await projectsInfo.ProjectVideoPath.CopyToAsync(fileStrem);
                            }
                            projectsInfo.ProjectVideo = "/Developer/Video/" + fileName;
                        }

                        else
                        {
                            ModelState.AddModelError("", "Please provide .jpg| .png | .jepg");
                            return View(projectsInfo);
                        }
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
                if (await _context.SaveChangesAsync() > 0)
                {
                    return RedirectToAction(nameof(Index));
                }

                if (User.IsInRole("Agent"))
                {
                    ViewData["AgentID"] = new SelectList(_context.DevelopersorAgent.Where(a => a.Email.Equals(User.Identity.Name)).OrderBy(a => a.CompanyName), "ID", "CompanyName", projectsInfo.AgentID);
                }
                else if (User.IsInRole("Admin") || User.IsInRole("Super Admin"))
                {
                    ViewData["AgentID"] = new SelectList(_context.DevelopersorAgent.OrderBy(a => a.CompanyName), "ID", "CompanyName", projectsInfo.AgentID);
                }
                return View(projectsInfo);
            }
            catch (Exception ex)
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
                string fpath = "";
                string wwwRootPath = "";
                if(_environment != null)
                {
                    wwwRootPath = _environment.WebRootPath;
                    fpath = wwwRootPath + "/Content";
                }
                else
                {
                    wwwRootPath = Directory.GetCurrentDirectory();
                    fpath = Path.Combine(wwwRootPath, "/wwwroot/Content");
                }
                if (_context.ProjectsInfo == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.ProjectsInfo'  is null.");
                }
                var projectsInfo = await _context.ProjectsInfo.FindAsync(id);
                if (projectsInfo != null)
                {
                    string path = projectsInfo.LocationMap.Replace("~", "");
                    string vpath = projectsInfo.ProjectVideo.Replace("~", "");
                    _context.ProjectsInfo.Remove(projectsInfo);
                    if(await _context.SaveChangesAsync() > 0)
                    {
                        string rootPath = wwwRootPath + path;                      
                        if(System.IO.File.Exists(rootPath))
                        {
                            System.IO.File.Delete(rootPath);
                        }

                        string vrootPath = wwwRootPath + vpath;
                        if (System.IO.File.Exists(vrootPath))
                        {
                            System.IO.File.Delete(vrootPath);
                        }
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
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
