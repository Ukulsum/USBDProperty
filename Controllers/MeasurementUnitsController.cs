using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using USBDProperty.Models;

namespace USBDProperty.Controllers
{
    [Authorize(Roles = "Admin,Agent")]
    public class MeasurementUnitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MeasurementUnitsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        public JsonResult GetMeasurmentUnit( )
        {
            try
            {
                var data = _context.MeasurementUnit.OrderBy(d => d.Name).ToList();
                return Json(new { Data = data });
            }
            catch(Exception ex)
            {
                return Json(new { Data = ex.Message });
            }
        }
        // GET: MeasurementUnits
        public async Task<IActionResult> Index()
        {
            try
            {
                return _context.MeasurementUnit != null ?
                          View(await _context.MeasurementUnit.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.MeasurementUnit'  is null.");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: MeasurementUnits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null || _context.MeasurementUnit == null)
                {
                    return NotFound();
                }

                var measurementUnit = await _context.MeasurementUnit
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (measurementUnit == null)
                {
                    return NotFound();
                }

                return View(measurementUnit);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: MeasurementUnits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MeasurementUnits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ShortName")] MeasurementUnit measurementUnit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(measurementUnit);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(measurementUnit);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: MeasurementUnits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null || _context.MeasurementUnit == null)
                {
                    return NotFound();
                }

                var measurementUnit = await _context.MeasurementUnit.FindAsync(id);
                if (measurementUnit == null)
                {
                    return NotFound();
                }
                return View(measurementUnit);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: MeasurementUnits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ShortName")] MeasurementUnit measurementUnit)
        {
            if (id != measurementUnit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(measurementUnit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeasurementUnitExists(measurementUnit.Id))
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
            return View(measurementUnit);
        }

        // GET: MeasurementUnits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null || _context.MeasurementUnit == null)
                {
                    return NotFound();
                }

                var measurementUnit = await _context.MeasurementUnit
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (measurementUnit == null)
                {
                    return NotFound();
                }

                return View(measurementUnit);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: MeasurementUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                if (_context.MeasurementUnit == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.MeasurementUnit'  is null.");
                }
                var measurementUnit = await _context.MeasurementUnit.FindAsync(id);
                if (measurementUnit != null)
                {
                    _context.MeasurementUnit.Remove(measurementUnit);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool MeasurementUnitExists(int id)
        {
          return (_context.MeasurementUnit?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
