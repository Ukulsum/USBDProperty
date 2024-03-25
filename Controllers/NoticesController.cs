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
    [Authorize(Roles = "Admin,Agent")]
    public class NoticesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public NoticesController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        [AllowAnonymous]
        public JsonResult HomeNotice()
        {
            try
            {
                //var noticeData = _context.Notices.OrderByDescending(p => p.NoticeID)
                //                                 .Where(p => p.IsActive   && p.IsFeatured   && p.EndDate >= DateTime.Today).Take(1).ToList();
                var noticeData = _context.Notices.OrderByDescending(p => p.NoticeID)
                                                 .Where(p => p.IsActive && p.IsFeatured && p.EndDate >= DateTime.Today).ToList();

                return Json(new { data = noticeData });
            }
            catch(Exception ex)
            {
                return Json(new { data = ex.Message });
            }
        }


        [AllowAnonymous]
        public async Task<IActionResult> NoticeDetails(int? id)
        {
            return View();
        }


        [AllowAnonymous]
        public JsonResult NoticeDetailsByID(int Id)
        {
            try
            {
                var nData = _context.Notices.OrderByDescending(n => n.NoticeID)
                                            .Where(n => n.NoticeID.Equals(Id)).ToList();
                return Json(new { data = nData });
            }
            catch (Exception ex)
            {
                return Json(new { data = "No record" });
            }
        }


        //[AllowAnonymous]
        //public async Task<IActionResult> NoticeDetails()
        //{
        //    try
        //    {
        //        var nData = _context.Notices.OrderByDescending(n => n.NoticeID).ToList();
        //        return View(nData);
        //    }
        //    catch(Exception ex)
        //    {
        //        ModelState.AddModelError("", ex.Message);
        //        return View();
        //    }
        //}

        // GET: Notices
        public async Task<IActionResult> Index()
        {
            try
            {
                return _context.Notices != null ?
                          View(await _context.Notices.OrderByDescending(p => p.NoticeID).ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Notices'  is null.");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: Notices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
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
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
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
        public async Task<IActionResult> Create(Notice notice)
        {
            try
            {
                string wwwRootPath = "";
                string fpath = "";
                if (_environment!=null)
                {
                     wwwRootPath = _environment.WebRootPath;
                    fpath = wwwRootPath + "/Content";
                }
                else
                {
                    wwwRootPath = Directory.GetCurrentDirectory();
                    fpath = Path.Combine(wwwRootPath, "/wwwroot/Content");
                }
                if(notice.Images != null)
                {
                    string extension = Path.GetExtension(notice.Images.FileName).ToLower();
                    if(extension == ".jpg" || extension == ".png" || extension == ".jpeg" || extension == "..svg" || extension == ".gif")
                    {
                        string fileName = notice.Title + extension;
                        string path = Path.Combine(fpath, "Images", fileName);
                        using (var fileStrem = new FileStream(path, FileMode.Create))
                        {
                            await notice.Images.CopyToAsync(fileStrem);
                        }
                        notice.ImagePath = "/Content/Images/" + fileName;
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please provide .jpg|.jpeg|.png");
                        return View(notice);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Please provide Photo ");
                }      
                _context.Add(notice);
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

        // GET: Notices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
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
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Notice notice)
        {
            try
            {
                if (id != notice.NoticeID)
                {
                    return NotFound();
                }
                var data = await _context.Notices.FindAsync(id);
                string fpath = "";
                string wwwRootPath = "";
                //if (notice.Images != null)
                //{
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
                if(notice.Images != null)
                {
                    string extension = Path.GetExtension(notice.Images.FileName).ToLower();
                    if(extension==".jpg" || extension == ".png" || extension == ".jpeg" || extension == "..svg" || extension == ".gif")
                    {
                        string fileName = notice.Title + extension;
                        string path = Path.Combine(fpath, "Images", fileName);
                        using (var fileStrem = new FileStream(path, FileMode.Create))
                        {
                            await notice.Images.CopyToAsync(fileStrem);
                        }
                         notice.ImagePath = "/Content/Images/" + fileName;
                        if (System.IO.File.Exists(fpath))
                        {
                            System.IO.File.Delete(fpath);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please provide .jpg|.jpeg|.png");
                        return View(notice);
                    }
                }
                else
                {
                    data.ImagePath = notice.ImagePath;
                }
                  
                data.NoticeID = notice.NoticeID;
                data.Title = notice.Title;
                data.Description = notice.Description;
                data.ImagePath = notice.ImagePath;
                data.UpdateBy = User.Identity.Name ?? "Umme";
                data.UpdateDate = DateTime.Now;
                data.StartDate = notice.StartDate;
                data.EndDate = notice.EndDate;
                data.IsActive = notice.IsActive;
                data.IsFeatured = notice.IsFeatured;

                _context.Update(data);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return RedirectToAction(nameof(Index));
                }

                return View(notice);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(notice);
            }
        }

        // GET: Notices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
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
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: Notices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
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
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool NoticeExists(int id)
        {
          return (_context.Notices?.Any(e => e.NoticeID == id)).GetValueOrDefault();
        }
    }
}
