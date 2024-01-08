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
    public class CitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CitiesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public JsonResult GetCities(int did)
        {
            var record = _context.Citys.OrderBy(c => c.CityName)
                                            .Where(d => d.DivisionId.Equals(did)).ToList();
            return Json(record);
        }
        // GET: Cities
        public async Task<IActionResult> Index()
        {
            try
            {
                var applicationDbContext = _context.Citys.OrderByDescending(c => c.CityId).Include(c => c.Division);
                return View(await applicationDbContext.ToListAsync());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: Cities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null || _context.Citys == null)
                {
                    return NotFound();
                }

                var city = await _context.Citys
                    .Include(c => c.Division)
                    .FirstOrDefaultAsync(m => m.CityId == id);
                if (city == null)
                {
                    return NotFound();
                }
                return View(city);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
           

        // GET: Cities/Create
        public IActionResult Create()
        {
            try
            {
                ViewData["DivisionId"] = new SelectList(_context.Divisions, "DivisionID", "DivisionName");
                return View();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: Cities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CityId,CityName,DivisionId")] City city)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(city);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["DivisionId"] = new SelectList(_context.Divisions, "DivisionID", "DivisionName", city.DivisionId);
                return View(city);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: Cities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null || _context.Citys == null)
                {
                    return NotFound();
                }

                var city = await _context.Citys.FindAsync(id);
                if (city == null)
                {
                    return NotFound();
                }
                ViewData["DivisionId"] = new SelectList(_context.Divisions, "DivisionID", "DivisionName", city.DivisionId);
                return View(city);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CityId,CityName,DivisionId")] City city)
        {
            if (id != city.CityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(city);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityExists(city.CityId))
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
            ViewData["DivisionId"] = new SelectList(_context.Divisions, "DivisionID", "DivisionName", city.DivisionId);
            return View(city);
        }

        // GET: Cities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null || _context.Citys == null)
                {
                    return NotFound();
                }

                var city = await _context.Citys
                    .Include(c => c.Division)
                    .FirstOrDefaultAsync(m => m.CityId == id);
                if (city == null)
                {
                    return NotFound();
                }

                return View(city);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                if (_context.Citys == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.Citys'  is null.");
                }
                var city = await _context.Citys.FindAsync(id);
                if (city != null)
                {
                    _context.Citys.Remove(city);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool CityExists(int id)
        {
          return (_context.Citys?.Any(e => e.CityId == id)).GetValueOrDefault();
        }
    }
}
