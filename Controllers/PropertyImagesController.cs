using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using USBDProperty.Models;

namespace USBDProperty.Controllers
{
    public class PropertyImagesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public PropertyImagesController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: PropertyImages
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PropertyImages.Include(p => p.PropertyDetails);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PropertyImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PropertyImages == null)
            {
                return NotFound();
            }

            var propertyImages = await _context.PropertyImages
                .Include(p => p.PropertyDetails)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (propertyImages == null)
            {
                return NotFound();
            }

            return View(propertyImages);
        }

       // GET: PropertyImages/Create
        public IActionResult Create(int id)
        {
            ViewData["propertyInfoId"] = new SelectList(_context.PropertyDetails.Where(p => p.PropertyInfoId.Equals(id)), "PropertyInfoId", "Title");
            return View();
        }
        //public IActionResult Create()
        //{
        //    ViewData["propertyInfoId"] = new SelectList(_context.PropertyDetails, "PropertyInfoId", "Title");
        //    return View();
        //}

        // POST: PropertyImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( PropertyImages propertyImages, List<IFormFile> MultiImagePath)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string rpath = "";
                    string wwwRootPath = "";
                    if (_environment != null)
                    {
                        wwwRootPath = _environment.WebRootPath;
                        rpath = wwwRootPath + "/Content/Images";
                    }
                    else
                    {
                        wwwRootPath = Directory.GetCurrentDirectory();
                        rpath = Path.Combine(wwwRootPath, "/wwwroot/Content/Images");
                    }
                    //string fileN = Path.GetFileNameWithoutExtension(propertyDetails.Image.FileName);
                    //foreach(var item in MultiImagePath)
            for(int i=0;i<MultiImagePath.Count(); i++)
                    {
                        string extention = Path.GetExtension(MultiImagePath[i].FileName).ToLower();
                        if (extention == ".jpg" || extention == ".png" || extention == ".jpeg")
                        {
                            string fileName = propertyImages.propertyInfoId + "_" + i + 1 + extention;
                            string path = Path.Combine(rpath, fileName);
                            using (var fileStrem = new FileStream(path, FileMode.Create))
                            {
                                await MultiImagePath[i].CopyToAsync(fileStrem);
                            }
                            propertyImages.ID = 0;
                            propertyImages.MultiImagePath = "/Content/Images/" + fileName;
                            _context.Add(propertyImages);
                            await _context.SaveChangesAsync();
                        }
                    }
                  
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(propertyImages);
                }
                   
                return RedirectToAction(nameof(Index));
            }
            ViewData["propertyInfoId"] = new SelectList(_context.PropertyDetails, "PropertyInfoId", "Title", propertyImages.propertyInfoId);
            return View(propertyImages);
        }

        // GET: PropertyImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PropertyImages == null)
            {
                return NotFound();
            }

            var propertyImages = await _context.PropertyImages.FindAsync(id);
            if (propertyImages == null)
            {
                return NotFound();
            }
            ViewData["propertyInfoId"] = new SelectList(_context.PropertyDetails, "PropertyInfoId", "Location", propertyImages.propertyInfoId);
            return View(propertyImages);
        }

        // POST: PropertyImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,MultiImagePath,propertyInfoId")] PropertyImages propertyImages)
        {
            if (id != propertyImages.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propertyImages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyImagesExists(propertyImages.ID))
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
            ViewData["propertyInfoId"] = new SelectList(_context.PropertyDetails, "PropertyInfoId", "Location", propertyImages.propertyInfoId);
            return View(propertyImages);
        }

        // GET: PropertyImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PropertyImages == null)
            {
                return NotFound();
            }

            var propertyImages = await _context.PropertyImages
                .Include(p => p.PropertyDetails)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (propertyImages == null)
            {
                return NotFound();
            }

            return View(propertyImages);
        }

        // POST: PropertyImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PropertyImages == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PropertyImages'  is null.");
            }
            var propertyImages = await _context.PropertyImages.FindAsync(id);
            if (propertyImages != null)
            {
                _context.PropertyImages.Remove(propertyImages);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyImagesExists(int id)
        {
          return (_context.PropertyImages?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
