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
    public class PropertyFeaturesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PropertyFeaturesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PropertyFeatures
        public async Task<IActionResult> Index()
        {
            try
            {
                return _context.PropertyFeatures != null ?
                          View(await _context.PropertyFeatures.OrderByDescending(pf => pf.PropertyFeatureId).ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.PropertyFeatures'  is null.");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //GET
        public async Task<IActionResult> AllFeatureProperty(int id)
        {
            try
            {
                var data = await _context.PropertyFeatures.ToListAsync();


                ViewData["propertyInfoId"] = new SelectList(_context.PropertyDetails.Where(p => p.PropertyInfoId.Equals(id)), "PropertyInfoId", "Title");
                return View(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //public async Task<IActionResult> AllFeatureProperty()
        //{
        //    try
        //    {
        //        var data = await _context.PropertyFeatures
        //                                .Select(p => new CheckBoxItem { }).ToListAsync();
        //        return View(data);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        // GET: PropertyFeatures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null || _context.PropertyFeatures == null)
                {
                    return NotFound();
                }

                var propertyFeatures = await _context.PropertyFeatures
                    .FirstOrDefaultAsync(m => m.PropertyFeatureId == id);
                if (propertyFeatures == null)
                {
                    return NotFound();
                }

                return View(propertyFeatures);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: PropertyFeatures/Create
        public IActionResult Create(int?id)
        {
            TempData["Pid"]=id;

            return View();
        }

        // POST: PropertyFeatures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PropertyFeatureId,PropertyFeatureName,FeatureDescription")] PropertyFeatures propertyFeatures)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(propertyFeatures);
                    if(await _context.SaveChangesAsync()>0)
                    {
                    if (TempData["Pid"]!=null) 
                    {
                        return RedirectToAction("CreatePropertyFeatures","PropertyDetails", new {id= TempData["Pid"] });
                    }
                    else
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    }
                }
                return View(propertyFeatures);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: PropertyFeatures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try {
                if (id == null || _context.PropertyFeatures == null)
                {
                    return NotFound();
                }

                var propertyFeatures = await _context.PropertyFeatures.FindAsync(id);
                if (propertyFeatures == null)
                {
                    return NotFound();
                }
                return View(propertyFeatures);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: PropertyFeatures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PropertyFeatureId,PropertyFeatureName,FeatureDescription")] PropertyFeatures propertyFeatures)
        {
            if (id != propertyFeatures.PropertyFeatureId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propertyFeatures);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyFeaturesExists(propertyFeatures.PropertyFeatureId))
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
            return View(propertyFeatures);
        }

        // GET: PropertyFeatures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null || _context.PropertyFeatures == null)
                {
                    return NotFound();
                }

                var propertyFeatures = await _context.PropertyFeatures
                    .FirstOrDefaultAsync(m => m.PropertyFeatureId == id);
                if (propertyFeatures == null)
                {
                    return NotFound();
                }

                return View(propertyFeatures);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: PropertyFeatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                if (_context.PropertyFeatures == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.PropertyFeatures'  is null.");
                }
                var propertyFeatures = await _context.PropertyFeatures.FindAsync(id);
                if (propertyFeatures != null)
                {
                    _context.PropertyFeatures.Remove(propertyFeatures);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool PropertyFeaturesExists(int id)
        {
          return (_context.PropertyFeatures?.Any(e => e.PropertyFeatureId == id)).GetValueOrDefault();
        }
    }
}
