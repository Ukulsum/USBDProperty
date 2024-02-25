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
    public class AreasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AreasController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public JsonResult GetArea(int cid)
        {
            try
            {
                var record = _context.Areas.OrderBy(c => c.AreaName)
                                           .Where(d => d.CityId.Equals(cid)).ToList();
                return Json(record);
            }
            catch (Exception ex)
            {
                return Json(new { data = "No Record" });
            }
           
        }
        // GET: Areas
        public async Task<IActionResult> Index()
        {
            try
            {
                var applicationDbContext = _context.Areas.OrderByDescending(a => a.AreaId).Include(a => a.City);
                return View(await applicationDbContext.ToListAsync());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: Areas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null || _context.Areas == null)
                {
                    return NotFound();
                }

                var area = await _context.Areas
                    .Include(a => a.City)
                    .FirstOrDefaultAsync(m => m.AreaId == id);
                if (area == null)
                {
                    return NotFound();
                }

                return View(area);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: Areas/Create
        public IActionResult Create()
        {
            try
            {
                ViewData["CityId"] = new SelectList(_context.Citys, "CityId", "CityName");
                return View();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: Areas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AreaId,AreaName,CityId")] Area area)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(area);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["CityId"] = new SelectList(_context.Citys, "CityId", "CityName", area.CityId);
                return View(area);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: Areas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null || _context.Areas == null)
                {
                    return NotFound();
                }

                var area = await _context.Areas.FindAsync(id);
                if (area == null)
                {
                    return NotFound();
                }
                ViewData["CityId"] = new SelectList(_context.Citys, "CityId", "CityName", area.CityId);
                return View(area);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: Areas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AreaId,AreaName,CityId")] Area area)
        {
            if (id != area.AreaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(area);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AreaExists(area.AreaId))
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
            ViewData["CityId"] = new SelectList(_context.Citys, "CityId", "CityName", area.CityId);
            return View(area);
        }

        // GET: Areas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null || _context.Areas == null)
                {
                    return NotFound();
                }

                var area = await _context.Areas
                    .Include(a => a.City)
                    .FirstOrDefaultAsync(m => m.AreaId == id);
                if (area == null)
                {
                    return NotFound();
                }

                return View(area);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: Areas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                if (_context.Areas == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.Areas'  is null.");
                }
                var area = await _context.Areas.FindAsync(id);
                if (area != null)
                {
                    _context.Areas.Remove(area);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool AreaExists(int id)
        {
          return (_context.Areas?.Any(e => e.AreaId == id)).GetValueOrDefault();
        }
    }
}
