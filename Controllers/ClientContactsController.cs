using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using USBDProperty.Models;
using USBDProperty.ViewModels;

namespace USBDProperty.Controllers
{
    [Authorize(Roles = "Admin,Agent")]
    public class ClientContactsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INotyfService _notyf;

        public ClientContactsController(ApplicationDbContext context, INotyfService srv)
        {
            _context = context;
            _notyf = srv;
        }

        // GET: ClientContacts
        public async Task<IActionResult> Index(int id)
        {
            try
            {
                var applicationDbContext = _context.ClientContacts.Where(c => ((int)c.Interested).Equals(id));
                return View(await applicationDbContext.ToListAsync());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: ClientContacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null || _context.ClientContacts == null)
                {
                    return NotFound();
                }

                var clientContact = await _context.ClientContacts
                    //.Include(c => c.PropertyType)
                    .FirstOrDefaultAsync(m => m.ClientContactId == id);
                if (clientContact == null)
                {
                    return NotFound();
                }

                return View(clientContact);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: ClientContacts/Create
        //public IActionResult Create(Interested interested)
        public IActionResult Create()
        {

            ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "PropertyTypeId", "PropertyTypeName");
            return View();
        }
        public async Task<JsonResult> SaveContact([FromBody] ClientVM clientContact)
        {
            //try
            //{
                var client = new ClientContact { ClientName = clientContact.ClientName, ContactNo = clientContact.ContactNo, Email = clientContact.Email, Message = clientContact.Message, ContactDate = DateTime.Now, Interested = clientContact.Interested };
                _context.ClientContacts.Add(client);
                if (await _context.SaveChangesAsync() > 0)
                {
                    _notyf.Success("As soon as possible we will contact with u");
                    return Json(new { data = clientContact, Issuccess = true }); ;
                }
                return Json(new { data = clientContact, Issuccess = true });
            //}
            //catch(Exception ex)
            //{
            //    return Json(new { error = ex.Message });
            //}
        }

        // POST: ClientContacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClientVM clientContact)
        {
            try
            {
                int Id = 0;
                int r = 0;
                if (ModelState.IsValid)
                {
                    if (clientContact.PropertyID > 0)
                    {
                        var client = new ClientContact
                        {
                            ClientName = clientContact.ClientName,
                            ContactNo = clientContact.ContactNo,
                            Email = clientContact.Email,
                            Message = clientContact.Message,
                            ContactDate = DateTime.Now,
                            Interested = Interested.Buy
                        };
                        _context.ClientContacts.Add(client);
                        await _context.SaveChangesAsync();

                        _context.ClientInterest.Add(new ClientInterest { ClientID = client.ClientContactId, Message = clientContact.Message, PropertyID = clientContact.PropertyID, PropertyTypeId = clientContact.PropertyTypeId, PropertyForId = clientContact.PropertyForId, });

                        Id = clientContact.PropertyID;

                        r = await _context.SaveChangesAsync();
                        if (r > 0)
                        {


                            _notyf.Success("As soon as possible we will contact with u");

                            return RedirectToAction("HomePropertyDetails", "PropertyDetails", new { Id });
                        }
                    }

                    else
                    {
                        var client = new ClientContact { ClientName = clientContact.ClientName, ContactNo = clientContact.ContactNo, Email = clientContact.Email, Message = clientContact.Message, ContactDate = DateTime.Now, Interested = Interested.Sale };
                        _context.ClientContacts.Add(client);
                        r = await _context.SaveChangesAsync();

                        if (r > 0)
                        {


                            _notyf.Success("As soon as possible we will contact with u");

                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
                ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "PropertyTypeId", "PropertyTypeName");
                return RedirectToAction("HomePropertyDetails", "PropertyDetails", new { Id });
            }

            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            //return RedirectToAction("HomePropertyDetails", "PropertyDetails", new { Id });
            return View();
        }

        public JsonResult Save([FromBody] ClientContact client)
        {
            try
            {
                int r = 0;

                if (client != null || client.ClientName != null)
                {
                    var clientData = new ClientContact { ClientName = client.ClientName, ContactNo = client.ContactNo, Email = client.Email, Message = client.Message, ContactDate = DateTime.Now, Interested = client.Interested };
                    _context.ClientContacts.Add(clientData);
                    r = _context.SaveChanges();

                    if (r > 0)
                    {
                        _notyf.Success("As soon as possible we will contact with u");
                        return Json(new { Data = clientData, issuccess = true });
                    }
                }
                return Json(new { Data = client, issuccess = false });
            }
            catch(Exception ex)
            {
                return Json(new { data = "No Record" });
            }

        }
 
        public async Task<IActionResult> Edit(int? id)
        {
            try
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
                ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "PropertyTypeId", "PropertyTypeName");
                return View(clientContact);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: ClientContacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientContactId,ClientName,ContactNo,Email,PropertyForId,PropertyTypeId,ContactDate,Message")] ClientContact clientContact)
        {
            try
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
                ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "PropertyTypeId", "PropertyTypeName");
                return View(clientContact);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: ClientContacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null || _context.ClientContacts == null)
                {
                    return NotFound();
                }

                var clientContact = await _context.ClientContacts
                    .FirstOrDefaultAsync(m => m.ClientContactId == id);
                if (clientContact == null)
                {
                    return NotFound();
                }

                return View(clientContact);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: ClientContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
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
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool ClientContactExists(int id)
        {
           return (_context.ClientContacts?.Any(e => e.ClientContactId == id)).GetValueOrDefault();
        }
    }
}
