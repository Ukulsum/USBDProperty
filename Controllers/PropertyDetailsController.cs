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
            _environment = environment;
        }

        public JsonResult Getlocation(int aid)
        {
            var record = _context.PropertyDetails.OrderBy(c => c.Location)
                                            .Where(d => d.Area.AreaId.Equals(aid)).ToList();
            return Json(record);
        }

        //public IActionResult GetPropertyByParent(int id)
        //{
        //    var data = _context.PropertyDetails.Where(p => p.PropertyTypeId.Equals(id));
        //    return View(data);
        //}

        [HttpGet]
        public IActionResult GetPropertyByParent(int id)
        {
            try
            {
                var data = _context.PropertyDetails.OrderByDescending(p => p.PropertyInfoId)
                                               .Include(p => p.Area)
                                               .Include(p => p.ProjectsInfo)
                                               .Include(p => p.PropertyType)
                                               .Include(p => p.MeasurementUnit)
                                               .Where(p => p.PropertyTypeId.Equals(id));
                return View(data);
                //if (pforid != null || pforid > 0)
                //{
                //    //data = data.Where(p => p.PropertyFor.Equals(pforid)).ToList();
                //    data = data.Where(p => p.PropertyFor.Equals(pforid)).ToList();
                //}
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }



        [HttpGet]
        public IActionResult MoreSearch( int? forid,int? AreaId, int? pSize, int? PropertyTypeId, int? minsize, int? maxsize, int? NumberOfBedrooms, int? minprice, int? maxprice, string location = "")
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
                //if (pSize != null || pSize > 0)
                //{
                //    data = data.Where(p => p.PropertySize.Equals(pSize)).ToList();
                //}



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


        public JsonResult HomeFooterProperty()
        {
            try
            {
                var propertyDbContext = _context.PropertyDetails
                                        .Include(p => p.Area)
                                        .Include(p => p.ProjectsInfo)
                                        .Include(p => p.PropertyType)
                                        .Include(p => p.MeasurementUnit)
                                        .OrderByDescending(p => p.PropertyInfoId)
                                        .Take(3)
                                        .ToList();

                return Json(new {data = propertyDbContext});
            }
            catch(Exception ex)
            {
                return Json(new { data = "No record" });
            }
            
        }
        public JsonResult AgentHomeFooterProperty(int id)
        {
            try
            {
                var propertyDbContext = _context.PropertyDetails
                                        .Include(p => p.Area)
                                        .Include(p => p.ProjectsInfo)
                                        .Include(p => p.PropertyType)
                                        .Include(p => p.MeasurementUnit)
                                        .OrderByDescending(p => p.PropertyInfoId)
                                        .Take(3)
                                        .Where(p => p.PropertyInfoId.Equals(id))
                                        .ToList();

                return Json(new { data = propertyDbContext });
            }
            catch (Exception ex)
            {
                return Json(new { data = "No record" });
            }

        }

        public JsonResult HomeProperty()
        {
            try
            {
                var applicationDbContext = _context.PropertyDetails
                                                .Include(p=>p.MeasurementUnit)
                                                .Include(p => p.Area)
                                                 .Include(p => p.ProjectsInfo)
                                                .Include(p => p.PropertyType)
                                                
                                                .Where(p=>p.ISFeatured).ToList();
                

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
                                                .Include(p => p.MeasurementUnit)
                                                .Include(p => p.PropertyType);


                return Json(new { data = applicationDbContext });
            }
            catch (Exception ex)
            {
                return Json(new { data = "No record" });
            }

        }
        public JsonResult HomePropertybyID(int Id)
        {
            try
            {
                var joinPropertyInfoDb = from pd in _context.PropertyDetails join p in _context.ProjectsInfo on pd.ProjectId equals p.Id join devInfo in _context.DevelopersorAgent on p.Id equals devInfo.ID select pd;

                var locallid = from a in _context.Areas
                                join c in _context.Citys on a.CityId equals c.CityId
                                join d in _context.Divisions on c.DivisionId equals d.DivisionID
                                join cc in _context.Countries on d.CountryId equals cc.CountryID
                                where a.AreaId == Id
                                select new
                                {
                                    DivisionId = d.DivisionID,
                                    CityId = c.CityId,
                                    CountryId = cc.CountryID
                                };

                var applicationDbContext = _context.PropertyDetails
                                                .Include(p => p.Area)
                                                 .Include(p => p.ProjectsInfo)
                                                .Include(p => p.PropertyType)
                                                .Include(p => p.MeasurementUnit)
                                                .Where(p => p.PropertyInfoId.Equals(Id));

                return Json(new { data = applicationDbContext, joinPropertyInfoDb, locallid });
            }
            catch (Exception ex)
            {
                return Json(new { data = "No record" });
            }
        }
        public JsonResult  PropertybyProjects(int prjId)
        {
            try
            {
                var applicationDbContext = _context.PropertyDetails
                                                .Include(p => p.Area)
                                                 .Include(p => p.ProjectsInfo)
                                                .Include(p => p.PropertyType)
                                                .Where(p=>p.ProjectId.Equals(prjId));
                return Json(new { data = applicationDbContext});
            }
            catch (Exception ex)
            {
                return Json(new { data = "No record" });
            }

        }

        public JsonResult DevProperty(int id)
        {
            try
            {
                var applicationDbContext = _context.PropertyDetails
                                                .Include(p => p.Area)
                                                 .Include(p => p.ProjectsInfo)
                                                .Include(p => p.PropertyType)
                                                .Where(p => p.PropertyInfoId.Equals(id));
                return Json(new { data = applicationDbContext });
            }
            catch (Exception ex)
            {
                return Json(new { data = "No record" });
            }

        }

        //[HttpGet("HomePropertyDetails")]
        public async Task<IActionResult> HomePropertyDetails(int? id)
        {
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
                                                .Include(p => p.MeasurementUnit)
                                                .Include(p => p.PropertyType);

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
                    .Include(p => p.MeasurementUnit)
   
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
                return View();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PropertyDetails propertyDetails)
        {
            try
            {
                string wwwRootPath = "";
                string fpath = "";
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
                if(propertyDetails.Image != null)
                {
                    string extention = Path.GetExtension(propertyDetails.Image.FileName).ToLower();
                    if(extention == ".jpg" || extention == ".png" || extention == ".jpeg" || extention == "..svg" || extention == ".gif")
                    {
                        string fileName = propertyDetails.Title + extention;
                        string path = Path.Combine(fpath, "Images", fileName);
                        using (var fileStrem = new FileStream(path, FileMode.Create))
                        {
                            await propertyDetails.Image.CopyToAsync(fileStrem);
                        }
                        propertyDetails.ImagePath = "/Content/Images/" + fileName;
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please provide .jpg|.jepg|.png");
                        return View(propertyDetails);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Please provide Property Photos");
                }
                //var PropertyInfo = new PropertyDetails
                //{
                //    Title = propertyDetails.Title,
                //    Description = propertyDetails.Description,
                //    //PropertyName = propertyDetails.PropertyName,
                //    ISFeatured = propertyDetails.ISFeatured,
                //    Location = propertyDetails.Location,
                //    ConstructionStatus = propertyDetails.ConstructionStatus,
                //    PropertySize = propertyDetails.PropertySize,
                //    NumberOfBedrooms = propertyDetails.NumberOfBedrooms,
                //    NumberOfBaths = propertyDetails.NumberOfBaths,
                //    NumberOfBalconies = propertyDetails.NumberOfBalconies,
                //    NumberOfGarages = propertyDetails.NumberOfGarages,
                //    TotalFloor = propertyDetails.TotalFloor,
                //    FloorAvailableNo = propertyDetails.FloorAvailableNo,
                //    Furnishing = propertyDetails.Furnishing,
                //    Facing = propertyDetails.Facing,
                //    LandArea = propertyDetails.LandArea,
                //    Price = propertyDetails.Price,
                //    MeasurementID = propertyDetails.MeasurementID,
                //    PropertyFor = propertyDetails.PropertyFor,
                //    Comments = propertyDetails.Comments,
                //    HandOverDate = propertyDetails.HandOverDate,
                //    PropertyTypeId = propertyDetails.PropertyTypeId,
                //    PropertyCondition = propertyDetails.PropertyCondition,
                //    ProjectId = propertyDetails.ProjectId,
                //    //IconId = propertyDetails.IconId,
                //    AreaId = propertyDetails.AreaId,
                //    CreatedBy = User.Identity.Name ?? "umme",
                //    CreatedDate = DateTime.Now,
                //    Image = propertyDetails.Image,
                //    ImagePath = "/Content/Images/" + fileName
                //};
                propertyDetails.CreatedBy = User.Identity.Name ?? "umme";
                propertyDetails.CreatedDate = DateTime.Now;
                if (propertyDetails.TotalFloor.HasValue &&  propertyDetails.FloorAvailableNo.HasValue)
                {
                    if(propertyDetails.FloorAvailableNo.Value> propertyDetails.TotalFloor.Value)
                    {

                    
                    ModelState.AddModelError("", "Total Floor must be bigger than Floor Available No. Please fix this error");
                    ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "AreaName", propertyDetails.AreaId);
                    ViewData["ProjectId"] = new SelectList(_context.ProjectsInfo, "ProjectId", "Banner", propertyDetails.ProjectId);
                   
                    ViewData["ParentPropertyTypeId"] = new SelectList(_context.PropertyTypes, "ParentPropertyTypeId", "PropertyTypeName", propertyDetails.PropertyTypeId);
                    ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "PropertyTypeId", "PropertyTypeName", propertyDetails.PropertyTypeId);
                    return View();
                    }
                }               
                    _context.Add(propertyDetails);

                if (await _context.SaveChangesAsync() > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
             
            }
            catch (Exception ex)
            {

                if (ex.InnerException != null)
                {
                    ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "AreaName", propertyDetails.AreaId);
            ViewData["ProjectId"] = new SelectList(_context.ProjectsInfo, "ProjectId", "Banner", propertyDetails.ProjectId);
            //ViewData["ParentPropertyTypeId"] = new SelectList(_context.PropertyTypes, "ParentPropertyTypeId", "PropertyTypeName", propertyDetails.PropertyTypeId);
            //ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "PropertyTypeId", "PropertyTypeName", propertyDetails.PropertyTypeId);
            ViewData["ParentPropertyTypeId"] = new SelectList(_context.PropertyTypes, "ParentPropertyTypeId", "PropertyTypeName", propertyDetails.PropertyTypeId);
            ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "PropertyTypeId", "PropertyTypeName", propertyDetails.PropertyTypeId);
            ViewData["MeasurementID"] = new SelectList(_context.MeasurementUnit, "Id", "Name", propertyDetails.MeasurementID);
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

                var allid = (from a in _context.Areas join c in _context.Citys on a.CityId equals c.CityId 
                            join d in _context.Divisions on c.DivisionId equals d.DivisionID 
                            join cc in _context.Countries on d.CountryId equals cc.CountryID 
                            where a.AreaId==propertyDetails.AreaId
                            select new { 
                                DivisionId=d.DivisionID,
                                CityId=c.CityId,
                                CountryId=cc.CountryID
                            
                            } ).FirstOrDefault();

                var project = _context.ProjectsInfo.Where(p => p.Id.Equals(propertyDetails.ProjectId)).FirstOrDefault();
                var devloper = _context.DevelopersorAgent.Where(d => d.ID.Equals(project.AgentID));

                ViewData["ProjectsId"] = new SelectList(_context.ProjectsInfo.OrderBy(p => p.ProjectName), "Id", "ProjectName", propertyDetails.ProjectId);
                ViewData["AgentID"] = new SelectList(_context.DevelopersorAgent.OrderBy(p => p.CompanyName), "ID", "CompanyName", devloper);

                var pid = _context.PropertyTypes.Where(t => t.PropertyTypeId.Equals(propertyDetails.PropertyTypeId)).Select(s => s.ParentPropertyTypeId).FirstOrDefault();
                ViewData["AreaId"] = new SelectList(_context.Areas.OrderBy(a => a.AreaName), "AreaId", "AreaName", propertyDetails.AreaId);
                ViewData["CityId"] = new SelectList(_context.Citys, "CityId", "CityName", allid.CityId);
                ViewData["DivisionId"] = new SelectList(_context.Divisions, "DivisionID", "DivisionName", allid.DivisionId);
                ViewData["CountryId"] = new SelectList(_context.Countries, "CountryID", "CountryName", allid.CountryId);
                //ViewData["ProjectId"] = new SelectList(_context.ProjectsInfo, "ProjectId", "Banner", propertyDetails.ProjectId);
                ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes.Where(p => p.ParentPropertyTypeId == 0), "PropertyTypeId", "PropertyTypeName",pid.Value );
                ViewData["PropertychildTypeId"] = new SelectList(_context.PropertyTypes.Where(p => p.ParentPropertyTypeId == pid.Value), "PropertyTypeId", "PropertyTypeName",propertyDetails.PropertyTypeId);
                ViewData["MeasurementID"] = new SelectList(_context.MeasurementUnit, "Id", "Name", propertyDetails.MeasurementID);
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
                if (id != propertyDetails.PropertyInfoId)
                {
                    return NotFound();
                }

                var data = await _context.PropertyDetails.FindAsync(id);
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
                if (propertyDetails.Image != null)
                {
                    string extention = Path.GetExtension(propertyDetails.Image.FileName).ToLower();
                    if(extention == ".jpg" || extention == ".png" || extention == ".jpeg" || extention == "..svg" || extention == ".gif")
                    {
                        string fileName = propertyDetails.Title + extention;
                        string path = Path.Combine(fpath, "Images", fileName);
                        using (var fileStrem = new FileStream(path, FileMode.Create))
                        {
                            await propertyDetails.Image.CopyToAsync(fileStrem);
                        }
                        propertyDetails.ImagePath = "/Content/Images/" + fileName;
                        if (System.IO.File.Exists(fpath))
                        {
                            System.IO.File.Delete(fpath);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please provide .jpg| .jpeg| .png");
                        return View(propertyDetails);
                    }
                }
                else
                {
                    data.ImagePath = propertyDetails.ImagePath;
                }
               //if(propertyDetails.TotalFloor.HasValue && propertyDetails.FloorAvailableNo.HasValue)
               // {
               //     if(propertyDetails.FloorAvailableNo.Value > propertyDetails.TotalFloor.Value)
               //     {
               //         ModelState.AddModelError("", "Total Floor must be bigger than Floor Available No. Please fix this error");
               //         return View();
               //     }
               // }

                data.PropertyInfoId = propertyDetails.PropertyInfoId;
                data.Title = propertyDetails.Title;
                data.Description = propertyDetails.Description;
                //data.PropertyName = propertyDetails.PropertyName,
                data.Location = propertyDetails.Location;
                data.ConstructionStatus = propertyDetails.ConstructionStatus;
                data.FlatSize = propertyDetails.FlatSize;
                data.NumberOfBedrooms = propertyDetails.NumberOfBedrooms;
                data.NumberOfBaths = propertyDetails.NumberOfBaths;
                data.NumberOfBalconies = propertyDetails.NumberOfBalconies;
                data.NumberOfGarages = propertyDetails.NumberOfGarages;
                data.TotalFloor = propertyDetails.TotalFloor;
                data.FloorAvailableNo = propertyDetails.FloorAvailableNo;
                data.Furnishing = propertyDetails.Furnishing;
                data.Facing = propertyDetails.Facing;
                data.Price = propertyDetails.Price;
                data.LandArea = propertyDetails.LandArea;
                data.Comments = propertyDetails.Comments;
                data.MeasurementID = propertyDetails.MeasurementID;
                data.HandOverDate = propertyDetails.HandOverDate;
                data.PropertyTypeId = propertyDetails.PropertyTypeId;
                data.PropertyCondition = propertyDetails.PropertyCondition;
                data.ProjectId = propertyDetails.ProjectId;
                data.AreaId = propertyDetails.AreaId;
                data.CreatedBy = propertyDetails.CreatedBy;
                data.CreatedDate = propertyDetails.CreatedDate;
                data.UpdateBy = User.Identity.Name ?? "Kulsum";
                data.UpdateDate = DateTime.Now;
                data.ImagePath = propertyDetails.ImagePath;


                //if (propertyDetails.TotalFloor.Value < propertyDetails.FloorAvailableNo.Value )
                //{
                //    ModelState.AddModelError("", "Total Floor must be bigger than Floor Available No. Please fix this error");
                //}
                //else
                //{
                //    //data.TotalFloor = propertyDetails.TotalFloor;
                //    //data.FloorAvailableNo = propertyDetails.FloorAvailableNo;
                //    _context.Update(data);
                //}

                _context.Update(data);
                if(await _context.SaveChangesAsync() > 0)
                {
                    return RedirectToAction(nameof(Index));
                }

                
                ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "AreaName", propertyDetails.AreaId);
                ViewData["ProjectId"] = new SelectList(_context.ProjectsInfo, "ProjectId", "Banner", propertyDetails.ProjectId);
                ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "PropertyTypeId", "PropertyTypeName", propertyDetails.PropertyTypeId);
                ViewData["MeasurementID"] = new SelectList(_context.MeasurementUnit, "MeasurementID", "Name", propertyDetails.MeasurementID);
                return View(propertyDetails);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(propertyDetails);
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
