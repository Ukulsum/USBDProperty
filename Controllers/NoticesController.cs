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
    public class NoticesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public NoticesController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            environment = _environment;
        }

        // GET: Notices
        public async Task<IActionResult> Index()
        {
              return _context.Notices != null ? 
                          View(await _context.Notices.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Notices'  is null.");
        }

        // GET: Notices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Notices == null)
            {
                return NotFound();
            }

            var notice = await _context.Notices
                .FirstOrDefaultAsync(m => m.NoticeID == id);
            if (notice == null)
            {
                return NotFound();
            }

            return View(notice);
        }

        // GET: Notices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Notices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NoticeID,Title,Description,Images,StartDate,EndDate,CreatedDate,CreatedBy,UpdateDate,UpdateBy,IsActive")] Notice notice)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string UniqueFileName = UploadImage(notice);
                    //notice.Path = UniqueFileName(notice);
                    _context.Add(notice);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, "Model property is not valid please check");
            } 
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            
            return View(notice);
        }

        private string UploadImage(Notice notice)
        {
            string uniqueFileName = string.Empty;
            if (notice.Images != null)
            {
                string uploadFolder = Path.Combine(_environment.WebRootPath, "Content/Photo/");

                string fileName = Guid.NewGuid().ToString() + "_" + notice.Images.FileName;
                string filePath = Path.Combine(uploadFolder, fileName);
                string filetosave = "~/Content/Images/" + fileName;
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    notice.Images.CopyTo(fileStream);
                }
                return filetosave;
            }
            return "";
        }

        // GET: Notices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Notices == null)
            {
                return NotFound();
            }

            var notice = await _context.Notices.FindAsync(id);
            if (notice == null)
            {
                return NotFound();
            }
            return View(notice);
        }

        // POST: Notices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NoticeID,Title,Description,Images,StartDate,EndDate,CreatedDate,CreatedBy,UpdateDate,UpdateBy,IsActive")] Notice notice)
        {
            if (id != notice.NoticeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoticeExists(notice.NoticeID))
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
            return View(notice);
        }

        // GET: Notices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Notices == null)
            {
                return NotFound();
            }

            var notice = await _context.Notices
                .FirstOrDefaultAsync(m => m.NoticeID == id);
            if (notice == null)
            {
                return NotFound();
            }

            return View(notice);
        }

        // POST: Notices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Notices == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Notices'  is null.");
            }
            var notice = await _context.Notices.FindAsync(id);
            if (notice != null)
            {
                _context.Notices.Remove(notice);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoticeExists(int id)
        {
          return (_context.Notices?.Any(e => e.NoticeID == id)).GetValueOrDefault();
        }
    }
}
