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
    public class PropertyOwnerInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PropertyOwnerInfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PropertyOwnerInfoes
        public async Task<IActionResult> Index()
        {
              return _context.PropertyOwnerInfos != null ? 
                          View(await _context.PropertyOwnerInfos.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.PropertyOwnerInfos'  is null.");
        }

        // GET: PropertyOwnerInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PropertyOwnerInfos == null)
            {
                return NotFound();
            }

            var propertyOwnerInfo = await _context.PropertyOwnerInfos
                .FirstOrDefaultAsync(m => m.OwnerID == id);
            if (propertyOwnerInfo == null)
            {
                return NotFound();
            }

            return View(propertyOwnerInfo);
        }

        // GET: PropertyOwnerInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PropertyOwnerInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OwnerID,Logo,Banner,CompanyName,ContactNo,Email,Name,PostedBy,CreatedDate,CreatedBy,UpdateDate,UpdateBy,IsActive")] PropertyOwnerInfo propertyOwnerInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(propertyOwnerInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(propertyOwnerInfo);
        }

        // GET: PropertyOwnerInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PropertyOwnerInfos == null)
            {
                return NotFound();
            }

            var propertyOwnerInfo = await _context.PropertyOwnerInfos.FindAsync(id);
            if (propertyOwnerInfo == null)
            {
                return NotFound();
            }
            return View(propertyOwnerInfo);
        }

        // POST: PropertyOwnerInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OwnerID,Logo,Banner,CompanyName,ContactNo,Email,Name,PostedBy,CreatedDate,CreatedBy,UpdateDate,UpdateBy,IsActive")] PropertyOwnerInfo propertyOwnerInfo)
        {
            if (id != propertyOwnerInfo.OwnerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propertyOwnerInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyOwnerInfoExists(propertyOwnerInfo.OwnerID))
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
            return View(propertyOwnerInfo);
        }

        // GET: PropertyOwnerInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PropertyOwnerInfos == null)
            {
                return NotFound();
            }

            var propertyOwnerInfo = await _context.PropertyOwnerInfos
                .FirstOrDefaultAsync(m => m.OwnerID == id);
            if (propertyOwnerInfo == null)
            {
                return NotFound();
            }

            return View(propertyOwnerInfo);
        }

        // POST: PropertyOwnerInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PropertyOwnerInfos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PropertyOwnerInfos'  is null.");
            }
            var propertyOwnerInfo = await _context.PropertyOwnerInfos.FindAsync(id);
            if (propertyOwnerInfo != null)
            {
                _context.PropertyOwnerInfos.Remove(propertyOwnerInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyOwnerInfoExists(int id)
        {
          return (_context.PropertyOwnerInfos?.Any(e => e.OwnerID == id)).GetValueOrDefault();
        }
    }
}
