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
    [Authorize(Roles = "Admin,Agent,Super Admin")]
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
        [AllowAnonymous]
        public JsonResult HomeDeveloperOrAgentsbyID(int Id)
        {
            try
            {
                var applicationDbContext = _context.DevelopersorAgent.Include(d => d.Area).Where(p => p.ID.Equals(Id));

                return Json(new { data = applicationDbContext });
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                return Json(new { data = "No record" });
            }

        }

        [AllowAnonymous]
        public JsonResult GetAgent()
        {
            try
            {
                var data = _context.DevelopersorAgent.OrderByDescending(d => d.Name).ToList();
                return Json(new { Data = data });
            }
            catch(Exception ex)
            {
                return Json(new { Data = ex.Message });
            }
        }
        [Authorize]
        public JsonResult GetAuthenticateAgent()
        {
            try
            {
                if (User.IsInRole("Agent"))
                {
                    var data = _context.DevelopersorAgent.OrderByDescending(d => d.Name).Where(a => a.Email.Equals(User.Identity.Name)).ToList();
                    return Json(new { Data = data });
                }
               else if (User.IsInRole("Admin") || User.IsInRole("Super Admin"))
                {

                    var data = _context.DevelopersorAgent.OrderByDescending(d => d.Name).ToList();
                    return Json(new { Data = data });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Data = ex.Message });
            }
            return Json(new { IsSuccess = false });
        }


        // GET: DevelopersorAgents
        public async Task<IActionResult> Index(bool?isActive)
        {
            try
            {
                if (User.IsInRole("Admin") || User.IsInRole("Super Admin"))
                {
                    //return _context.DevelopersorAgent != null ?
                    //View(await _context.DevelopersorAgent.OrderByDescending(d => d.ID)
                    //                                     .Where(a => a.IsActive).ToListAsync()) :
                    //Problem("Entity set 'ApplicationDbContext.DevelopersorAgent'  is null.");
                    var devdata = _context.DevelopersorAgent.OrderByDescending(d => d.ID)
                                                            .Where(a => a.IsActive);
                    return View(await devdata.ToListAsync());

                }
                else if (User.IsInRole("Agent"))
                {
                    var agent = _context.DevelopersorAgent
                                          .Where(d => d.Email.Equals(User.Identity.Name) && d.IsActive)
                                          .OrderByDescending(a => a.ID);
                    return View(await agent.ToListAsync());

                }
                //return _context.DevelopersorAgent != null ?
                //          View(await _context.DevelopersorAgent.OrderByDescending(p => p.ID).Where(d => d.IsActive).ToListAsync()) :
                //Problem("Entity set 'ApplicationDbContext.DevelopersorAgent'  is null.");
                return View();
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
        [AllowAnonymous]
        public async Task<IActionResult> Developer(bool? isActive=true)
        {

            return View();
        }
        [AllowAnonymous]
        public JsonResult GetDeveloper( )
        {
            try
            {
                var data = _context.DevelopersorAgent.Where(d => d.IsActive);
                return Json(new { Data = data });
            }
            catch (Exception ex)
            {
                return Json(new { data = "No Record" });
            }
        }

        [AllowAnonymous]
        public JsonResult HomeAgent(int id)
        {
            try
            {
                var data = _context.DevelopersorAgent.Where(d => d.ID == id);
                return Json(new { Data = data });
            }
            catch(Exception ex)
            {
                return Json(new { data = "No Record" });
            }
        }

        // GET: DevelopersorAgents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
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
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(id);
            }
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
                            developersorAgent.Logo = "/Developer/Logo/" + fileName;
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
                            developersorAgent.Banner = "/Developer/Banner/" + fileName;
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
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            try
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
                var alllocid = (from a in _context.Areas join c in _context.Citys on a.CityId equals c.CityId
                                join d in _context.Divisions on c.DivisionId equals d.DivisionID
                                join cc in _context.Countries on d.CountryId equals cc.CountryID
                                where a.AreaId == developersorAgent.AreaID
                                select new
                                {
                                    DivisionId = d.DivisionID,
                                    CityId = c.CityId,
                                    CountryId = cc.CountryID
                                }).FirstOrDefault();
                ViewData["AreaId"] = new SelectList(_context.Areas.OrderBy(a => a.AreaName), "AreaId", "AreaName", developersorAgent.AreaID);
                ViewData["CityId"] = new SelectList(_context.Citys, "CityId", "CityName", alllocid.CityId);
                ViewData["DivisionId"] = new SelectList(_context.Divisions, "DivisionID", "DivisionName", alllocid.DivisionId);
                ViewData["CountryId"] = new SelectList(_context.Countries, "CountryID", "CountryName", alllocid.CountryId);

                return View(developersorAgent);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(id);
            }
        }

        // POST: DevelopersorAgents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DevelopersorAgent developersorAgent)
        //public async Task<IActionResult> Edit(int id, DevelopersorAgent developersorAgent, IFormFile logofile, IFormFile bannerFile)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                if (id != developersorAgent.ID)
                {
                    return NotFound();
                }
                var data =await  _context.DevelopersorAgent.FindAsync( id);
                var wwwRootPath = "";
                var rPath = "";
                if(_environment != null)
                {
                    wwwRootPath = _environment.WebRootPath;
                    rPath = wwwRootPath + "/Developer";
                }
                else
                {
                    wwwRootPath = Directory.GetCurrentDirectory();
                    rPath = Path.Combine(wwwRootPath, "/wwwroot/Developer");
                }
                if (developersorAgent.logofile != null)
                {

                ////}
                ////if (developersorAgent.logofile.FileName.Length > 0)
                //    //if (logofile.FileName != null && logofile.FileName.Length > 0)
                //{
                    string extension = Path.GetExtension(developersorAgent.logofile.FileName).ToLower();
                    if(extension == ".jpg" || extension == ".png" || extension == ".jepg")
                    {
                        string fileName = $" {developersorAgent.CompanyName} logo {extension}";
                        string path = Path.Combine(rPath, "Logo", fileName);
                        using (var fileStrem = new FileStream (path, FileMode.Create))
                        {
                            await developersorAgent.logofile.CopyToAsync(fileStrem);
                        }
                        developersorAgent.Logo = "/Developer/Logo/" + fileName;
                        if (System.IO.File.Exists(rPath))
                        {
                            System.IO.File.Delete(rPath);
                        }
                         
                    }
                   
                    else
                    {
                        ModelState.AddModelError("", "Please provide .jpg|.jpeg|png");
                        return View(developersorAgent);
                    }

                }
                else
                {
                    //ModelState.AddModelError("", "Please Provide logo");
                    //return View(developersorAgent);
                    data.Logo = developersorAgent.Logo;
                }


                if(developersorAgent.bannerFile != null)
                {
                    string extension = Path.GetExtension(developersorAgent.bannerFile.FileName).ToLower();
                    if(extension == ".jpg" || extension == ".png" || extension == ".jepg")
                    {
                        string fileName = $" {developersorAgent.CompanyName} banner {extension}";
                        string path = Path.Combine(rPath, "Banner", fileName);
                        using(var fileStrem = new FileStream (path, FileMode.Create))
                        {
                            await developersorAgent.bannerFile.CopyToAsync(fileStrem);
                        }
                        developersorAgent.Banner = "/Developer/Banner/" + fileName;
                        if (System.IO.File.Exists(rPath))
                        {
                            System.IO.File.Delete(rPath);
                        }
                        //data.Banner = "~/Developer/Banner/" + fileName;
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please provide .jpg| .png| .jpeg");
                        return View(developersorAgent);
                    }
                }
                else
                {
                    //ModelState.AddModelError("", "Please provide Banner");
                    ////return View(developersorAgent);
                    ///
                    data.Banner = developersorAgent.Banner;
                }

                data.UpdateBy = User.Identity.Name ?? "";
                data.UpdateDate = DateTime.Now.Date;
                data.Banner=developersorAgent.Banner;
                data.Logo = developersorAgent.Logo;
                data.Email = developersorAgent.Email;
                data.AreaID = developersorAgent.AreaID;
                data.Address = developersorAgent.Address;
                data.AboutUs = developersorAgent.AboutUs;
                data.CompanyName = developersorAgent.CompanyName;
                data.ContactNo = developersorAgent.ContactNo;
                data.IsActive = developersorAgent.IsActive;
                data.Membership = developersorAgent.Membership;
                data.CreatedDate = developersorAgent.CreatedDate;
                data.CreatedBy =  developersorAgent.CreatedBy;  
                
                
                _context.Update(data);
                if(await _context.SaveChangesAsync() > 0)
                {
                   
                 var isExist=   await _userManager.FindByEmailAsync(data.Email);
                    if (isExist ==null)
                    {
                        var result = await _userManager.CreateAsync(new ApplicationUser { UserName = developersorAgent.Email, Email = developersorAgent.Email, PhoneNumber = developersorAgent.ContactNo }, password: "@Test123");
                        if (result.Succeeded)
                        {
                            transaction.Commit();
                            return RedirectToAction(nameof(Index));
                        }
                        else
                        {
                            string errorMessage = "";
                            if (result.Errors.Count() > 0)
                            {
                                foreach (var item in result.Errors)
                                {
                                    errorMessage += item.Description;
                                }
                            }
                            transaction.Rollback();
                            ModelState.AddModelError("", errorMessage);
                            return View(developersorAgent);
                        }
                    }
                    transaction.Commit();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch(Exception ex)
            {
                transaction.Rollback();
                ModelState.AddModelError("", ex.Message);
                return View(developersorAgent);
            }
            return View(developersorAgent);
        }

        // GET: DevelopersorAgents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
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
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(id);
            }
        }

        // POST: DevelopersorAgents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
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
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(id);
            }
        }

        private bool DevelopersorAgentExists(int id)
        {
          return (_context.DevelopersorAgent?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
