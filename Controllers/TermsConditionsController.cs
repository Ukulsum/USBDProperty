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
    public class TermsConditionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TermsConditionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TermsConditions
        public async Task<IActionResult> Index()
        {
            try
            {
                return _context.TermsConditions != null ?
                         View(await _context.TermsConditions.ToListAsync()) :
                         Problem("Entity set 'ApplicationDbContext.TermsConditions'  is null.");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: TermsConditions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null || _context.TermsConditions == null)
                {
                    return NotFound();
                }

                var termsCondition = await _context.TermsConditions
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (termsCondition == null)
                {
                    return NotFound();
                }

                return View(termsCondition);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: TermsConditions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TermsConditions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Description")] TermsCondition termsCondition)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(termsCondition);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(termsCondition);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: TermsConditions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null || _context.TermsConditions == null)
                {
                    return NotFound();
                }

                var termsCondition = await _context.TermsConditions.FindAsync(id);
                if (termsCondition == null)
                {
                    return NotFound();
                }
                return View(termsCondition);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: TermsConditions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Description")] TermsCondition termsCondition)
        {
            if (id != termsCondition.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(termsCondition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TermsConditionExists(termsCondition.ID))
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
            return View(termsCondition);
        }

        // GET: TermsConditions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null || _context.TermsConditions == null)
                {
                    return NotFound();
                }

                var termsCondition = await _context.TermsConditions
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (termsCondition == null)
                {
                    return NotFound();
                }

                return View(termsCondition);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: TermsConditions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                if (_context.TermsConditions == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.TermsConditions'  is null.");
                }
                var termsCondition = await _context.TermsConditions.FindAsync(id);
                if (termsCondition != null)
                {
                    _context.TermsConditions.Remove(termsCondition);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool TermsConditionExists(int id)
        {
          return (_context.TermsConditions?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
