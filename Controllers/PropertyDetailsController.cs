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
    public class PropertyDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public PropertyDetailsController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            environment = _environment;
        }

        [HttpGet]
        public IActionResult MoreSearch( int? forid,int? AreaId, string location="" )
        {
          var data=  _context.PropertyDetails.Where(p=>p.AreaId.Equals(AreaId) || p.PropertyFor.Equals(forid) || p.Location.Contains(location));
            return View(data);
        }

        


        public JsonResult Search()
        {
            return Json("Result");
        }

       
        public JsonResult HomeProperty()
        {
            try
            {
                var applicationDbContext = _context.PropertyDetails
                                                .Include(p => p.Area)
                                                 .Include(p => p.ProjectsInfo)
                                                .Include(p => p.PropertyType);
                                                //.Include(p => p.SocialIcon)
                                                //.Include(p => p.propertyFor).ToList();
                                              //.Include(p => p.TransactionType)
                                                
                return Json(new { data = applicationDbContext });
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                return Json(new { data="No record"});
            }

        }

        public JsonResult BannerProperty()
        {
            try
            {
                var applicationDbContext = _context.PropertyDetails
                                                .OrderByDescending(p=>p.PropertyInfoId)
                                                .Take(4)
                                                .Include(p => p.Area)
                                                .Include(p => p.ProjectsInfo)
                                                .Include(p => p.PropertyType);
                //.Include(p => p.SocialIcon)
                //.Include(p => p.propertyFor).ToList();
                //.Include(p => p.TransactionType)

                return Json(new { data = applicationDbContext });
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                return Json(new { data = "No record" });
            }

        }

        public JsonResult HomePropertybyID(int Id)
        {
            try
            {
                var applicationDbContext = _context.PropertyDetails
                                                .Include(p => p.Area)
                                                 .Include(p => p.ProjectsInfo)
                                                .Include(p => p.PropertyType)
                                                .Where(p=>p.PropertyInfoId.Equals(Id));
                //.Include(p => p.SocialIcon)
                //.Include(p => p.propertyFor).ToList();
                //.Include(p => p.TransactionType)

                return Json(new { data = applicationDbContext });
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                return Json(new { data = "No record" });
            }

        }
        //[HttpGet("HomePropertyDetails")]
        public async Task<IActionResult> HomePropertyDetails(int? id)
        {
            //try
            //{
            //    var applicationDbContext = await _context.PropertyDetails
            //                                    .OrderByDescending(o => o.PropertyInfoId)
            //                                    .Include(p => p.Area)
            //                                    .Include(p => p.ProjectsInfo)
            //                                    //.Include(p => p.PropertyType)
            //                                    //.Include(p => p.SocialIcon)
            //                                    .FirstOrDefaultAsync(m => m.PropertyInfoId == id);
            //    //.Include(p => p.TransactionType)
            //    //.Include(p => p.propertyFor);
            //    return View(applicationDbContext);
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}
            return View();
        }


        // GET: PropertyDetails
        //[Authorize]
        public async Task<IActionResult> Index()
        {
            try
            {
                var applicationDbContext = _context.PropertyDetails
                                                .OrderByDescending(o=>o.PropertyInfoId)
                                                .Include(p => p.Area)
                                                .Include(p => p.ProjectsInfo)
                                                .Include(p => p.PropertyType);
                                                //.Include(p => p.SocialIcon);
                                                //.Include(p => p.TransactionType)
                                                //.Include(p => p.propertyFor);
                return View(await applicationDbContext.ToListAsync());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        
        

        // GET: PropertyDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null || _context.PropertyDetails == null)
                {
                    return NotFound();
                }

                var propertyDetails = await _context.PropertyDetails
                    .Include(p => p.Area)
                    .Include(p => p.ProjectsInfo)
                    .Include(p => p.PropertyType)
                   // .Include(p => p.SocialIcon)
                    //.Include(p => p.TransactionType)
                    //.Include(p => p.propertyFor)
                    .FirstOrDefaultAsync(m => m.PropertyInfoId == id);
                if (propertyDetails == null)
                {
                    return NotFound();
                }

                return View(propertyDetails);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       
        // GET: PropertyDetails/Create
        public IActionResult Create()
        {
            try
            {
               // ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "AreaName");
              // ViewData["ProjectId"] = new SelectList(_context.ProjectsInfo, "ProjectId", "Banner");
               // ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes.OrderBy(a=>a.PropertyTypeName).Where(p=>p.ParentPropertyTypeId==0), "PropertyTypeId", "PropertyTypeName");
                //ViewData["IconId"] = new SelectList(_context.SocialIcons, "IconId", "Icon");
                //ViewData["TransactionTypeId"] = new SelectList(_context.TransactionTypes, "TransactionTypeId", "TransactionTypeName");
                //ViewData["PropertyForId"] = new SelectList(_context.PropertyFors, "PropertyForId", "PropeFor");
                return View();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: PropertyDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.


        //[Bind("PropertyInfoId,Title,Description,PropertyName,Location,ConstructionStatus,PropertySize,NumberOfBedrooms,NumberOfBaths,NumberOfBalconies,NumberOfGarages,TotalFloor,FloorAvailableNo,Furnishing,Facing,LandArea,Price,Measurement,Comments,HandOverDate,PropertyTypeId,TransactionTypeId,OwnerId,IconId,AreaId,PropertyForId,CreatedDate,CreatedBy,UpdateDate,UpdateBy,IsActive")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( PropertyDetails propertyDetails)
        {
            try
            {
                string wwwRootPath = "";
                if (_environment != null)
                {
                    wwwRootPath = _environment.WebRootPath;
                }
                else
                {
                    wwwRootPath = Directory.GetCurrentDirectory();
                }
                //string fileN = Path.GetFileNameWithoutExtension(propertyDetails.Image.FileName);
                string extention = Path.GetExtension(propertyDetails.Image.FileName);
                string fileName = propertyDetails.Title + extention;
                string path = Path.Combine(wwwRootPath + "/wwwroot/Content/Images", fileName);
                using (var fileStrem = new FileStream(path, FileMode.Create))
                {
                    await propertyDetails.Image.CopyToAsync(fileStrem);
                }

                var PropertyInfo = new PropertyDetails
                {
                    Title = propertyDetails.Title,
                    Description = propertyDetails.Description,
                    PropertyName = propertyDetails.PropertyName,
                    Location = propertyDetails.Location,
                    ConstructionStatus = propertyDetails.ConstructionStatus,
                    PropertySize = propertyDetails.PropertySize,
                    NumberOfBedrooms = propertyDetails.NumberOfBedrooms,
                    NumberOfBaths = propertyDetails.NumberOfBaths,
                    NumberOfBalconies = propertyDetails.NumberOfBalconies,
                    NumberOfGarages = propertyDetails.NumberOfGarages,
                    TotalFloor = propertyDetails.TotalFloor,
                    FloorAvailableNo = propertyDetails.FloorAvailableNo,
                    Furnishing = propertyDetails.Furnishing,
                    Facing = propertyDetails.Facing,
                    LandArea = propertyDetails.LandArea,
                    Price = propertyDetails.Price,
                    MeasurementID = propertyDetails.MeasurementID,
                    Comments = propertyDetails.Comments,
                    HandOverDate = propertyDetails.HandOverDate,
                    PropertyTypeId = propertyDetails.PropertyTypeId,
                    PropertyCondition = propertyDetails.PropertyCondition,
                    ProjectId = propertyDetails.ProjectId,
                    //IconId = propertyDetails.IconId,
                    AreaId = propertyDetails.AreaId,
                    CreatedBy =User.Identity.Name?? "umme",
                    CreatedDate = DateTime.Now,
                    Path = "/Content/Images/"+fileName
                };
                _context.Add(PropertyInfo);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "AreaName", propertyDetails.AreaId);
                ViewData["ProjectId"] = new SelectList(_context.ProjectsInfo, "ProjectId", "Banner", propertyDetails.ProjectId);
                ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "PropertyTypeId", "PropertyTypeName", propertyDetails.PropertyTypeId);
                //ViewData["IconId"] = new SelectList(_context.SocialIcons, "IconId", "Icon", propertyDetails.IconId);
                //ViewData["TransactionTypeId"] = new SelectList(_context.TransactionTypes, "TransactionTypeId", "TransactionTypeName", propertyDetails.TransactionTypeId);
                //ViewData["PropertyForId"] = new SelectList(_context.PropertyFors, "PropertyForId", "PropeFor", propertyDetails.PropertyForId);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(propertyDetails);
        }

        // GET: PropertyDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null || _context.PropertyDetails == null)
                {
                    return NotFound();
                }

                var propertyDetails = await _context.PropertyDetails.FindAsync(id);
                if (propertyDetails == null)
                {
                    return NotFound();
                }
                ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "AreaName", propertyDetails.AreaId);
                ViewData["ProjectId"] = new SelectList(_context.ProjectsInfo, "ProjectId", "Banner", propertyDetails.ProjectId);
                ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "PropertyTypeId", "PropertyTypeName", propertyDetails.PropertyTypeId);
                //ViewData["IconId"] = new SelectList(_context.SocialIcons, "IconId", "Icon", propertyDetails.IconId);
                //ViewData["TransactionTypeId"] = new SelectList(_context.TransactionTypes, "TransactionTypeId", "TransactionTypeName", propertyDetails.TransactionTypeId);
                //ViewData["PropertyForId"] = new SelectList(_context.PropertyFors, "PropertyForId", "PropeFor", propertyDetails.PropertyForId);
                return View(propertyDetails);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: PropertyDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PropertyInfoId,Title,Description,PropertyName,Location,ConstructionStatus,PropertySize,NumberOfBedrooms,NumberOfBaths,NumberOfBalconies,NumberOfGarages,TotalFloor,FloorAvailableNo,Furnishing,Facing,LandArea,Price,Measurement,Comments,HandOverDate,PropertyTypeId,TransactionTypeId,OwnerId,IconId,AreaId,PropertyForId,CreatedDate,CreatedBy,UpdateDate,UpdateBy,IsActive")] PropertyDetails propertyDetails)
        {
            try
            {
                if (id != propertyDetails.PropertyInfoId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(propertyDetails);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!PropertyDetailsExists(propertyDetails.PropertyInfoId))
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
                ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "AreaName", propertyDetails.AreaId);
                ViewData["ProjectId"] = new SelectList(_context.ProjectsInfo, "ProjectId", "Banner", propertyDetails.ProjectId);
                ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "PropertyTypeId", "PropertyTypeName", propertyDetails.PropertyTypeId);
                //ViewData["IconId"] = new SelectList(_context.SocialIcons, "IconId", "Icon", propertyDetails.IconId);
                //ViewData["TransactionTypeId"] = new SelectList(_context.TransactionTypes, "TransactionTypeId", "TransactionTypeName", propertyDetails.TransactionTypeId);
                //ViewData["PropertyForId"] = new SelectList(_context.PropertyFors, "PropertyForId", "PropeFor", propertyDetails.PropertyForId);
                return View(propertyDetails);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: PropertyDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null || _context.PropertyDetails == null)
                {
                    return NotFound();
                }

                var propertyDetails = await _context.PropertyDetails
                    .Include(p => p.Area)
                    .Include(p => p.ProjectsInfo)
                    .Include(p => p.PropertyType)
                    //.Include(p => p.SocialIcon)
                   // .Include(p => p.TransactionType)
                    //.Include(p => p.propertyFor)
                    .FirstOrDefaultAsync(m => m.PropertyInfoId == id);
                if (propertyDetails == null)
                {
                    return NotFound();
                }
                return View(propertyDetails);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: PropertyDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                if (_context.PropertyDetails == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.PropertyDetails'  is null.");
                }
                var propertyDetails = await _context.PropertyDetails.FindAsync(id);
                if (propertyDetails != null)
                {
                    _context.PropertyDetails.Remove(propertyDetails);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool PropertyDetailsExists(int id)
        {
          return (_context.PropertyDetails?.Any(e => e.PropertyInfoId == id)).GetValueOrDefault();
        }
    }
}
