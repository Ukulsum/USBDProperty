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
    public class PropertyDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PropertyDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PropertyDetails
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PropertyDetails.Include(p => p.Area).Include(p => p.PropertyOwnerInfo).Include(p => p.PropertyType).Include(p => p.SocialIcon).Include(p => p.TransactionType).Include(p => p.propertyFor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PropertyDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PropertyDetails == null)
            {
                return NotFound();
            }

            var propertyDetails = await _context.PropertyDetails
                .Include(p => p.Area)
                .Include(p => p.PropertyOwnerInfo)
                .Include(p => p.PropertyType)
                .Include(p => p.SocialIcon)
                .Include(p => p.TransactionType)
                .Include(p => p.propertyFor)
                .FirstOrDefaultAsync(m => m.PropertyInfoId == id);
            if (propertyDetails == null)
            {
                return NotFound();
            }

            return View(propertyDetails);
        }

        // GET: PropertyDetails/Create
        public IActionResult Create()
        {
            ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "AreaName");
            ViewData["OwnerId"] = new SelectList(_context.PropertyOwnerInfos, "OwnerID", "Banner");
            ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "PropertyTypeId", "PropertyTypeName");
            ViewData["IconId"] = new SelectList(_context.SocialIcons, "IconId", "Icon");
            ViewData["TransactionTypeId"] = new SelectList(_context.TransactionTypes, "TransactionTypeId", "TransactionTypeName");
            ViewData["PropertyForId"] = new SelectList(_context.PropertyFors, "PropertyForId", "PropeFor");
            return View();
        }

        // POST: PropertyDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PropertyInfoId,Title,Description,PropertyName,Location,ConstructionStatus,PropertySize,NumberOfBedrooms,NumberOfBaths,NumberOfBalconies,NumberOfGarages,TotalFloor,FloorAvailableNo,Furnishing,Facing,LandArea,Price,Measurement,Comments,HandOverDate,PropertyTypeId,TransactionTypeId,OwnerId,IconId,AreaId,PropertyForId,CreatedDate,CreatedBy,UpdateDate,UpdateBy,IsActive")] PropertyDetails propertyDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(propertyDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "AreaName", propertyDetails.AreaId);
            ViewData["OwnerId"] = new SelectList(_context.PropertyOwnerInfos, "OwnerID", "Banner", propertyDetails.OwnerId);
            ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "PropertyTypeId", "PropertyTypeName", propertyDetails.PropertyTypeId);
            ViewData["IconId"] = new SelectList(_context.SocialIcons, "IconId", "Icon", propertyDetails.IconId);
            ViewData["TransactionTypeId"] = new SelectList(_context.TransactionTypes, "TransactionTypeId", "TransactionTypeName", propertyDetails.TransactionTypeId);
            ViewData["PropertyForId"] = new SelectList(_context.PropertyFors, "PropertyForId", "PropeFor", propertyDetails.PropertyForId);
            return View(propertyDetails);
        }

        // GET: PropertyDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PropertyDetails == null)
            {
                return NotFound();
            }

            var propertyDetails = await _context.PropertyDetails.FindAsync(id);
            if (propertyDetails == null)
            {
                return NotFound();
            }
            ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "AreaName", propertyDetails.AreaId);
            ViewData["OwnerId"] = new SelectList(_context.PropertyOwnerInfos, "OwnerID", "Banner", propertyDetails.OwnerId);
            ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "PropertyTypeId", "PropertyTypeName", propertyDetails.PropertyTypeId);
            ViewData["IconId"] = new SelectList(_context.SocialIcons, "IconId", "Icon", propertyDetails.IconId);
            ViewData["TransactionTypeId"] = new SelectList(_context.TransactionTypes, "TransactionTypeId", "TransactionTypeName", propertyDetails.TransactionTypeId);
            ViewData["PropertyForId"] = new SelectList(_context.PropertyFors, "PropertyForId", "PropeFor", propertyDetails.PropertyForId);
            return View(propertyDetails);
        }

        // POST: PropertyDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PropertyInfoId,Title,Description,PropertyName,Location,ConstructionStatus,PropertySize,NumberOfBedrooms,NumberOfBaths,NumberOfBalconies,NumberOfGarages,TotalFloor,FloorAvailableNo,Furnishing,Facing,LandArea,Price,Measurement,Comments,HandOverDate,PropertyTypeId,TransactionTypeId,OwnerId,IconId,AreaId,PropertyForId,CreatedDate,CreatedBy,UpdateDate,UpdateBy,IsActive")] PropertyDetails propertyDetails)
        {
            if (id != propertyDetails.PropertyInfoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propertyDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyDetailsExists(propertyDetails.PropertyInfoId))
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
            ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "AreaName", propertyDetails.AreaId);
            ViewData["OwnerId"] = new SelectList(_context.PropertyOwnerInfos, "OwnerID", "Banner", propertyDetails.OwnerId);
            ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "PropertyTypeId", "PropertyTypeName", propertyDetails.PropertyTypeId);
            ViewData["IconId"] = new SelectList(_context.SocialIcons, "IconId", "Icon", propertyDetails.IconId);
            ViewData["TransactionTypeId"] = new SelectList(_context.TransactionTypes, "TransactionTypeId", "TransactionTypeName", propertyDetails.TransactionTypeId);
            ViewData["PropertyForId"] = new SelectList(_context.PropertyFors, "PropertyForId", "PropeFor", propertyDetails.PropertyForId);
            return View(propertyDetails);
        }

        // GET: PropertyDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PropertyDetails == null)
            {
                return NotFound();
            }

            var propertyDetails = await _context.PropertyDetails
                .Include(p => p.Area)
                .Include(p => p.PropertyOwnerInfo)
                .Include(p => p.PropertyType)
                .Include(p => p.SocialIcon)
                .Include(p => p.TransactionType)
                .Include(p => p.propertyFor)
                .FirstOrDefaultAsync(m => m.PropertyInfoId == id);
            if (propertyDetails == null)
            {
                return NotFound();
            }

            return View(propertyDetails);
        }

        // POST: PropertyDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PropertyDetails == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PropertyDetails'  is null.");
            }
            var propertyDetails = await _context.PropertyDetails.FindAsync(id);
            if (propertyDetails != null)
            {
                _context.PropertyDetails.Remove(propertyDetails);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyDetailsExists(int id)
        {
          return (_context.PropertyDetails?.Any(e => e.PropertyInfoId == id)).GetValueOrDefault();
        }
    }
}
