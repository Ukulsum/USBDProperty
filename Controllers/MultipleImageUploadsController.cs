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
    public class MultipleImageUploadsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public MultipleImageUploadsController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
        }

        // GET: MultipleImageUploads
        public async Task<IActionResult> Index()
        {
            try
            {
                var applicationDbContext = _context.MultipleImageUploads.Include(m => m.PropertyDetails);
                return View(await applicationDbContext.ToListAsync());
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: MultipleImageUploads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null || _context.MultipleImageUploads == null)
                {
                    return NotFound();
                }

                var multipleImageUpload = await _context.MultipleImageUploads
                    .Include(m => m.PropertyDetails)
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (multipleImageUpload == null)
                {
                    return NotFound();
                }
                return View(multipleImageUpload);
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: MultipleImageUploads/Create
        public IActionResult Create()
        {
            try
            {
                ViewData["propertyInfoId"] = new SelectList(_context.PropertyDetails, "PropertyInfoId", "Location");
                return View();
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }

        // POST: MultipleImageUploads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MultiImagePath,propertyInfoId")] MultipleImageUpload multipleImageUpload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string wwwRootPath = "";
                    if (_environment != null)
                    {
                        wwwRootPath = _environment.WebRootPath;
                    }
                    else
                    {
                        wwwRootPath = Directory.GetCurrentDirectory();
                    }
                    string extension = Path.GetExtension(multipleImageUpload.MultipleImage.FileName);
                    string fileName = multipleImageUpload.Title + extension;
                    string path = Path.Combine(wwwRootPath + "/wwwroot/Content/Images", fileName);
                    using (var fileStrem = new FileStream(path, FileMode.Create))
                    {
                        await multipleImageUpload.MultipleImage.CopyToAsync(fileStrem);
                    }
                    _context.Add(multipleImageUpload);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["propertyInfoId"] = new SelectList(_context.PropertyDetails, "PropertyInfoId", "Location", multipleImageUpload.propertyInfoId);
                return View(multipleImageUpload);
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: MultipleImageUploads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null || _context.MultipleImageUploads == null)
                {
                    return NotFound();
                }

                var multipleImageUpload = await _context.MultipleImageUploads.FindAsync(id);
                if (multipleImageUpload == null)
                {
                    return NotFound();
                }
                ViewData["propertyInfoId"] = new SelectList(_context.PropertyDetails, "PropertyInfoId", "Location", multipleImageUpload.propertyInfoId);
                return View(multipleImageUpload);
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }

        // POST: MultipleImageUploads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MultiImagePath,propertyInfoId")] MultipleImageUpload multipleImageUpload)
        {
            if (id != multipleImageUpload.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(multipleImageUpload);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MultipleImageUploadExists(multipleImageUpload.ID))
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
            ViewData["propertyInfoId"] = new SelectList(_context.PropertyDetails, "PropertyInfoId", "Location", multipleImageUpload.propertyInfoId);
            return View(multipleImageUpload);
        }

        // GET: MultipleImageUploads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null || _context.MultipleImageUploads == null)
                {
                    return NotFound();
                }

                var multipleImageUpload = await _context.MultipleImageUploads
                    .Include(m => m.PropertyDetails)
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (multipleImageUpload == null)
                {
                    return NotFound();
                }

                return View(multipleImageUpload);
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }

        // POST: MultipleImageUploads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                if (_context.MultipleImageUploads == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.MultipleImageUploads'  is null.");
                }
                var multipleImageUpload = await _context.MultipleImageUploads.FindAsync(id);
                if (multipleImageUpload != null)
                {
                    _context.MultipleImageUploads.Remove(multipleImageUpload);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }

        private bool MultipleImageUploadExists(int id)
        {
          return (_context.MultipleImageUploads?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
