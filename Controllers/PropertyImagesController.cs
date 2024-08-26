using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//using NuGet.Packaging.Signing;
using USBDProperty.Models;

namespace USBDProperty.Controllers
{
    [Authorize(Roles = "Admin,Agent")]
    public class PropertyImagesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public PropertyImagesController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: PropertyImages
        public async Task<IActionResult> Index(int propertyId = 0)
        {
            try
            {
                if (User.IsInRole("Agent"))
                {
                    var appDbData = _context.PropertyImages.Include(i => i.PropertyDetails.ProjectsInfo.Developers).Where(d => d.PropertyDetails.ProjectsInfo.Developers.Email.Equals(User.Identity.Name)).ToList();
                    if (propertyId > 0)
                    {
                        appDbData = appDbData.Where(d => d.propertyInfoId.Equals(propertyId)).ToList();
                    }
                    return View(appDbData);
                }
                else if (User.IsInRole("Admin") || User.IsInRole("Super Admin"))
                {
                    var applicationDbContext = _context.PropertyImages.Include(i => i.PropertyDetails).ToList();
                    if (propertyId > 0)
                    {
                        applicationDbContext = applicationDbContext.Where(p => p.propertyInfoId.Equals(propertyId)).ToList();
                    }
                    return View(applicationDbContext);
                }
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: PropertyImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null || _context.PropertyImages == null)
                {
                    return NotFound();
                }

                var propertyImages = await _context.PropertyImages
                    .Include(p => p.PropertyDetails)
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (propertyImages == null)
                {
                    return NotFound();
                }

                return View(propertyImages);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        public JsonResult HomeImagePropertybyID(int Id)
        {
            try
            {
                var applicationDbContext = _context.PropertyImages

                                                .Where(p => p.propertyInfoId.Equals(Id)).ToList();


                return Json(new { data = applicationDbContext });
            }
            catch (Exception ex)
            {
                return Json(new { data = "No record" });
            }
        }

        //GET: PropertyImages/Create
        public IActionResult Create(int id)
        {
            ViewData["propertyInfoId"] = new SelectList(_context.PropertyDetails.Where(p => p.PropertyInfoId.Equals(id)), "PropertyInfoId", "Title");
            return View();
        }
        //public IActionResult Create()
        //{
        //    ViewData["propertyInfoId"] = new SelectList(_context.PropertyDetails, "PropertyInfoId", "Title");
        //    return View();
        //}

        // POST: PropertyImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PropertyImages propertyImages, List<IFormFile> MultiImagePath)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string rpath = "";
                    string wwwRootPath = "";
                    if (_environment != null)
                    {
                        wwwRootPath = _environment.WebRootPath;
                        rpath = wwwRootPath + "/Content/Images";
                    }
                    else
                    {
                        wwwRootPath = Directory.GetCurrentDirectory();
                        rpath = Path.Combine(wwwRootPath, "/wwwroot/Content/Images");
                    }
                    for (int i = 0; i < MultiImagePath.Count(); i++)
                    {
                        string extention = Path.GetExtension(MultiImagePath[i].FileName).ToLower();
                        if (extention == ".jpg" || extention == ".png" || extention == ".jpeg")
                        {
                            string fileName = propertyImages.propertyInfoId + "_" + i + 1 + extention;
                            string path = Path.Combine(rpath, fileName);
                            using (var fileStrem = new FileStream(path, FileMode.Create))
                            {
                                await MultiImagePath[i].CopyToAsync(fileStrem);
                            }
                            propertyImages.ID = 0;
                            propertyImages.MultiImagePath = "/Content/Images/" + fileName;
                            _context.Add(propertyImages);
                            await _context.SaveChangesAsync();
                        }
                    }

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(propertyImages);
                }

