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
    [Authorize]
    public class NoticesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public NoticesController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            environment = _environment;
        }
        [AllowAnonymous]
        public JsonResult HomeNotice()
        {
            var noticeData = _context.Notices.OrderByDescending(p => p.NoticeID)
                                             .Where(p => p.IsActive == true).ToList();

            return Json(new { data = noticeData});
        }

        // GET: Notices
        public async Task<IActionResult> Index()
        {
              return _context.Notices != null ? 
                          View(await _context.Notices.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Notices'  is null.");
        }

        // GET: Notices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Notices == null)
            {
                return NotFound();
            }

            var notice = await _context.Notices
                .FirstOrDefaultAsync(m => m.NoticeID == id);
            if (notice == null)
            {
                return NotFound();
            }

            return View(notice);
        }

        // GET: Notices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Notices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NoticeID,Title,Description,Images,StartDate,EndDate,CreatedDate,CreatedBy,UpdateDate,UpdateBy,IsActive")] Notice notice)
        {
            try
            {
                string wwwRootPath = "";
                if (_environment!=null)
                {
                     wwwRootPath = _environment.WebRootPath;
                }
                else
                {
                    wwwRootPath = Directory.GetCurrentDirectory();
                }
               // string fileName = Path.GetFileNameWithoutExtension(notice.Images.FileName);
                string extension = Path.GetExtension(notice.Images.FileName);
                string fileName =  notice.Title + extension;
                string path = Path.Combine(wwwRootPath + "/wwwroot/Content/Images", fileName);
                using (var fileStrem = new FileStream(path, FileMode.Create))
                {
                    await notice.Images.CopyToAsync(fileStrem);
                }
                //if (ModelState.IsValid)
                //{
                //string fPath = "";
                //if (notice.Images != null)
                //{

                //    string pathSave = "";
                //    var folderName = Path.Combine("/Content/Images");
                //    if (_environment != null)
                //    {
                //        pathSave = Path.Combine(_environment.WebRootPath, folderName);
                //    }
                //    else
                //    {
                //        pathSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                //    }

                //    var fileName = notice.Title + Path.GetExtension(notice.Images.FileName);
                //    var filePath = Path.Combine(pathSave, fileName);
                //    fPath = "~/Content/Images/" + notice.Title + Path.GetExtension(notice.Images.FileName);
                //    using (var stream = new FileStream(filePath, FileMode.Create))
                //    {
                //        await notice.Images.CopyToAsync(stream);
                //    }
                //notice.Path = fPath;
                //return fPath;
                //}
                var noticeToInsert = new Notice
                {
                    Title = notice.Title,
                    Description = notice.Description,
                    StartDate = notice.StartDate,
                    EndDate = notice.EndDate,
                    CreatedBy = "Umme",
                    CreatedDate = DateTime.Now,
                    Path = "/Content/Images/"+fileName
                    };
                    //string UniqueFileName = UploadImage(notice);
                    
                    //notice.Path = UniqueFileName;
                    _context.Add(noticeToInsert);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                //}
                //ModelState.AddModelError(string.Empty, "Model property is not valid please check");
            } 
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            
            return View(notice);
        }

        //private string UploadImage(Notice model)
        //{
        //    string fPath = "
        //    ";
        //    string uniqueFileName = string.Empty;
        //    if(model.Images != null)
        //    {
        //        var folderName = Path.Combine("~/Content/Images");
        //        var pathSave = Path.Combine(_environment.WebRootPath, folderName);
        //        var fileName = model.Title + Path.GetExtension(model.Images.FileName);
        //        var filePath = Path.Combine(pathSave, fileName);
        //        fPath = "~/Content/Images/" + model.Title + Path.GetExtension(model.Images.FileName);
        //        using (var stream = new FileStream(filePath, FileMode.Create))
        //        {
        //            model.Images.CopyTo(stream);
        //        }
        //        return fPath;
        //    }
            //if (notice.Images != null)
            //{
                
            //    string uploadFolder = Path.Combine(_environment.WebRootPath, "Content/Images/");

            //    string fileName = Guid.NewGuid().ToString() + "_" + notice.Images.FileName;
            //    string filePath = Path.Combine(uploadFolder, fileName);
            //    string filetosave = "~/Content/Images/" + fileName;
            //    using (var fileStream = new FileStream(filePath, FileMode.Create))
            //    {
            //        notice.Images.CopyTo(fileStream);
            //    }
            //    return filetosave;
            //}
        //    return "";
        //}

        // GET: Notices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Notices == null)
            {
                return NotFound();
            }

            var notice = await _context.Notices.FindAsync(id);
            if (notice == null)
            {
                return NotFound();
            }
            return View(notice);
        }

        // POST: Notices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("NoticeID,Title,Description,Images,StartDate,EndDate,CreatedDate,CreatedBy,UpdateDate,UpdateBy,IsActive")] Notice notice)
        //{

        //    if (id != notice.NoticeID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(notice);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!NoticeExists(notice.NoticeID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(notice);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NoticeID,Title,Description,Images,StartDate,EndDate,CreatedDate,CreatedBy,UpdateDate,UpdateBy,IsActive")] Notice notice)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    //var data = _context.Notices.Where(n => n.NoticeID == notice.NoticeID).SingleOrDefaultAsync();
                    if(notice!= null)
                    {
                        var uniqueFileName = string.Empty;
                        if (notice.Images != null)
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
                            // string fileName = Path.GetFileNameWithoutExtension(notice.Images.FileName);
                            string extension = Path.GetExtension(notice.Images.FileName);
                            string fileName = notice.Title + extension;
                            string path = Path.Combine(wwwRootPath + "/wwwroot/Content/Images", fileName);
                            using (var fileStrem = new FileStream(path, FileMode.Create))
                            {
                                await notice.Images.CopyToAsync(fileStrem);
                            }
                            var NoticeToUpdate = new Notice
                            {
                                NoticeID = notice.NoticeID,
                                Title = notice.Title,
                                Description = notice.Description,
                                StartDate = notice.StartDate,
                                EndDate = notice.EndDate,
                                UpdateBy = "Kulsum",
                                UpdateDate = DateTime.Now,
                                Path = "/Content/Images/" + fileName
                            };
                            _context.Update(NoticeToUpdate);
                            if (await _context.SaveChangesAsync() > 0)
                            {
                                return RedirectToAction(nameof(Index));
                            }
                        };
                    }

                }

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return View();         
        }

        // GET: Notices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Notices == null)
            {
                return NotFound();
            }

            var notice = await _context.Notices
                .FirstOrDefaultAsync(m => m.NoticeID == id);
            if (notice == null)
            {
                return NotFound();
            }

            return View(notice);
        }

        // POST: Notices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Notices == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Notices'  is null.");
            }
            var notice = await _context.Notices.FindAsync(id);
            if (notice != null)
            {
                _context.Notices.Remove(notice);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoticeExists(int id)
        {
          return (_context.Notices?.Any(e => e.NoticeID == id)).GetValueOrDefault();
        }
    }
}
