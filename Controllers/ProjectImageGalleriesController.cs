using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using USBDProperty.Models;

namespace USBDProperty.Controllers
{
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
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProjectImageGallery.Include(p => p.ProjectsInfo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProjectImageGalleries/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: ProjectImageGalleries/Create
        public IActionResult Create(int id)
        {
            ViewData["ProjectID"] = new SelectList(_context.ProjectsInfo.Where(p => p.Id.Equals(id)), "Id", "Location");
            return View();
        }

        // POST: ProjectImageGalleries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(ProjectImageGallery projectImageGallery)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            string rPath = "";
        //            string wwwRootPath = "";
        //            if(_environment != null)
        //            {
        //                wwwRootPath = _environment.WebRootPath;
        //                rPath = wwwRootPath + "/Content/Images";
        //            }
        //            else
        //            {
        //                wwwRootPath = Directory.GetCurrentDirectory();
        //                rPath = Path.Combine(wwwRootPath, "/wwwroot/Content/Images");
        //            }
        //            for(int i=0; i< projectImageGallery.MultipleImage.Count(); i++)
        //            {
        //                string extention = Path.GetExtension(MultipleImage[i].FileName).ToLower();
        //                if(extention == ".jpg" || extention == ".png" || extention == ".jpeg")
        //                {
        //                    string fileName = projectImageGallery.ProjectID + "_" + i + 1 + extention;
        //                    string path = Path.Combine(rPath, fileName);
        //                    using(var fileStrem = new FileStream(path, FileMode.Create))
        //                    {
        //                        await MultiImagePath[i].CopyToAsync(fileStrem);
        //                    }
        //                    projectImageGallery.Id = 0;
        //                    projectImageGallery.ImagePath = "/Content/Images/" + fileName;
        //                    _context.Add(projectImageGallery);
        //                    await _context.SaveChangesAsync();
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            ModelState.AddModelError("", ex.Message);
        //            return View();
        //        }
               
        //        return RedirectToAction(nameof(Index));
                
        //    }
        //    ViewData["ProjectID"] = new SelectList(_context.ProjectsInfo, "Id", "ProjectName", projectImageGallery.ProjectID);
        //    return View(projectImageGallery);
        //}

        // GET: ProjectImageGalleries/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

        // POST: ProjectImageGalleries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ImagePath,ProjectID")] ProjectImageGallery projectImageGallery)
        {
            if (id != projectImageGallery.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectImageGallery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectImageGalleryExists(projectImageGallery.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectID"] = new SelectList(_context.ProjectsInfo, "Id", "Location", projectImageGallery.ProjectID);
            return View(projectImageGallery);
        }

        // GET: ProjectImageGalleries/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: ProjectImageGalleries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
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

        private bool ProjectImageGalleryExists(int id)
        {
          return (_context.ProjectImageGallery?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
