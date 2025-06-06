﻿using System;
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
    public class DivisionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DivisionsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        public JsonResult GetDivision(int cid)
        {
            try
            {
                var record = _context.Divisions.OrderBy(c => c.DivisionName)
                                           .Where(d => d.CountryId.Equals(cid)).ToList();
                return Json(record);
            }
            catch(Exception ex)
            {
                return Json(new { data = "No Record" });
            }
        }
        // GET: Divisions
        public async Task<IActionResult> Index()
        {
            try
            {
                var applicationDbContext = _context.Divisions.OrderByDescending(d => d.DivisionID).Include(d => d.Country);
                return View(await applicationDbContext.ToListAsync());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: Divisions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null || _context.Divisions == null)
                {
                    return NotFound();
                }

                var division = await _context.Divisions
                    .Include(d => d.Country)
                    .FirstOrDefaultAsync(m => m.DivisionID == id);
                if (division == null)
                {
                    return NotFound();
                }

                return View(division);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: Divisions/Create
        public IActionResult Create()
        {
            try
            {
                ViewData["CountryId"] = new SelectList(_context.Countries, "CountryID", "CountryName");
                return View();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: Divisions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        //[Bind("DivisionID,DivisionName,CountryId")] 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Division division)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(division);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
              
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryID", "CountryName", division.CountryId);
            return View(division);
        }

        // GET: Divisions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null || _context.Divisions == null)
                {
                    return NotFound();
                }

                var division = await _context.Divisions.FindAsync(id);
                if (division == null)
                {
                    return NotFound();
                }
                ViewData["CountryId"] = new SelectList(_context.Countries, "CountryID", "CountryName", division.CountryId);
                return View(division);
            }
             
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        // POST: Divisions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DivisionID,DivisionName,CountryId")] Division division)
        {
            if (id != division.DivisionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(division);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DivisionExists(division.DivisionID))
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
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryID", "CountryName", division.CountryId);
            return View(division);
        }

        // GET: Divisions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null || _context.Divisions == null)
                {
                    return NotFound();
                }

                var division = await _context.Divisions
                    .Include(d => d.Country)
                    .FirstOrDefaultAsync(m => m.DivisionID == id);
                if (division == null)
                {
                    return NotFound();
                }

                return View(division);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: Divisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                if (_context.Divisions == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.Divisions'  is null.");
                }
                var division = await _context.Divisions.FindAsync(id);
                if (division != null)
                {
                    _context.Divisions.Remove(division);
                }

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DivisionExists(int id)
        {
          return (_context.Divisions?.Any(e => e.DivisionID == id)).GetValueOrDefault();
        }
    }
}
