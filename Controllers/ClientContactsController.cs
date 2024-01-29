using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using USBDProperty.Models;
using USBDProperty.ViewModels;

namespace USBDProperty.Controllers
{
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
        public async Task<IActionResult> Index()
        {
            //var applicationDbContext = _context.ClientContacts.Include(c => c.PropertyType);
            var applicationDbContext = _context.ClientContacts;
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
                //.Include(c => c.PropertyType)
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
        public async Task<IActionResult> Create(
             ClientVM clientContact)
        {
            int Id = 0;
            int r = 0;
            if (ModelState.IsValid)
            {
                if(clientContact.PropertyID > 0)
                {
                    var client = new ClientContact { ClientName = clientContact.ClientName, ContactNo = clientContact.ContactNo, Email = clientContact.Email, Message = clientContact.Message, ContactDate = DateTime.Now };
                    _context.ClientContacts.Add(client);
                    await _context.SaveChangesAsync();

                    _context.ClientInterest.Add(new ClientInterest { ClientID = client.ClientContactId, Message = clientContact.Message, PropertyID = clientContact.PropertyID, PropertyTypeId = clientContact.PropertyTypeId, PropertyForId = clientContact.PropertyForId });

                    Id = clientContact.PropertyID;

                    r = await _context.SaveChangesAsync();
                    if (r > 0)
                    {


                        _notyf.Success("As soon as possible we will contact with u");
                        // return RedirectToAction("/PropertyDetails/HomePropertyDetails/"+clientContact.PropertyID);

                        return RedirectToAction("HomePropertyDetails", "PropertyDetails", new { Id });
                    }
                }

                else
                {
                    var client = new ClientContact { ClientName = clientContact.ClientName, ContactNo = clientContact.ContactNo, Email = clientContact.Email, Message = clientContact.Message, ContactDate = DateTime.Now };
                    _context.ClientContacts.Add(client);
                    r = await _context.SaveChangesAsync();

                    if (r > 0)
                    {


                        _notyf.Success("As soon as possible we will contact with u");
                        // return RedirectToAction("/PropertyDetails/HomePropertyDetails/"+clientContact.PropertyID);

                        return RedirectToAction("Index", "Home");
                    }
                }


                //var client = new ClientContact { ClientName = clientContact.ClientName, ContactNo = clientContact.ContactNo, Email = clientContact.Email, ContactDate = DateTime.Now };
                //_context.ClientContacts.Add(client);
                //await _context.SaveChangesAsync();

                //if (clientContact.PropertyID > 0)
                //{
                //_context.ClientInterest.Add(new ClientInterest { ClientID = client.ClientContactId, Message = clientContact.Message, PropertyID = clientContact.PropertyID, PropertyTypeId = clientContact.PropertyTypeId, PropertyForId = clientContact.PropertyForId });

                //Id = clientContact.PropertyID;
                //}
                //else
                //{
                //    _context.ClientContacts.Add(client);
                //    await _context.SaveChangesAsync();
                //}

                //_context.ClientInterest.Add(new ClientInterest { ClientID = client.ClientContactId, Message = clientContact.Message, PropertyID = clientContact.PropertyID, PropertyTypeId = clientContact.PropertyTypeId, PropertyForId = clientContact.PropertyForId });

                //Id = clientContact.PropertyID;


                //_context.Add(clientContact);
                //r = await _context.SaveChangesAsync();
                //if (r > 0)
                //{


                //    _notyf.Success("As soon as possible we will contact with u");
                //    // return RedirectToAction("/PropertyDetails/HomePropertyDetails/"+clientContact.PropertyID);

                //    return RedirectToAction("HomePropertyDetails", "PropertyDetails", new { Id });
                //}

                //  return RedirectToAction(nameof(Index));
            }
            //ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "PropertyTypeId", "PropertyTypeName", 
            //    clientContact.PropertyTypeId);
            ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "PropertyTypeId", "PropertyTypeName");
            // return View(clientContact);
            return RedirectToAction("HomePropertyDetails", "PropertyDetails", new { Id });
        }

        public JsonResult Save([FromBody] ClientContact client)
        {
            int r = 0;

           if(client != null ||   client.ClientName!=null ) { 
            var clientData = new ClientContact { ClientName = client.ClientName, ContactNo = client.ContactNo, Email = client.Email, Message = client.Message, ContactDate = DateTime.Now };
            _context.ClientContacts.Add(clientData);
            r = _context.SaveChanges();

            if (r > 0)
            {
                _notyf.Success("As soon as possible we will contact with u");
                // return RedirectToAction("/PropertyDetails/HomePropertyDetails/"+clientContact.PropertyID);
                //return RedirectToAction("Index", "Home");
                return Json(new { Data = clientData, issuccess =true });
            }        }
            return Json(new { Data = client ,issuccess=false});
        }



        //public async Task<IActionResult> Create(
        //     ClientVM clientContact)
        //{
        //    int Id = 0;
        //     if (ModelState.IsValid)
        //                     {
        //        var client = new ClientContact { ClientName = clientContact.ClientName, ContactNo = clientContact.ContactNo, Email = clientContact.Email, Message = clientContact.Message, ContactDate = DateTime.Now };
        //        _context.ClientContacts.Add(client);
        //        await _context.SaveChangesAsync();

        //        //if (clientContact.PropertyID > 0)
        //        //{
        //        _context.ClientInterest.Add(new ClientInterest { ClientID = client.ClientContactId, Message = clientContact.Message, PropertyID = clientContact.PropertyID, PropertyTypeId = clientContact.PropertyTypeId, PropertyForId = clientContact.PropertyForId });

        //            Id = clientContact.PropertyID;
        //        //}
        //        //else
        //        //{
        //        //    _context.ClientContacts.Add(client);
        //        //    await _context.SaveChangesAsync();
        //        //}

        //        //_context.ClientInterest.Add(new ClientInterest { ClientID = client.ClientContactId, Message = clientContact.Message, PropertyID = clientContact.PropertyID, PropertyTypeId = clientContact.PropertyTypeId, PropertyForId = clientContact.PropertyForId });

        //        //Id = clientContact.PropertyID;


        //        //_context.Add(clientContact);
        //        var r= await _context.SaveChangesAsync();
        //        if (r> 0)
        //        {


        //            _notyf.Success("As soon as possible we will contact with u");
        //            // return RedirectToAction("/PropertyDetails/HomePropertyDetails/"+clientContact.PropertyID);

        //            return RedirectToAction("HomePropertyDetails", "PropertyDetails", new { Id  });
        //        }

        //        //  return RedirectToAction(nameof(Index));
        //    }
        //    //ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "PropertyTypeId", "PropertyTypeName", 
        //    //    clientContact.PropertyTypeId);
        //    ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "PropertyTypeId", "PropertyTypeName"      );
        //    // return View(clientContact);
        //    return RedirectToAction("HomePropertyDetails", "PropertyDetails", new { Id });
        //}

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
            //ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "PropertyTypeId", "PropertyTypeName", clientContact.PropertyTypeId);
            ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "PropertyTypeId", "PropertyTypeName");
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
            ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "PropertyTypeId", "PropertyTypeName");
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
                //.Include(c => c.PropertyType)
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
