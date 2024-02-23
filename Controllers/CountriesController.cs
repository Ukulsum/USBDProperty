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
    public class CountriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CountriesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public JsonResult GetCountry()
        {
            var record = _context.Countries.OrderBy(c => c.CountryName).ToList();
            return Json(record);
        }
        // GET: Countries
        public async Task<IActionResult> Index()
        {
            try
            {
                return _context.Countries != null ?
                         View(await _context.Countries.OrderByDescending(c => c.CountryID).ToListAsync()) :
                         Problem("Entity set 'ApplicationDbContext.Countries'  is null.");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
             
        }

        // GET: Countries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null || _context.Countries == null)
                {
                    return NotFound();
                }

                var country = await _context.Countries
                    .FirstOrDefaultAsync(m => m.CountryID == id);
                if (country == null)
                {
                    return NotFound();
                }

                return View(country);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);        
            }
        }

        // GET: Countries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Countries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CountryID,CountryName")] Country country)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(country);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(country);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: Countries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null || _context.Countries == null)
                {
                    return NotFound();
                }

                var country = await _context.Countries.FindAsync(id);
                if (country == null)
                {
                    return NotFound();
                }
                return View(country);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: Countries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CountryID,CountryName")] Country country)
        {
            if (id != country.CountryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(country);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryExists(country.CountryID))
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
            return View(country);
        }

        // GET: Countries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null || _context.Countries == null)
                {
                    return NotFound();
                }

                var country = await _context.Countries
                    .FirstOrDefaultAsync(m => m.CountryID == id);
                if (country == null)
                {
                    return NotFound();
                }

                return View(country);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                if (_context.Countries == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.Countries'  is null.");
                }
                var country = await _context.Countries.FindAsync(id);
                if (country != null)
                {
                    _context.Countries.Remove(country);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool CountryExists(int id)
        {
          return (_context.Countries?.Any(e => e.CountryID == id)).GetValueOrDefault();
        }
    }
}
