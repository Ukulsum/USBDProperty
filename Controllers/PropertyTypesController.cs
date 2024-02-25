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
    public class PropertyTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PropertyTypesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        public JsonResult GetChildType(int? pid=0)
        {
            try
            {
                if (pid.Value  != null || pid.Value>0)
                {
                    var result = _context.PropertyTypes.OrderBy(p => p.PropertyTypeName).Where(p => p.ParentPropertyTypeId.Equals(pid));
                    return Json(result);
                }
                else
                {
                    var result = _context.PropertyTypes.OrderBy(p => p.PropertyTypeName).Where(p => p.ParentPropertyTypeId.Equals(0));
                    return Json(result);
                }
            }
            catch (Exception ex)
            {
                return Json(new { isSuccess = false,Message=ex.Message });
            }
            return Json(new { isSuccess = false, Message = "Failed to retrieve" });
        }
        // GET: PropertyTypes
        public async Task<IActionResult> Index()
        {
            try
            {
                return _context.PropertyTypes != null ?
                       View(await _context.PropertyTypes.OrderByDescending(p => p.PropertyTypeId).ToListAsync()) :
                       Problem("Entity set 'ApplicationDbContext.PropertyTypes'  is null.");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: PropertyTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null || _context.PropertyTypes == null)
                {
                    return NotFound();
                }

                var propertyType = await _context.PropertyTypes
                    .FirstOrDefaultAsync(m => m.PropertyTypeId == id);
                if (propertyType == null)
                {
                    return NotFound();
                }

                return View(propertyType);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: PropertyTypes/Create
        public IActionResult Create()
        {
            var ptype = _context.PropertyTypes.OrderBy(a => a.PropertyTypeName).ToList();
            ViewBag.PropertyTypes = new SelectList(ptype??new List<PropertyType>(), "PropertyTypeId", "PropertyTypeName");
            return View();
        }

        // POST: PropertyTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PropertyTypeId,PropertyTypeName,ParentPropertyTypeId")] PropertyType propertyType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(propertyType);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(propertyType);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: PropertyTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null || _context.PropertyTypes == null)
                {
                    return NotFound();
                }

                var propertyType = await _context.PropertyTypes.FindAsync(id);
                if (propertyType == null)
                {
                    return NotFound();
                }

                return View(propertyType);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: PropertyTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PropertyTypeId,PropertyTypeName,ParentPropertyTypeId")] PropertyType propertyType)
        {
            if (id != propertyType.PropertyTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propertyType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyTypeExists(propertyType.PropertyTypeId))
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
            return View(propertyType);
        }

        // GET: PropertyTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null || _context.PropertyTypes == null)
                {
                    return NotFound();
                }

                var propertyType = await _context.PropertyTypes
                    .FirstOrDefaultAsync(m => m.PropertyTypeId == id);
                if (propertyType == null)
                {
                    return NotFound();
                }

                return View(propertyType);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: PropertyTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                if (_context.PropertyTypes == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.PropertyTypes'  is null.");
                }
                var propertyType = await _context.PropertyTypes.FindAsync(id);
                if (propertyType != null)
                {
                    _context.PropertyTypes.Remove(propertyType);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool PropertyTypeExists(int id)
        {
          return (_context.PropertyTypes?.Any(e => e.PropertyTypeId == id)).GetValueOrDefault();
        }
    }
}
