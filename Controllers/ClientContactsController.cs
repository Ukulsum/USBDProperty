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
    public class ClientContactsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientContactsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClientContacts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ClientContacts.Include(c => c.PropertyType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ClientContacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ClientContacts == null)
            {
                return NotFound();
            }

            var clientContact = await _context.ClientContacts
                .Include(c => c.PropertyType)
                .FirstOrDefaultAsync(m => m.ClientContactId == id);
            if (clientContact == null)
            {
                return NotFound();
            }

            return View(clientContact);
        }

        // GET: ClientContacts/Create
        public IActionResult Create()
        {
            ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "PropertyTypeId", "PropertyTypeName");
            return View();
        }

        // POST: ClientContacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientContactId,ClientName,ContactNo,Email,PropertyForId,PropertyTypeId,ContactDate,Message")] ClientContact clientContact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "PropertyTypeId", "PropertyTypeName", clientContact.PropertyTypeId);
            return View(clientContact);
        }

        // GET: ClientContacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ClientContacts == null)
            {
                return NotFound();
            }

            var clientContact = await _context.ClientContacts.FindAsync(id);
            if (clientContact == null)
            {
                return NotFound();
            }
            ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "PropertyTypeId", "PropertyTypeName", clientContact.PropertyTypeId);
            return View(clientContact);
        }

        // POST: ClientContacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientContactId,ClientName,ContactNo,Email,PropertyForId,PropertyTypeId,ContactDate,Message")] ClientContact clientContact)
        {
            if (id != clientContact.ClientContactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientContactExists(clientContact.ClientContactId))
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
            ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "PropertyTypeId", "PropertyTypeName", clientContact.PropertyTypeId);
            return View(clientContact);
        }

        // GET: ClientContacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ClientContacts == null)
            {
                return NotFound();
            }

            var clientContact = await _context.ClientContacts
                .Include(c => c.PropertyType)
                .FirstOrDefaultAsync(m => m.ClientContactId == id);
            if (clientContact == null)
            {
                return NotFound();
            }

            return View(clientContact);
        }

        // POST: ClientContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ClientContacts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ClientContacts'  is null.");
            }
            var clientContact = await _context.ClientContacts.FindAsync(id);
            if (clientContact != null)
            {
                _context.ClientContacts.Remove(clientContact);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientContactExists(int id)
        {
          return (_context.ClientContacts?.Any(e => e.ClientContactId == id)).GetValueOrDefault();
        }
    }
}
