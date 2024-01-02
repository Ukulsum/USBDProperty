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
    public class PropertyForsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PropertyForsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PropertyFors
        public async Task<IActionResult> Index()
        {
            try
            {
                return _context.PropertyFors != null ?
                          View(await _context.PropertyFors.OrderByDescending(p => p.PropertyForId).ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.PropertyFors'  is null.");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: PropertyFors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null || _context.PropertyFors == null)
                {
                    return NotFound();
                }

                var propertyFor = await _context.PropertyFors
                    .FirstOrDefaultAsync(m => m.PropertyForId == id);
                if (propertyFor == null)
                {
                    return NotFound();
                }

                return View(propertyFor);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: PropertyFors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PropertyFors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PropertyForId,PropeFor")] PropertyFor propertyFor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(propertyFor);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(propertyFor);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: PropertyFors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null || _context.PropertyFors == null)
                {
                    return NotFound();
                }

                var propertyFor = await _context.PropertyFors.FindAsync(id);
                if (propertyFor == null)
                {
                    return NotFound();
                }
                return View(propertyFor);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: PropertyFors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PropertyForId,PropeFor")] PropertyFor propertyFor)
        {
            if (id != propertyFor.PropertyForId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propertyFor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyForExists(propertyFor.PropertyForId))
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
            return View(propertyFor);
        }

        // GET: PropertyFors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null || _context.PropertyFors == null)
                {
                    return NotFound();
                }

                var propertyFor = await _context.PropertyFors
                    .FirstOrDefaultAsync(m => m.PropertyForId == id);
                if (propertyFor == null)
                {
                    return NotFound();
                }

                return View(propertyFor);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: PropertyFors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                if (_context.PropertyFors == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.PropertyFors'  is null.");
                }
                var propertyFor = await _context.PropertyFors.FindAsync(id);
                if (propertyFor != null)
                {
                    _context.PropertyFors.Remove(propertyFor);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool PropertyForExists(int id)
        {
          return (_context.PropertyFors?.Any(e => e.PropertyForId == id)).GetValueOrDefault();
        }
    }
}
