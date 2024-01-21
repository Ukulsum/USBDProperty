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

        public JsonResult Getlocation(int aid)
        {
            var record = _context.PropertyDetails.OrderBy(c => c.Location)
                                            .Where(d => d.Area.AreaId.Equals(aid)).ToList();
            return Json(record);
        }

        public IActionResult GetPropertyByParent(int id)
        {
            var data = _context.PropertyDetails.Where(p => p.PropertyTypeId.Equals(id));
            return View(data);
        }
        [HttpGet]
        public IActionResult MoreSearch( int? forid,int? AreaId, int? pSize, int? PropertyTypeId, int? minsize, int? maxsize, int? NumberOfBedrooms, 
             int? minprice, int? maxprice, string location = "")
        {
            try
            {
                ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "AreaName");
                //ViewData["PropertyInfoId"] = new SelectList(_context.PropertyDetails, "PropertyInfoId", "Location");
                //ViewData["NumberOfBedrooms"] = (_context.PropertyDetails, "PropertyInfoId", "NumberOfBedrooms");
                var data = _context.PropertyDetails.Where(p=>p.IsActive)
                                                   .Include(p => p.Area)
                                                   //.Include(p => p.ProjectsInfo)
                                                   .Include(p => p.PropertyType)
                                                   .Include(p => p.MeasurementUnit)
                                                    .ToList();
                if (forid != null || forid > 0)
                {
                    data = data.Where(p => p.PropertyFor.Equals(forid)).ToList();
                }
                if (AreaId != null || AreaId > 0)
                {
                    data = data.Where(p => p.AreaId.Equals(AreaId)).ToList();
                }
                if (pSize != null || pSize > 0)
                {
                    data = data.Where(p => p.PropertySize.Equals(pSize)).ToList();
                }
                //if (ptypeid != null || ptypeid > 0)
                //{
                //    data = data.Where(p => p.PropertyTypeId.Equals(ptypeid)).ToList();
                //}
                if (NumberOfBedrooms != null || NumberOfBedrooms > 0)
                {
                    data = data.Where(p => p.NumberOfBedrooms.Equals(NumberOfBedrooms)).ToList();
                }
                //if (pPrice != null || pPrice > 0)
                //{
                //    data = data.Where(p => p.Price.Equals(pPrice)).ToList();
                //}
                //if (conStatus != null || conStatus > 0)
                //{
                //    data = data.Where(p => p.ConstructionStatus.Equals(conStatus)).ToList();
                //}
                if (!string.IsNullOrEmpty(location))
                {
                    data = data.Where(p => p.Location.ToLower().Equals(location.ToLower())).ToList();
                }
                //if (SearchText != " " || SearchText != null)
                //{
                //    data = data.Where(p => p.PropertyName!.Contains(SearchText).ToList());
                //}



                //var data=  _context.PropertyDetails.Where(p=>p.AreaId.Equals(AreaId) || p.PropertyFor.Equals(forid) || p.Location.Contains(location));

                //ViewData["PropertyInfoId"] = new SelectList(_context.PropertyDetails, "PropertyInfoId", "PropertyFor");


                return View(data);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }

           
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
                var joinPropertyInfoDb = from pd in _context.PropertyDetails join p in _context.ProjectsInfo on pd.ProjectId equals p.Id join devInfo in _context.DevelopersorAgent on p.Id equals devInfo.ID select pd;
                var applicationDbContext = _context.PropertyDetails
                                                .Include(p => p.Area)
                                                 .Include(p => p.ProjectsInfo)
                                                .Include(p => p.PropertyType)
                                                .Where(p=>p.PropertyInfoId.Equals(Id));


                //.Include(p => p.SocialIcon)
                //.Include(p => p.propertyFor).ToList();
                //.Include(p => p.TransactionType)

                return Json(new { data = applicationDbContext, joinPropertyInfoDb});
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PropertyDetails propertyDetails)
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
                    CreatedBy = User.Identity.Name ?? "umme",
                    CreatedDate = DateTime.Now,
                    Path = "/Content/Images/" + fileName
                };
                _context.Add(PropertyInfo);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "AreaName", propertyDetails.AreaId);
                ViewData["ProjectId"] = new SelectList(_context.ProjectsInfo, "ProjectId", "Banner", propertyDetails.ProjectId);
                ViewData["ParentPropertyTypeId"] = new SelectList(_context.PropertyTypes, "ParentPropertyTypeId", "PropertyTypeName", propertyDetails.PropertyTypeId);
                ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "PropertyTypeId", "PropertyTypeName", propertyDetails.PropertyTypeId);
                //ViewData["CountryID"] = new SelectList(_context.Countries, "CountryID", "CountryName", Country.CountryName);
                //ViewData["IconId"] = new SelectList(_context.SocialIcons, "IconId", "Icon", propertyDetails.IconId);
                //ViewData["TransactionTypeId"] = new SelectList(_context.TransactionTypes, "TransactionTypeId", "TransactionTypeName", propertyDetails.TransactionTypeId);
                //ViewData["PropertyForId"] = new SelectList(_context.PropertyFors, "PropertyForId", "PropeFor", propertyDetails.PropertyForId);
            }
            catch (Exception ex)
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

                //var area = _context.Areas.Where(a => a.AreaId.Equals(propertyDetails.AreaId)).FirstOrDefault();
                //var cities = _context.Citys.Where(d => d.CityId.Equals(area.CityId));
                //ViewData["CityId"] = new SelectList(_context.Citys, "CityId", "CityName", area.CityId);
                //ViewData["CityId"] = new SelectList(_context.Citys, "CityId", "CityName", area.CityId);


                var allid = (from a in _context.Areas join c in _context.Citys on a.CityId equals c.CityId 
                            join d in _context.Divisions on c.DivisionId equals d.DivisionID 
                            join cc in _context.Countries on d.CountryId equals cc.CountryID 
                            where a.AreaId==propertyDetails.AreaId
                            select new { 
                                DivisionId=d.DivisionID,
                                CityId=c.CityId,
                                CountryId=cc.CountryID
                            
                            } ).FirstOrDefault();

                


                //var devprojectid = from p in _context.ProjectsInfo
                //                   join d in _context.DevelopersorAgent on p.AgentID equals d.ID
                //                   where p.Id == propertyDetails.ProjectId
                //                   select p;

                //var dp = from p in _context.pro

                //var project = _context.ProjectsInfo.Where(p => p.Id.Equals(propertyDetails.ProjectId)).FirstOrDefault();
                //var devloper = _context.DevelopersorAgent.Where(d => d.ID.Equals(project.AgentID));

                //ViewData["Id"] = new SelectList(_context.ProjectsInfo.OrderBy(p => p.ProjectName), "Id", "ProjectName", propertyDetails.ProjectId);
                //ViewData["ID"] = new SelectList(_context.DevelopersorAgent.OrderBy(p => p.CompanyName), "ID", "CompanyName", devloper);


                //ViewData["Id"] = new SelectList(_context.ProjectsInfo.OrderBy(p => p.ProjectName).Where(p=>p.Id.Equals(propertyDetails.ProjectId)), "Id", "ProjectName", propertyDetails.ProjectId);
                //ViewData["ID"] = new SelectList(_context.DevelopersorAgent.OrderBy(p => p.CompanyName).Where(p=>p.ID.Equals(ProjectsInfo.ID)), "Id", "ProjectName", propertyDetails.ProjectId);
                ViewData["AreaId"] = new SelectList(_context.Areas.OrderBy(a => a.AreaName), "AreaId", "AreaName", propertyDetails.AreaId);
                ViewData["CityId"] = new SelectList(_context.Citys, "CityId", "CityName", allid.CityId);
                ViewData["DivisionId"] = new SelectList(_context.Divisions, "DivisionID", "DivisionName", allid.DivisionId);
                ViewData["CountryId"] = new SelectList(_context.Countries, "CountryID", "CountryName", allid.CountryId);
                //ViewData["ProjectId"] = new SelectList(_context.ProjectsInfo, "ProjectId", "Banner", propertyDetails.ProjectId);
                ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "PropertyTypeId", "PropertyTypeName", propertyDetails.PropertyTypeId);
                ViewData["MeasurementID"] = new SelectList(_context.MeasurementUnit, "Id", "Name", propertyDetails.MeasurementID);
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




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PropertyDetails propertyDetails)
        {
            try
            {
                var data = _context.PropertyDetails.Where(m => m.PropertyInfoId == propertyDetails.PropertyInfoId).SingleOrDefaultAsync();
                string fpath = "";
                string wwwRootPath = "";
                if (propertyDetails.Path.Length > 0)
                {
                    if (_environment != null)
                    {
                        wwwRootPath = _environment.WebRootPath;
                    }
                    else
                    {
                        wwwRootPath = Directory.GetCurrentDirectory();
                    }
                    string extention = Path.GetExtension(propertyDetails.Image.FileName);
                    string fileName = propertyDetails.Title + extention;
                    fpath = Path.Combine(wwwRootPath + "/wwwroot/Content/Images", fileName);
                    using (var fileStrem = new FileStream(fpath, FileMode.Create))
                    {
                        await propertyDetails.Image.CopyToAsync(fileStrem);
                    }
                }
                else
                {
                    fpath = data.Result.Path;
                }

                var propertyInfo = new PropertyDetails
                {
                    PropertyInfoId = propertyDetails.PropertyInfoId,
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
                    Price = propertyDetails.Price,
                    LandArea = propertyDetails.LandArea,
                    Comments = propertyDetails.Comments,
                    MeasurementID = propertyDetails.MeasurementID,
                    HandOverDate = propertyDetails.HandOverDate,
                    PropertyTypeId = propertyDetails.PropertyTypeId,
                    PropertyCondition = propertyDetails.PropertyCondition,
                    ProjectId = propertyDetails.ProjectId,
                    AreaId = propertyDetails.AreaId,
                    UpdateBy = User.Identity.Name ?? "Kulsum",
                    UpdateDate = DateTime.Now,
                    Path = fpath
                };
                _context.Entry(propertyDetails).State = EntityState.Modified;
                if(await _context.SaveChangesAsync() > 0)
                {
                    return RedirectToAction(nameof(Index));
                }

                //if (id != propertyDetails.PropertyInfoId)
                //{
                //    return NotFound();
                //}

                //if (ModelState.IsValid)
                //{
                //    try
                //    {
                //        _context.Update(propertyDetails);
                //        await _context.SaveChangesAsync();
                //    }
                //    catch (DbUpdateConcurrencyException)
                //    {
                //        if (!PropertyDetailsExists(propertyDetails.PropertyInfoId))
                //        {
                //            return NotFound();
                //        }
                //        else
                //        {
                //            throw;
                //        }
                //    }
                //    return RedirectToAction(nameof(Index));
                //}
                ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "AreaName", propertyDetails.AreaId);
                ViewData["ProjectId"] = new SelectList(_context.ProjectsInfo, "ProjectId", "Banner", propertyDetails.ProjectId);
                ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "PropertyTypeId", "PropertyTypeName", propertyDetails.PropertyTypeId);
                ViewData["MeasurementID"] = new SelectList(_context.MeasurementUnit, "MeasurementID", "Name", propertyDetails.MeasurementID);
                //ViewData["IconId"] = new SelectList(_context.SocialIcons, "IconId", "Icon", propertyDetails.IconId);
                //ViewData["TransactionTypeId"] = new SelectList(_context.TransactionTypes, "TransactionTypeId", "TransactionTypeName", propertyDetails.TransactionTypeId);
                //ViewData["PropertyForId"] = new SelectList(_context.PropertyFors, "PropertyForId", "PropeFor", propertyDetails.PropertyForId);
                return View(propertyDetails);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: PropertyDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, PropertyDetails propertyDetails)
        //{
        //    try
        //    {
        //        if (id != propertyDetails.PropertyInfoId)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                _context.Update(propertyDetails);
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!PropertyDetailsExists(propertyDetails.PropertyInfoId))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //            return RedirectToAction(nameof(Index));
        //        }
        //        ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "AreaName", propertyDetails.AreaId);
        //        ViewData["ProjectId"] = new SelectList(_context.ProjectsInfo, "ProjectId", "Banner", propertyDetails.ProjectId);
        //        ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "PropertyTypeId", "PropertyTypeName", propertyDetails.PropertyTypeId);
        //        ViewData["MeasurementID"] = new SelectList(_context.MeasurementUnit, "MeasurementID", "Name", propertyDetails.MeasurementID);
        //        //ViewData["IconId"] = new SelectList(_context.SocialIcons, "IconId", "Icon", propertyDetails.IconId);
        //        //ViewData["TransactionTypeId"] = new SelectList(_context.TransactionTypes, "TransactionTypeId", "TransactionTypeName", propertyDetails.TransactionTypeId);
        //        //ViewData["PropertyForId"] = new SelectList(_context.PropertyFors, "PropertyForId", "PropeFor", propertyDetails.PropertyForId);
        //        return View(propertyDetails);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

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
