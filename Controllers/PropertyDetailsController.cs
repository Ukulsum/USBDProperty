using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    [Authorize(Roles = "Admin,Super Admin,Agent")]
    public class PropertyDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly INotyfService _notyf;
        public PropertyDetailsController(ApplicationDbContext context, IWebHostEnvironment environment, INotyfService srv)
        {
            _context = context;
            _environment = environment;
            _notyf = srv;
        }


        //All Properties
        [AllowAnonymous]
        public IActionResult AllProperties()
        {
            try
            {
                var data = _context.PropertyDetails.OrderByDescending(p => p.PropertyInfoId)
                                                .Include("PropertyType")
                                                .ToList();
                //.Select(p => new
                //{
                //    FlatSize = p.PropertyType.IsLand ? p.LandArea : p.FlatSize,
                //    NumberOfBedrooms = p.PropertyType.IsLand ? " " : p.NumberOfBedrooms.ToString(),
                //    NumberOfBaths = p.PropertyType.IsLand ? " " : p.NumberOfBaths.ToString(),
                //    TotalPrice = p.PropertyType.IsLand ? p.TotalLandPrice : p.TotalPrice,
                //    PropertyFor = p.PropertyFor,
                //    PropertyTypeName = p.PropertyType.PropertyTypeName,
                //    Location = p.Location
                //}).ToList();
                return View(data);
            }
            catch (Exception ex)
            {
               ViewBag.ErrorMessage = ex.Message;
            }
            return View();
        }

        [AllowAnonymous]
        public JsonResult GetDrpProperty(int pid)
        {
            try
            {
                //var property = _context.PropertyDetails.OrderByDescending(p => p.PropertyInfoId)
                //                                  .Where(d => d.ProjectId.Equals(pid)).ToList();
                //return Json(new { Data = property });
                if (User.IsInRole("Agent"))
                {
                    var property = _context.PropertyDetails.OrderByDescending(p => p.PropertyInfoId)
                                                           .Include("ProjectsInfo")
                                                           .Where(d => d.ProjectsInfo.Developers.Email.Equals(User.Identity.Name) && d.ProjectId.Equals(pid)).ToList();
                    return Json(new { Data = property });
                }
                else if (User.IsInRole("Admin") || User.IsInRole("Super Admin"))
                {
                    var property = _context.PropertyDetails.OrderByDescending(p => p.PropertyInfoId)
                                                           .Include("ProjectsInfo")
                                                           .Where(d => d.ProjectId.Equals(pid)).ToList();
                    return Json(new { Data = property });
                }
                return Json(new { IsSuccess = false });
            }
            catch(Exception ex)
            {
                return Json(new { Data = ex.Message });
            }
        }


        [AllowAnonymous]
        public JsonResult Getlocation(int aid)
        {
            try
            {
                var record = _context.PropertyDetails.OrderBy(c => c.Location)
                                         .Where(d => d.Area.AreaId.Equals(aid))
                                         .Select(l => new {l.Location}).Distinct()
                                         .ToList();
                return Json(record);
            }
            catch (Exception ex)
            {
                return Json(new { data = "No Record" });
            }
        }

        //public IActionResult GetPropertyByParent(int id)
        //{
        //    var data = _context.PropertyDetails.Where(p => p.PropertyTypeId.Equals(id));
        //    return View(data);
        //}
        [AllowAnonymous]
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
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        //[HttpGet]
        [AllowAnonymous]
        public IActionResult MoreSearch(int? Propertyfor, int? AreaId, int? pSize, int? PropertyTypeId, int? minsize, int? maxsize, int? NumberOfBedrooms, int? minprice, int? maxprice, int? conStatus, string location = "", string SearchText = "")
        {
            try
            {
                ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "AreaName");
                
                var data = _context.PropertyDetails.Where(p => p.IsActive)                                           
                                                   .Include(p => p.Area)
                                                   //.Include(p => p.ProjectsInfo)
                                                   .Include(p => p.PropertyType)
                                                   .Include(p => p.MeasurementUnit)
                                                   //.Select(n => n.Location).Distinct()
                                                   .ToList();
                //if (forid != null || forid > 0)
                //{
                //    data = data.Where(p => p.PropertyFor.Equals(forid)).ToList();
                //}
                if (Propertyfor > 0)
                {

                   
                    data = data.Where(p => p.PropertyFor.Equals((PropertyFor)Propertyfor)).ToList();
                }
                if (AreaId != null || AreaId > 0)
                {
                    data = data.Where(p => p.AreaId.Equals(AreaId)).ToList();
                }
                if (pSize != null || pSize > 0)
                {
                    data = data.Where(p => p.FlatSize.Equals(pSize)).ToList();
                }

                if (minsize > 0)
                {
                    data = data.Where(p => p.FlatSize >= minsize).ToList();
                }

                if (maxsize > 0)
                {
                    data = data.Where(p => p.FlatSize <= maxsize).ToList();
                }

                if ( PropertyTypeId > 0)//PropertyTypeId != null ||
                {
                    data = data.Where(p =>  p.PropertyType.ParentPropertyTypeId.Equals(PropertyTypeId)).ToList();
                }
                if (NumberOfBedrooms != null || NumberOfBedrooms > 0)
                {
                    data = data.Where(p => p.NumberOfBedrooms.Equals(NumberOfBedrooms)).ToList();
                }
                if ( minprice > 0)
                {
                    data = data.Where(p => p.Price>=minprice).ToList();
                }
                if ( maxprice > 0)
                {
                    data = data.Where(p => p.Price<=maxprice).ToList();
                }
               
                if ( conStatus > 0)
                {
                    data = data.Where(p => p.ConstructionStatus.Equals(conStatus)).ToList();
                }
                if (!string.IsNullOrEmpty(location))
                {
                    data = data.Where(p => p.Location.ToLower().Equals(location.ToLower())).ToList();
                }
               
                if (!string.IsNullOrEmpty(SearchText))
                {
                    data = data.Where(p => p.Title.ToLower().Contains(SearchText.ToLower())).ToList();
                }

                return View(data);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }  
        }

        [AllowAnonymous]
        public JsonResult Search()
        {
            return Json("Result");
        }

        [AllowAnonymous]
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

                return Json(new { data = propertyDbContext });
            }
            catch (Exception ex)
            {
                return Json(new { data = "No record" });
            }

        }

        [AllowAnonymous]
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
                                        .Where(p => p.ProjectsInfo.AgentID.Equals(id))
                                        .ToList();

                return Json(new { data = propertyDbContext });
            }
            catch (Exception ex)
            {
                return Json(new { data = "No record" });
            }

        }


        [AllowAnonymous]
        public JsonResult HomeFlatProperty()
        {
            try
            {
                var applicationDbContext = _context.PropertyDetails
                                                .Include(p => p.MeasurementUnit)
                                                .Include(p => p.Area)
                                                 .Include(p => p.ProjectsInfo)
                                                .Include(p => p.PropertyType)

                                                .Where(p => p.ISFeatured && p.PropertyType.IsLand == false).Select(s => new
                                                {
                                                    ContructionStatus = s.ConstructionStatus,
                                                    PropertyFor = s.PropertyFor.ToString(),
                                                    ImagePath = s.ImagePath,
                                                    LandArea = s.LandArea,
                                                    Location = s.Location,
                                                    NumberOfBaths = s.NumberOfBaths,
                                                    NumberOfBedrooms = s.NumberOfBedrooms,
                                                    Title = s.Title,
                                                    PropertyTypeName = s.PropertyType.PropertyTypeName,
                                                    TotalPrice = s.TotalPrice,
                                                    PropertyInfoId = s.PropertyInfoId,
                                                    FlatSize = s.FlatSize,
                                                    //IsLand= s.PropertyType.IsLand
                                                }).ToList();


                return Json(new { data = applicationDbContext });
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                return Json(new { data = "No record" });
            }

        }


        [AllowAnonymous]
        public JsonResult HomeLandProperty()
        {
            try
            {
                var applicationDbContext = _context.PropertyDetails
                                                .Include(p => p.MeasurementUnit)
                                                .Include(p => p.Area)
                                                 .Include(p => p.ProjectsInfo)
                                                .Include(p => p.PropertyType)

                                                .Where(p => p.ISFeatured && p.PropertyType.IsLand).Select(s => new
                                                {
                                                    //ContructionStatus = s.ConstructionStatus,
                                                    PropertyFor = s.PropertyFor.ToString(),
                                                    ImagePath = s.ImagePath,
                                                    LandArea = s.LandArea,
                                                    Location = s.Location,
                                                    //NumberOfBaths = s.NumberOfBaths,
                                                    //NumberOfBedrooms = s.NumberOfBedrooms,
                                                    Title = s.Title,
                                                    PropertyTypeName = s.PropertyType.PropertyTypeName,
                                                    TotalLandPrice = s.TotalLandPrice,
                                                    PropertyInfoId = s.PropertyInfoId,
                                                    MeasurementUnit = s.MeasurementUnit
                                                    //FlatSize = s.FlatSize,

                                                }).ToList();


                return Json(new { data = applicationDbContext });
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                return Json(new { data = "No record" });
            }

        }

        [AllowAnonymous]
        public JsonResult BannerProperty()
        {
            try
            {
                var applicationDbContext = _context.PropertyDetails
                                                .OrderByDescending(p => p.PropertyInfoId)
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


        [AllowAnonymous]
        //[HttpGet("HomePropertyDetails")]
        public async Task<IActionResult> HomePropertyDetails(int? id)
        {
            return View();
        }
        [AllowAnonymous]
        public JsonResult PropertyWithFeature(int Id) //property Details Show with feature
        {
            try
            {
                var featureData = _context.PropertyWithFeatures.Include(p => p.PropertyFeatures)
                                                               .Include(p => p.PropertyDetails)
                                                               .Where(p => p.PropertyId.Equals(Id))
                                                               .ToList();
                                                              
                return Json(new { Data = featureData });
            }
            catch (Exception ex)
            {
                return Json(new { data = "No record" });
            }
        }

        [AllowAnonymous]
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
                                                //.Include(p => p.PropertyType.IsLand)
                                                .Where(p => p.PropertyInfoId.Equals(Id))
                                                .Select(s => new
                                                {

                                                    //NumberOfGarages = s.PropertyType.IsLand ? "N/A" : s.NumberOfGarages.ToString(),
                                                    Title = s.Title,
                                                    Description = s.Description,
                                                    ConstructionStatus = s.PropertyType.IsLand ? "N/A" : s.ConstructionStatus.ToString(),
                                                    Comments = s.Comments,
                                                    FlatSize = s.PropertyType.IsLand ? s.LandArea + " " + s.MeasurementUnit.Name.ToString() : s.FlatSize + " sqft".ToString(),
                                                    ImagePath = s.ImagePath,
                                                    AreaName = s.Area.AreaName,
                                                    facing = s.PropertyType.IsLand ? "N/A" : s.Facing.ToString(),
                                                    FloorAvailableNo = s.PropertyType.IsLand ? "N/A" : s.FloorAvailableNo.ToString(),
                                                    Furnishing = s.PropertyType.IsLand ? "N/A" : s.Furnishing.ToString(),
                                                    HandOverDate = s.HandOverDate,
                                                    LandArea = s.LandArea,
                                                    //LandPrice = s.PropertyType.IsLand != null : s.LandPrice,
                                                    Location = s.Location,
                                                    name = s.MeasurementUnit.Name,
                                                    NumberOfBalconies = s.PropertyType.IsLand ? "N/A" : s.NumberOfBalconies.ToString(),
                                                    NumberOfBaths = s.PropertyType.IsLand ? "N/A" : s.NumberOfBaths.ToString(),
                                                    NumberOfBedrooms = s.PropertyType.IsLand ? "N/A" : s.NumberOfBedrooms.ToString(),
                                                    NumberOfGarages = s.PropertyType.IsLand ? "N/A" : s.NumberOfGarages.ToString(),
                                                    ProjectName = s.ProjectsInfo.ProjectName,
                                                    PropertyCondition = s.PropertyType.IsLand ? "N/A" : s.PropertyCondition.ToString(),
                                                    PropertyFor = s.PropertyFor.ToString(),
                                                    PropertyTypeName = s.PropertyType.PropertyTypeName,
                                                    TotalFloor = s.PropertyType.IsLand ? "N/A" : s.TotalFloor.ToString(),
                                                    TotalPrice = s.PropertyType.IsLand ? s.TotalLandPrice : s.TotalPrice,

                                                    //IsLand = s.PropertyType.IsLand,
                                                    //TotalLandPrice = s.PropertyType.IsLand ? "N/A" : s.TotalLandPrice.ToString(),
                                                    //IsLand = s.PropertyType.IsLand
                                                }).ToList();

                return Json(new { data = applicationDbContext, joinPropertyInfoDb, locallid });
            }
            catch (Exception ex)
            {
                return Json(new { data = "No record" });
            }
        }


        [AllowAnonymous]
        public JsonResult PropertybyProjects(int id)
        {
            try
            {
                var applicationDbContext = _context.PropertyDetails
                                                .Include(p => p.Area)
                                                 .Include(p => p.ProjectsInfo)
                                                .Include(p => p.PropertyType)
                                                .Where(p => p.ProjectId.Equals(id));
                return Json(new { data = applicationDbContext });
            }
            catch (Exception ex)
            {
                return Json(new { data = "No record" });
            }

        }


        [AllowAnonymous]
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


      


        private void AssignedPropertyFeature(PropertyDetails propertyDetails)
        {
            try
            {
                var allFeatures = _context.PropertyFeatures.ToList();
                HashSet<int> propertyFeatureList = new HashSet<int>();
                    var vm = new List<AssignPropertyFeatures>();
                if(propertyDetails.PropertyWithFeatures != null)
                {
                     propertyFeatureList = new HashSet<int>(propertyDetails.PropertyWithFeatures.Select(p => p.FeatureId));

                }
                foreach (var feature in allFeatures)
                {
                    vm.Add(new AssignPropertyFeatures
                    {
                        PropertyFeaturedId = feature.PropertyFeatureId,
                        PropertyName = feature.PropertyFeatureName,
                        Assigned = propertyFeatureList.Contains(feature.PropertyFeatureId)
                    });
                   ViewBag.propertyFeatures = vm;
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
           
        }
        //Feature Property Create
        public async Task<IActionResult> CreatePropertyFeatures(int id)
        {
            try
            {
                var propertyDetails = _context.PropertyDetails.Find(id);

                //propertyDetails.PropertyWithFeatures = new List<PropertyFeatures>();
                propertyDetails.PropertyWithFeatures = _context.PropertyWithFeatures.Where(r=>r.PropertyId.Equals(id)).ToList();
                AssignedPropertyFeature(propertyDetails);
                //var data = await _context.PropertyFeatures.ToListAsync();
                ViewData["propertyInfoId"] = new SelectList(_context.PropertyDetails.Where(p => p.PropertyInfoId.Equals(id)), "PropertyInfoId", "Title");
                ViewData["pid"] = id;
                //return View(data);
                return View();
            }
            catch(Exception ex)
            {
                //ModelState.AddModelError("", ex.Message);
                ViewBag.Message = ex.Message;
            }
            return View();
        }

        //POST: FeaturedProperty/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CreatePropertyFeatures( PropertyWithFeatures propertyWithFeatures, string[] selectedFeatures)
        //{
        //    try
        //    {
        //        if (selectedFeatures != null)
        //        {
        //            //propertyDetails.propertyFeatures = new List<PropertyFeatures>();
        //            //foreach (var feature in selectedFeatures)
        //            //{
        //            //    var featureToAdd = _context.PropertyFeatures.FindAsync(int.Parse(feature));
        //            //    propertyDetails.propertyFeatures.Add(await featureToAdd);
        //            //}
        //        }
        //        if (ModelState.IsValid)
        //        {
        //            _context.PropertyWithFeatures.Add(propertyWithFeatures);
        //            _context.SaveChanges();
        //            return RedirectToAction("AllFeatured");
        //        }
        //        AssignedPropertyFeature(propertyWithFeatures);
        //        ViewData["propertyInfoId"] = new SelectList(_context.PropertyDetails.Where(p => p.PropertyInfoId.Equals(propertyWithFeatures.PropertyId)), "PropertyInfoId", "Title");
        //        return View(propertyWithFeatures);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePropertyFeatures(int? id, string[] selectedFeatures)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var propertyToUpdate = await _context.PropertyDetails
                                                    .Include(i => i.PropertyWithFeatures)
                                                    .ThenInclude(i => i.PropertyFeatures)
                                                    .FirstOrDefaultAsync(m => m.PropertyInfoId == id);

                //if (await TryUpdateModelAsync<PropertyDetails>(propertyToUpdate,   ""))
                //{

                UpdatePropertyFeature(selectedFeatures, propertyToUpdate);
                try
                {
                    //foreach(var i in propertyToUpdate.PropertyWithFeatures)
                    //{
                    //    _context.PropertyWithFeatures.Add(i);
                    //}
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateException ex)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                    _notyf.Error(ex.Message);
                    AssignedPropertyFeature(propertyToUpdate);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }

            //}
            //UpdateInstructorCourses(selectedCourses, instructorToUpdate);
            //PopulateAssignedCourseData(instructorToUpdate);
            return View();
        }

        private void UpdatePropertyFeature(string[] selectedFeatures, PropertyDetails propertyToUpdate)
        {
            try
            {
                if (selectedFeatures == null)
                {
                    propertyToUpdate.PropertyWithFeatures = new List<PropertyWithFeatures>();
                    return;
                }

                var selectedFeaturesHS = new HashSet<string>(selectedFeatures);
                if (propertyToUpdate.PropertyWithFeatures != null)
                {
                    var propertyFeatures = new HashSet<int>
                    (propertyToUpdate.PropertyWithFeatures.Select(c => c.FeatureId));
                    foreach (var feature in _context.PropertyFeatures)
                    {
                        if (selectedFeaturesHS.Contains(feature.PropertyFeatureId.ToString()))
                        {
                            if (!propertyFeatures.Contains(feature.PropertyFeatureId))
                            {
                                propertyToUpdate.PropertyWithFeatures.Add(new PropertyWithFeatures { PropertyId = propertyToUpdate.PropertyInfoId, FeatureId = feature.PropertyFeatureId });
                            }
                        }
                        else
                        {

                            if (propertyFeatures.Contains(feature.PropertyFeatureId))
                            {
                                PropertyWithFeatures featureToRemove = propertyToUpdate.PropertyWithFeatures.FirstOrDefault(i => i.FeatureId == feature.PropertyFeatureId);
                                _context.Remove(featureToRemove);
                            }
                        }
                    }

                }
                //var propertyFeatures = new HashSet<int>
                //    (propertyToUpdate.PropertyWithFeatures.Select(c => c.FeatureId));

                else
                {
                    propertyToUpdate.PropertyWithFeatures = new List<PropertyWithFeatures>();
                    foreach (var feature in _context.PropertyFeatures)
                    {
                        if (selectedFeaturesHS.Contains(feature.PropertyFeatureId.ToString()))
                        {

                            propertyToUpdate.PropertyWithFeatures.Add(new PropertyWithFeatures { PropertyId = propertyToUpdate.PropertyInfoId, FeatureId = feature.PropertyFeatureId });

                        }

                    }
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);            
            }
        }
        // GET: PropertyDetails
        //[Authorize]
        public async Task<IActionResult> Index()
        {
            try
            {
                if (User.IsInRole("Agent"))
                {
                    var applicationDbContext = _context.PropertyDetails
                                                .OrderByDescending(o => o.PropertyInfoId)
                                                .Include(p => p.Area)
                                                .Include(p => p.ProjectsInfo)
                                                .Include(p => p.MeasurementUnit)
                                                .Include(p => p.PropertyType)
                                                .Where(p => p.ProjectsInfo.Developers.Email.Equals(User.Identity.Name));

                    return View(await applicationDbContext.ToListAsync());
                }
                else if (User.IsInRole("Admin") || User.IsInRole("Super Admin"))
                {
                    var applicationDbContext = _context.PropertyDetails
                                                .OrderByDescending(o => o.PropertyInfoId)
                                                .Include(p => p.Area)
                                                .Include(p => p.ProjectsInfo)
                                                .Include(p => p.MeasurementUnit)
                                                .Include(p => p.PropertyType);

                    return View(await applicationDbContext.ToListAsync());
                }
                //var applicationDbContext = _context.PropertyDetails
                //                                .OrderByDescending(o => o.PropertyInfoId)
                //                                .Include(p => p.Area)
                //                                .Include(p => p.ProjectsInfo)
                //                                .Include(p => p.MeasurementUnit)
                //                                .Include(p => p.PropertyType);

                //return View(await applicationDbContext.ToListAsync());
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                ViewBag.error = ex.Message;
                return View( new List<PropertyDetails>());
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
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: PropertyDetails/Create
        public IActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
               
                ModelState.AddModelError("", ex.Message);
                return View();
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
                if (propertyDetails.Image != null)
                {
                    string extention = Path.GetExtension(propertyDetails.Image.FileName).ToLower();
                    if (extention == ".jpg" || extention == ".png" || extention == ".jpeg" || extention == "..svg" || extention == ".gif")
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
                
                propertyDetails.CreatedBy = User.Identity.Name ?? "umme";
                propertyDetails.CreatedDate = DateTime.Now;
                //if (propertyDetails.TotalFloor.HasValue &&  propertyDetails.FloorAvailableNo.HasValue)
                //{
                //    if(propertyDetails.FloorAvailableNo.Value> propertyDetails.TotalFloor.Value)
                //    {


                //    ModelState.AddModelError("", "Total Floor must be bigger than Floor Available No. Please fix this error");
                //    ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "AreaName", propertyDetails.AreaId);
                //    ViewData["ProjectId"] = new SelectList(_context.ProjectsInfo, "ProjectId", "Banner", propertyDetails.ProjectId);

                //    ViewData["ParentPropertyTypeId"] = new SelectList(_context.PropertyTypes, "ParentPropertyTypeId", "PropertyTypeName", propertyDetails.PropertyTypeId);
                //    ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "PropertyTypeId", "PropertyTypeName", propertyDetails.PropertyTypeId);
                //    return View();
                //    }
                //}               
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
                propertyDetails.PropertyType = _context.PropertyTypes.Where(p => p.PropertyTypeId.Equals(propertyDetails.PropertyTypeId)).FirstOrDefault();
                var allid = (from a in _context.Areas
                             join c in _context.Citys on a.CityId equals c.CityId
                             join d in _context.Divisions on c.DivisionId equals d.DivisionID
                             join cc in _context.Countries on d.CountryId equals cc.CountryID
                             where a.AreaId == propertyDetails.AreaId
                             select new
                             {
                                 DivisionId = d.DivisionID,
                                 CityId = c.CityId,
                                 CountryId = cc.CountryID

                             }).FirstOrDefault();

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
                ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes.Where(p => p.ParentPropertyTypeId == 0), "PropertyTypeId", "PropertyTypeName", pid.Value);
                ViewData["PropertychildTypeId"] = new SelectList(_context.PropertyTypes.Where(p => p.ParentPropertyTypeId == pid.Value), "PropertyTypeId", "PropertyTypeName", propertyDetails.PropertyTypeId);
                ViewData["MeasurementID"] = new SelectList(_context.MeasurementUnit, "Id", "Name", propertyDetails.MeasurementID);
                return View(propertyDetails);
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                ModelState.AddModelError("", ex.Message);
            }
            return View();
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
                    if (data != null)
                    {
                        string npath = data.ImagePath.Replace("/", "");
                        string rootpath = wwwRootPath + npath;
                        if (System.IO.File.Exists(rootpath))
                        {
                            System.IO.File.Delete(rootpath);
                        }

                        string extention = Path.GetExtension(propertyDetails.Image.FileName).ToLower();
                        if (extention == ".jpg" || extention == ".png" || extention == ".jpeg" || extention == "..svg" || extention == ".gif")
                        {
                            string fileName = propertyDetails.Title + extention;
                            string path = Path.Combine(fpath, "Images", fileName);
                            using (var fileStrem = new FileStream(path, FileMode.Create))
                            {
                                await propertyDetails.Image.CopyToAsync(fileStrem);
                            }
                            propertyDetails.ImagePath = "/Content/Images/" + fileName;
                            //if (System.IO.File.Exists(fpath))
                            //{
                            //    System.IO.File.Delete(fpath);
                            //}
                        }
                        else
                        {
                            ModelState.AddModelError("", "Please provide .jpg| .jpeg| .png");
                            return View(propertyDetails);
                        }
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

                data.PropertyType = _context.PropertyTypes.Where(s => s.PropertyTypeId.Equals(propertyDetails.PropertyTypeId)).FirstOrDefault();
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
                if (await _context.SaveChangesAsync() > 0)
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
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // POST: PropertyDetails/Delete/5
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
                if (_context.PropertyDetails == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.PropertyDetails'  is null.");
                }
                var propertyDetails = await _context.PropertyDetails.FindAsync(id);
                if (propertyDetails != null)
                {
                    string path = propertyDetails.ImagePath.Replace("~", "");
                    _context.PropertyDetails.Remove(propertyDetails);
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
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        private bool PropertyDetailsExists(int id)
        {
            return (_context.PropertyDetails?.Any(e => e.PropertyInfoId == id)).GetValueOrDefault();
        }
    }
}
