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
    public class PrivacyPoliciesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrivacyPoliciesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PrivacyPolicies
        public async Task<IActionResult> Index()
        {
            try
            {
                return _context.PrivacyPolicy != null ?
                          View(await _context.PrivacyPolicy.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.PrivacyPolicy'  is null.");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: PrivacyPolicies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null || _context.PrivacyPolicy == null)
                {
                    return NotFound();
                }

                var privacyPolicy = await _context.PrivacyPolicy
                    .FirstOrDefaultAsync(m => m.PpId == id);
                if (privacyPolicy == null)
                {
                    return NotFound();
                }

                return View(privacyPolicy);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: PrivacyPolicies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PrivacyPolicies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PpId,Title,Description")] PrivacyPolicy privacyPolicy)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(privacyPolicy);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(privacyPolicy);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: PrivacyPolicies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null || _context.PrivacyPolicy == null)
                {
                    return NotFound();
                }

                var privacyPolicy = await _context.PrivacyPolicy.FindAsync(id);
                if (privacyPolicy == null)
                {
                    return NotFound();
                }
                return View(privacyPolicy);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: PrivacyPolicies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PpId,Title,Description")] PrivacyPolicy privacyPolicy)
        {
            if (id != privacyPolicy.PpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(privacyPolicy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrivacyPolicyExists(privacyPolicy.PpId))
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
            return View(privacyPolicy);
        }

        // GET: PrivacyPolicies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null || _context.PrivacyPolicy == null)
                {
                    return NotFound();
                }

                var privacyPolicy = await _context.PrivacyPolicy
                    .FirstOrDefaultAsync(m => m.PpId == id);
                if (privacyPolicy == null)
                {
                    return NotFound();
                }

                return View(privacyPolicy);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: PrivacyPolicies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                if (_context.PrivacyPolicy == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.PrivacyPolicy'  is null.");
                }
                var privacyPolicy = await _context.PrivacyPolicy.FindAsync(id);
                if (privacyPolicy != null)
                {
                    _context.PrivacyPolicy.Remove(privacyPolicy);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool PrivacyPolicyExists(int id)
        {
          return (_context.PrivacyPolicy?.Any(e => e.PpId == id)).GetValueOrDefault();
        }
    }
}
