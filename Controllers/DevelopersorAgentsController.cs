using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using USBDProperty.Models;

namespace USBDProperty.Controllers
{
    [Authorize(Roles = "Admin,Agent")]
    public class DevelopersorAgentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly UserManager<ApplicationUser> _userManager;
        public DevelopersorAgentsController(ApplicationDbContext context, 
            IWebHostEnvironment environment, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _environment = environment;
            _userManager = userManager;
        }

        // GET: DevelopersorAgents
        public async Task<IActionResult> Index(bool?isActive)
        {

              return _context.DevelopersorAgent != null ? 
                          View(await _context.DevelopersorAgent.Where(d=>d.IsActive).ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.DevelopersorAgent'  is null.");
        }
        public async Task<IActionResult> Developer(bool? isActive=true)
        {

            return View();
        }
        [AllowAnonymous]
        public  JsonResult  GetDeveloper( )
        {
            var data = _context.DevelopersorAgent.Where(d=>d.IsActive);
            return Json(new { Data = data });
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
        [HttpGet]
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
        public async Task<IActionResult> Create( DevelopersorAgent developersorAgent,IFormFile logo,IFormFile banner)
        {
            //if (ModelState.IsValid)
            //{
                ////https://www.milanjovanovic.tech/blog/working-with-transactions-in-ef-core
                using var transaction = _context.Database.BeginTransaction();
                try
                {
                    string wwwRootPath = "";
                string rpath = "";
                    if (_environment != null)
                    {
                        wwwRootPath = _environment.WebRootPath;
                    rpath = wwwRootPath + "/Developer";
                    }
                    else
                    {
                        wwwRootPath = Directory.GetCurrentDirectory();
                    rpath = Path.Combine(wwwRootPath, "/wwwroot/Developer");
                }
                    if (logo.FileName != null)
                    {
                        string extension = Path.GetExtension(logo.FileName).ToLower();
                        if (extension == ".jpg" || extension == ".png" || extension == ".jpeg")
                        {
                            //string fileName = developersorAgent.CompanyName + extension;
                        string fileName = $" {developersorAgent.CompanyName} logo {extension}";
                        string path = Path.Combine(rpath,"Logo", fileName);
                            using (var fileStrem = new FileStream(path, FileMode.Create))
                            {
                                await logo.CopyToAsync(fileStrem);
                            }
                            developersorAgent.Logo = "~/Developer/Logo/" + fileName;
                        }
                        else
                        {
                            ModelState.AddModelError("", "Please provide jpg|.jpeg|png");
                            return View(developersorAgent);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please provide logo ");
                        return View(developersorAgent);
                    }
                    if (banner.FileName != null)
                    {
                        string extension = Path.GetExtension(banner.FileName).ToLower();
                        if (extension == ".jpg" || extension == ".png" || extension == ".jpeg")
                        {
                            string fileName =$" {developersorAgent.CompanyName} _banner {extension}";
                        //string path = Path.Combine(wwwRootPath + "/wwwroot/Developer/Banner", fileName);
                        string path = Path.Combine(rpath,"Banner", fileName);
                        using (var fileStrem = new FileStream(path, FileMode.Create))
                            {
                                await banner.CopyToAsync(fileStrem);
                            }
                            developersorAgent.Banner = "~/Developer/Banner/" + fileName;
                        }
                        else
                        {
                            ModelState.AddModelError("", "Please provide jpg|jpeg|png");
                            return View(developersorAgent);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please provide logo ");
                        return View(developersorAgent);
                    }
                    developersorAgent.CreatedBy = User.Identity.Name ?? "";
                    developersorAgent.CreatedDate = DateTime.Now.Date;
                    _context.Add(developersorAgent);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        var result = await _userManager.CreateAsync(new ApplicationUser { UserName = developersorAgent.Email, Email = developersorAgent.Email, PhoneNumber = developersorAgent.ContactNo }, password: "@Test123");
                        if (result.Succeeded)
                        {
                            transaction.Commit();
                            return RedirectToAction(nameof(Index));
                        }
                        else
                        {
                            string errormsg = "";
                            if (result.Errors.Count() > 0)
                            {
                                foreach (var item in result.Errors)
                                {
                                    errormsg += item.Description;
                                }
                            }
                            transaction.Rollback();
                            ModelState.AddModelError("", errormsg);
                            return View(developersorAgent);
                        }
                    }
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    ModelState.AddModelError("", ex.Message);
                return View(developersorAgent);
                }
            //}
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