                return RedirectToAction(nameof(Index));
            }
            ViewData["propertyInfoId"] = new SelectList(_context.PropertyDetails, "PropertyInfoId", "Title", propertyImages.propertyInfoId);
            return View(propertyImages);
        }

        // GET: PropertyImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null || _context.PropertyImages == null)
                {
                    return NotFound();
                }

                var propertyImages = await _context.PropertyImages.FindAsync(id);
                if (propertyImages == null)
                {
                    return NotFound();
                }
                ViewData["propertyInfoId"] = new SelectList(_context.PropertyDetails, "PropertyInfoId", "Location", propertyImages.propertyInfoId);
                return View(propertyImages);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: PropertyImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PropertyImages propertyImages)
        {
            try
            {
                if (id != propertyImages.ID)
                {
                    return NotFound();
                }
                var data = await _context.PropertyImages.FindAsync(id);
                string fpath = "";
                string wwwRootPath = "";
                if (_environment != null)
                {
                    wwwRootPath = _environment.WebRootPath;
                    fpath = wwwRootPath + "/Content";
                }
                else
                {
                    wwwRootPath = Directory.GetCurrentDirectory();
                    fpath = Path.Combine(wwwRootPath, "/wwwroot/Content");
                }
                if (propertyImages.MultipleImage != null)
                {
                    if (data != null)
                    {
                        string npath = data.MultiImagePath.Replace("~/", "");
                        string rootpath = wwwRootPath + npath;
                        if (System.IO.File.Exists(rootpath))
                        {
                            System.IO.File.Delete(rootpath);
                        }

                        string extension = Path.GetExtension(propertyImages.MultipleImage.FileName).ToLower();
                        if (extension == ".jpg" || extension == ".png" || extension == ".jpeg")
                        {
                            string fileName = propertyImages.Title + extension;
                            string path = Path.Combine(fpath, "Images", fileName);
                            using (var fileStrem = new FileStream(path, FileMode.Create))
                            {
                                await propertyImages.MultipleImage.CopyToAsync(fileStrem);
                            }
                            propertyImages.MultiImagePath = "/Content/Images/" + fileName;
                            if (System.IO.File.Exists(fpath))
                            {
                                System.IO.File.Delete(fpath);
                            }
                        }

                    }
                    else
                    {
                        ModelState.AddModelError("", "Please provide .jpg| .jpeg| .png");
                        return View(propertyImages);
                    }
                }
                else
                {
                    data.MultiImagePath = propertyImages.MultiImagePath;
                }
                //data.propertyInfoId = propertyImages.propertyInfoId;
                data.Title = propertyImages.Title;
                data.ID = propertyImages.ID;
                data.MultiImagePath = propertyImages.MultiImagePath;

                _context.Update(data);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(propertyImages);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(propertyImages);
            }

            //ViewData["propertyInfoId"] = new SelectList(_context.PropertyDetails.Select(p => (new { p.Location })).Distinct(), "PropertyInfoId", "Location", propertyImages.propertyInfoId);
            ViewData["propertyInfoId"] = new SelectList(_context.PropertyDetails, "PropertyInfoId", "Location", propertyImages.propertyInfoId);
            return View(propertyImages);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null || _context.PropertyImages == null)
                {
                    return NotFound();
                }

                var propertyImages = await _context.PropertyImages
                    .Include(p => p.PropertyDetails)
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (propertyImages == null)
                {
                    return NotFound();
                }

                return View(propertyImages);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: PropertyImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                string fpath = "";
                string wwwRootPath = "";
                if(_environment != null)
                {
                    wwwRootPath = _environment.WebRootPath;
                    fpath = wwwRootPath + "/Content";
                }
                else
                {
                    wwwRootPath = Directory.GetCurrentDirectory();
                    fpath = Path.Combine(wwwRootPath, "/wwwroot/Content");
                }
                if (_context.PropertyImages == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.PropertyImages'  is null.");
                }
                var propertyImages = await _context.PropertyImages.FindAsync(id);
                if (propertyImages != null)
                {
                    string path = propertyImages.MultiImagePath.Replace("~", "");
                    _context.PropertyImages.Remove(propertyImages);
                    if(await _context.SaveChangesAsync() > 0)
                    {
                        string rootPath = wwwRootPath + path;
                        if (System.IO.File.Exists(rootPath))
                        {
                            System.IO.File.Delete(rootPath);
                        }
                    }
                }

                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool PropertyImagesExists(int id)
        {
            return (_context.PropertyImages?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
