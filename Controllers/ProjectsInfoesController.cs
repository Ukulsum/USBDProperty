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
    [Authorize(Roles ="Admin,Agent")]
    public class ProjectsInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectsInfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProjectsInfoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProjectsInfo.Include(p => p.Developers);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProjectsInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProjectsInfo == null)
            {
                return NotFound();
            }

            var projectsInfo = await _context.ProjectsInfo
                .Include(p => p.Developers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectsInfo == null)
            {
                return NotFound();
            }

            return View(projectsInfo);
        }

        // GET: ProjectsInfoes/Create
        public IActionResult Create()
        {
            ViewData["AgentID"] = new SelectList(_context.DevelopersorAgent, "ID", "Banner");
            return View();
        }

        // POST: ProjectsInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,ProjectName,Location,LocationMap,AgentID")] ProjectsInfo projectsInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectsInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgentID"] = new SelectList(_context.DevelopersorAgent, "ID", "Banner", projectsInfo.AgentID);
            return View(projectsInfo);
        }

        // GET: ProjectsInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProjectsInfo == null)
            {
                return NotFound();
            }

            var projectsInfo = await _context.ProjectsInfo.FindAsync(id);
            if (projectsInfo == null)
            {
                return NotFound();
            }
            ViewData["AgentID"] = new SelectList(_context.DevelopersorAgent, "ID", "Banner", projectsInfo.AgentID);
            return View(projectsInfo);
        }

        // POST: ProjectsInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,ProjectName,Location,LocationMap,AgentID")] ProjectsInfo projectsInfo)
        {
            if (id != projectsInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectsInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectsInfoExists(projectsInfo.Id))
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
            ViewData["AgentID"] = new SelectList(_context.DevelopersorAgent, "ID", "Banner", projectsInfo.AgentID);
            return View(projectsInfo);
        }

        // GET: ProjectsInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProjectsInfo == null)
            {
                return NotFound();
            }

            var projectsInfo = await _context.ProjectsInfo
                .Include(p => p.Developers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectsInfo == null)
            {
                return NotFound();
            }

            return View(projectsInfo);
        }

        // POST: ProjectsInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProjectsInfo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProjectsInfo'  is null.");
            }
            var projectsInfo = await _context.ProjectsInfo.FindAsync(id);
            if (projectsInfo != null)
            {
                _context.ProjectsInfo.Remove(projectsInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectsInfoExists(int id)
        {
          return (_context.ProjectsInfo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
