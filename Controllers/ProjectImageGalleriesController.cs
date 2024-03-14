using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using USBDProperty.Models;

namespace USBDProperty.Controllers
{
    [Authorize(Roles = "Admin,Agent")]
    public class ProjectImageGalleriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public ProjectImageGalleriesController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: ProjectImageGalleries
        public async Task<IActionResult> Index(int projectId=0)
        {
            try
            {

            
                if (User.IsInRole("Agent"))
                {
                    var projectData = _context.ProjectImageGallery.Include(p => p.ProjectsInfo.Developers)
                                                                  .Where(d => d.ProjectsInfo.Developers.Email.Equals    (User.Identity.Name)).ToList();
                    if (projectId > 0)
                    {
                        projectData = projectData.Where(d => d.ProjectsInfo.Equals(projectId)).ToList();
                    }
                    return View(projectData);
                }
                else if(User.IsInRole("Admin") || User.IsInRole("Super Admin"))
                {
                    var projectData = _context.ProjectImageGallery.Include(p => p.ProjectsInfo.Developers).ToList();
                    if (projectId > 0)
                    {
                        projectData = projectData.Where(d => d.ProjectsInfo.Equals(projectId)).ToList();
                    }
                    return View(projectData);
                }
            //{
            //    if (User.IsInRole("Admin"))
            //    {
            //        var applicationDbContext = _context.ProjectImageGallery.Include(p => p.ProjectsInfo).ToList();


            //        if (projectId != null || projectId > 0)
            //        {
            //            applicationDbContext = applicationDbContext.Where(p => p.ProjectID.Equals(projectId)).ToList();
            //        }
            //        return View(applicationDbContext.ToList());
            //    }
            //    else if (User.IsInRole("Agent"))
            //    {
            //        var devID = _context.DevelopersorAgent.Where(a => a.Email.Equals(User.Identity.Name) && a.ID.Equals(agentId)).Select(s => s.ID);

            //        var appDbData = _context.ProjectImageGallery.Include(p => p.ProjectsInfo).Where(d => d.Id.Equals(devID)).OrderByDescending(p => p.Id);

            //        return View( await appDbData.ToListAsync());
             //}

                //var image = ICollection<ProjectImageGallery.Mul>
                //var applicationDbContext = _context.ProjectImageGallery.Include(p => p.ProjectsInfo).ToList();
              

                //if (projectId != null || projectId > 0)
                //{
                //    applicationDbContext =  applicationDbContext.Where(p => p.ProjectID.Equals(projectId)).ToList();
                //}

                //ViewData["ProjectId"] = new SelectList(_context.ProjectsInfo, "Id", "ProjectName");
                ViewData["AgentId"] = new SelectList(_context.DevelopersorAgent, "ID", "CompanyName");
                //return View(applicationDbContext.ToList());
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: ProjectImageGalleries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null || _context.ProjectImageGallery == null)
                {
                    return NotFound();
                }

                var projectImageGallery = await _context.ProjectImageGallery
                    .Include(p => p.ProjectsInfo)
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (projectImageGallery == null)
                {
                    return NotFound();
                }

                return View(projectImageGallery);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: ProjectImageGalleries/Create
        public IActionResult Create(int id)
        {
            ViewData["ProjectID"] = new SelectList(_context.ProjectsInfo.Where(p => p.Id.Equals(id)), "Id", "Location");
            return View();
        }

        // POST: ProjectImageGalleries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectImageGallery projectImageGallery, List<IFormFile> MultipleImagePath)
        {
            //if (ModelState.IsValid)
            //{
                try
                {
                    string rPath = "";
                    string wwwRootPath = "";
                    if (_environment != null)
                    {
                        wwwRootPath = _environment.WebRootPath;
                        rPath = wwwRootPath + "/Content/Images";
                    }
                    else
                    {
                        wwwRootPath = Directory.GetCurrentDirectory();
                        rPath = Path.Combine(wwwRootPath, "/wwwroot/Content/Images");
                    }
                    for (int i = 0; i <MultipleImagePath.Count(); i++)
                    {
                        string extention = Path.GetExtension(MultipleImagePath[i].FileName).ToLower();
                        if (extention == ".jpg" || extention == ".png" || extention == ".jpeg")
                        {
                            string fileName = projectImageGallery.ProjectID + "_" + i + 1 + extention;
                            string path = Path.Combine(rPath, fileName);
                            using (var fileStrem = new FileStream(path, FileMode.Create))
                            {
                                await MultipleImagePath[i].CopyToAsync(fileStrem);
                            }
                            projectImageGallery.Id = 0;
                            projectImageGallery.ImagePath = "/Content/Images/" + fileName;
                            _context.Add(projectImageGallery);
                            await _context.SaveChangesAsync();
                        }
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(projectImageGallery);
                }

                return RedirectToAction(nameof(Index));

            //}
            ViewData["ProjectID"] = new SelectList(_context.ProjectsInfo, "Id", "ProjectName", projectImageGallery.ProjectID);
            return View(projectImageGallery);
        }

        // GET: ProjectImageGalleries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null || _context.ProjectImageGallery == null)
                {
                    return NotFound();
                }

                var projectImageGallery = await _context.ProjectImageGallery.FindAsync(id);
                if (projectImageGallery == null)
                {
                    return NotFound();
                }
                ViewData["ProjectID"] = new SelectList(_context.ProjectsInfo, "Id", "Location", projectImageGallery.ProjectID);
                return View(projectImageGallery);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // POST: ProjectImageGalleries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProjectImageGallery projectImageGallery)
        {
            try
            {
                if (id != projectImageGallery.Id)
                {
                    return NotFound();
                }
                var data = await _context.ProjectImageGallery.FindAsync(id);
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
                if(projectImageGallery.ImageFile != null)
                {
                    string extension = Path.GetExtension(projectImageGallery.ImageFile.FileName).ToLower();
                    if(extension == ".jpg" || extension == ".png" || extension == ".jpeg")
                    {
                        string fileName = projectImageGallery.Name + extension;
                        string path = Path.Combine(fpath, "Images", fileName);
                        using (var fileStrem = new FileStream(path, FileMode.Create))
                        {
                            await projectImageGallery.ImageFile.CopyToAsync(fileStrem);
                        }
                        projectImageGallery.ImagePath = "/Content/Images/" + fileName;
                        if (System.IO.File.Exists(fpath))
                        {
                            System.IO.File.Delete(fpath);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please provide .jpg| .jpeg| .png");
                        return View(projectImageGallery);
                    }
                }
                else
                {
                    data.ImagePath = projectImageGallery.ImagePath;
                }
                data.Name = projectImageGallery.Name;
                data.ProjectID = projectImageGallery.ProjectID;
                data.ImagePath = projectImageGallery.ImagePath;
                data.Id = projectImageGallery.Id;

                _context.Update(data);
                if(await _context.SaveChangesAsync() > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(projectImageGallery);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
            ViewData["ProjectID"] = new SelectList(_context.ProjectsInfo, "Id", "Location", projectImageGallery.ProjectID);
            return View(projectImageGallery);
        }

        // GET: ProjectImageGalleries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null || _context.ProjectImageGallery == null)
                {
                    return NotFound();
                }

                var projectImageGallery = await _context.ProjectImageGallery
                    .Include(p => p.ProjectsInfo)
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (projectImageGallery == null)
                {
                    return NotFound();
                }

                return View(projectImageGallery);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // POST: ProjectImageGalleries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                if (_context.ProjectImageGallery == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.ProjectImageGallery'  is null.");
                }
                var projectImageGallery = await _context.ProjectImageGallery.FindAsync(id);
                if (projectImageGallery != null)
                {
                    _context.ProjectImageGallery.Remove(projectImageGallery);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        private bool ProjectImageGalleryExists(int id)
        {
          return (_context.ProjectImageGallery?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
