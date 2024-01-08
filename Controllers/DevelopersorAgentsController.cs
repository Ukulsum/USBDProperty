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
    public class DevelopersorAgentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DevelopersorAgentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DevelopersorAgents
        public async Task<IActionResult> Index()
        {
              return _context.DevelopersorAgent != null ? 
                          View(await _context.DevelopersorAgent.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.DevelopersorAgent'  is null.");
        }

        // GET: DevelopersorAgents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DevelopersorAgent == null)
            {
                return NotFound();
            }

            var developersorAgent = await _context.DevelopersorAgent
                .FirstOrDefaultAsync(m => m.ID == id);
            if (developersorAgent == null)
            {
                return NotFound();
            }

            return View(developersorAgent);
        }

        // GET: DevelopersorAgents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DevelopersorAgents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Logo,Banner,CompanyName,ContactNo,Email,Name,PostedBy,CreatedDate,CreatedBy,UpdateDate,UpdateBy,IsActive")] DevelopersorAgent developersorAgent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(developersorAgent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(developersorAgent);
        }

        // GET: DevelopersorAgents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DevelopersorAgent == null)
            {
                return NotFound();
            }

            var developersorAgent = await _context.DevelopersorAgent.FindAsync(id);
            if (developersorAgent == null)
            {
                return NotFound();
            }
            return View(developersorAgent);
        }

        // POST: DevelopersorAgents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Logo,Banner,CompanyName,ContactNo,Email,Name,PostedBy,CreatedDate,CreatedBy,UpdateDate,UpdateBy,IsActive")] DevelopersorAgent developersorAgent)
        {
            if (id != developersorAgent.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(developersorAgent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DevelopersorAgentExists(developersorAgent.ID))
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
            return View(developersorAgent);
        }

        // GET: DevelopersorAgents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DevelopersorAgent == null)
            {
                return NotFound();
            }

            var developersorAgent = await _context.DevelopersorAgent
                .FirstOrDefaultAsync(m => m.ID == id);
            if (developersorAgent == null)
            {
                return NotFound();
            }

            return View(developersorAgent);
        }

        // POST: DevelopersorAgents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DevelopersorAgent == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DevelopersorAgent'  is null.");
            }
            var developersorAgent = await _context.DevelopersorAgent.FindAsync(id);
            if (developersorAgent != null)
            {
                _context.DevelopersorAgent.Remove(developersorAgent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DevelopersorAgentExists(int id)
        {
          return (_context.DevelopersorAgent?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
