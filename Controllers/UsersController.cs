using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using USBDProperty.Models;
using USBDProperty.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Encodings.Web;
using System.Text;

namespace USBDProperty.Controllers
{
    public class UsersController : Controller
    {
       
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserStore<ApplicationUser> _userStore;

        public UsersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, 
                                SignInManager<ApplicationUser> signInManager,
                                IUserStore<ApplicationUser> userStore)
        {
            this._context = context;
            this._userManager = userManager;
            _signInManager = signInManager;
            _userStore = userStore;
        }
        public IActionResult Index(string roleName, string email)
        {
            ViewBag.roles = new SelectList(_context.Roles.OrderBy(c => c.Name), "Name", "Name");
            List<UserROlesVM> usersWithRoles = new List<UserROlesVM>();
            
            usersWithRoles = (from user in _context.Users
                              select new
                              {
                                  UserId = user.Id,
                                  Username = user.UserName,
                                  Email = user.Email,
                                  //RoleNames = (from userRole in user.Roles
                                  //             join role in _context.Roles on userRole.RoleId
                                  //                          equals role.Id
                                  //select role.Name).ToList()
                                  RoleNames = _userManager.GetRolesAsync( user).Result.ToArray()
                              }).ToList().Select(p => new UserROlesVM()

                              {
                                  UserId = p.UserId,
                                  Username = p.Username,
                                  Email = p.Email,
                                  Role = string.Join(",", p.RoleNames)
                              }).OrderBy(r => r.Username).ToList();

            if (roleName == null)
            {
                roleName = "";
            }
            if (email == null)
            {
                email = "";
            }

            if (roleName != string.Empty)
            {
                usersWithRoles = usersWithRoles.Where(u => u.Role.Contains(roleName)).ToList();
            }
            if (email != string.Empty || email.Length > 0)
            {
                usersWithRoles = usersWithRoles.Where(u => u.Email == email).ToList();

            }
            //return View(usersWithRoles.ToPagedList(noOfPages, PageSize));
            return View(usersWithRoles.ToList());
             
        }
    public IActionResult Create(string returnUrl = null)
        {
            ViewBag.roles = new SelectList(_context.Roles.OrderBy(c => c.Name), "Name", "Name");
            return View(new UserVM { ReturnUrl=returnUrl?? "/Users/Index" });
        }
        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserVM uservm)
        {
            if (ModelState.IsValid)
            {

                var user = CreateUser();
                user.Email = uservm.Email;
                await _userStore.SetUserNameAsync(user,uservm.Email, CancellationToken.None);
               // await _emailStore.SetEmailAsync(user, uservm.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, uservm.Password);

                if (result.Succeeded)
                {
                   // _logger.LogInformation("User created a new account with password.");

                      //await _signInManager.SignInAsync(user, isPersistent: false);
                    await  _userManager.AddToRoleAsync(user, uservm.Role);
                        return LocalRedirect(uservm.ReturnUrl);
                   
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(uservm);
        }

        // GET: UserInfos
        [Authorize(Roles = "Super Admin")]
        public ActionResult AllUser(int? pageNo, string roleName, string email, string currentFilter)
        {
            ViewBag.roles = new SelectList(_context.Roles.OrderBy(c => c.Name), "Name", "Name");
            List<UserROlesVM> usersWithRoles = new List<UserROlesVM>();
            int PageSize = 15;
            int noOfPages = pageNo ?? 1;
            usersWithRoles = (from user in _context.Users
                              select new
                              {
                                  UserId = user.Id,
                                  Username = user.UserName,
                                  Email = user.Email,
                                  //RoleNames = (from userRole in user.Roles
                                  //             join role in _context.Roles on userRole.RoleId
                                  //                          equals role.Id
                                               //select role.Name).ToList()
                              }).ToList().Select(p => new UserROlesVM()

                              {
                                  UserId = p.UserId,
                                  Username = p.Username,
                                  Email = p.Email,
                                 // Role = string.Join(",", p.RoleNames)
                              }).OrderBy(r => r.Username).ToList();

            if (roleName == null)
            {
                roleName = "";
            }
            if (email == null)
            {
                email = "";
            }
            if (email != null)
            {
                pageNo = 1;
            }
            else
            {
                email = currentFilter;

            }
            ViewBag.CurrentFilter = email;
            if (roleName != string.Empty)
            {
                usersWithRoles = usersWithRoles.Where(u => u.Role.Contains(roleName)).ToList();
            }
            if (email != string.Empty || email.Length > 0)
            {
                usersWithRoles = usersWithRoles.Where(u => u.Email == email).ToList();

            }
            //return View(usersWithRoles.ToPagedList(noOfPages, PageSize));
            return View(usersWithRoles.ToList());
        }
        
        
        
        //[HttpGet]
        //[Authorize(Roles = "Super Admin")]
        //public ActionResult EditRoles(string email)
        //{
        //    var usersRoleID = _context.Users.Where(u => u.Email == email)
        //                            .SelectMany(s => s.Roles)
        //                            .Select(p => p.RoleId).ToList();


        //    var roleList = _context.Roles.ToList()
        //                            .Select(r => new SelectListItem
        //                            {
        //                                Selected = usersRoleID.Contains(r.Id.ToString()),
        //                                Text = r.Name,
        //                                Value = r.Name
        //                            });
        //    ViewBag.roles = roleList;
        //    ViewBag.user = email;
        //    return View();
        //}
        //[HttpPost]
        //[Authorize(Roles = "Super Admin")]
        //public ActionResult EditRoles(string[] SelectedRole, string emaill)
        //{
        //    var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_context));
        //    try
        //    {
        //        var user = _context.Users.Where(u => u.Email == emaill).FirstOrDefault();
        //        var oldRoles = _context.Users.Where(u => u.Email == emaill).SelectMany(s => s.Roles).Select(p => p.RoleId).ToList();
        //        var selectedRoles = new HashSet<string>(SelectedRole);
        //        IdentityResult result = null;
        //        if (SelectedRole != null)
        //        {
        //            //foreach (var s in _context.Roles)
        //            //{
        //            //    if (selectedRoles.Contains(s.Id))
        //            //    {
        //            //        //result = userManager.RemoveFromRole(user.Id, _context.Roles.Find(r).Name);
        //            //        if (!selectedRoleID.Contains(s.Id))
        //            //        {
        //            //            result = userManager.AddToRole(user.Id, _context.Roles.Find(s.Id).Name);
        //            //        }
        //            //    }
        //            //    else
        //            //    {
        //            //        if (selectedRoleID.Contains(s.Id))
        //            //        {
        //            //            result = userManager.RemoveFromRole(user.Id, _context.Roles.Find(s.Id).Name);
        //            //        }


        //            //    }
        //            if (oldRoles.Count > 0)
        //            {
        //                foreach (var s in oldRoles)
        //                {
        //                    result = userManager.RemoveFromRole(user.Id, _context.Roles.Find(s).Name);
        //                }
        //            }
        //            result = userManager.AddToRoles(user.Id, SelectedRole);
        //        }
        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("AllUser");
        //        }
        //        if (result.Errors.Count() > 0)
        //        {
        //            foreach (string e in result.Errors)
        //            {
        //                ViewBag.error += e + "\t";
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.error = ex.Message;
        //    }
        //    var usersRoleID = _context.Users.Where(u => u.Email == emaill).SelectMany(s => s.Roles).Select(p => p.RoleId).ToList();
        //    var roleList = _context.Roles.ToList()
        //                            .Select(r => new SelectListItem
        //                            {
        //                                Selected = usersRoleID.Contains(r.Id.ToString()),
        //                                Text = r.Name,
        //                                Value = r.Name
        //                            });
        //    ViewBag.roles = roleList;
        //    ViewBag.user = emaill;
        //    return View();
        //}
        //[Authorize(Roles = "Admin,Super Admin,Employee,Instructor,Student")]
        //[HttpGet]
        //public ActionResult ChangeProfilePic()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[Authorize(Roles = "Admin,Super Admin,Employee,Instructor,Student")]
        //public ActionResult ChangeProfilePic(HttpPostedFileBase Profile)
        //{
        //    // get EF Database 
        //    var _context = HttpContext.GetOwinContext().Get<Application_contextContext>();

        //    // find the user.
        //    var userid = User.Identity.GetUserId();
        //    var user = _context.Users.Where(x => x.Id == userid).FirstOrDefault();
        //    if (Profile != null)
        //    {
        //        string ext = Path.GetExtension(Profile.FileName).ToLower();
        //        string fpath = Path.Combine(Server.MapPath("~/Images/ProfilePic"));
        //        if (!Directory.Exists(fpath))
        //        {
        //            Directory.CreateDirectory(fpath);
        //        }
        //        if (ext == ".jpg" || ext == ".png" || ext == ".jpeg")
        //        {
        //            //string fileName = Path.GetFileNameWithoutExtension(courses.BannerImg.FileName) + "_" + Guid.NewGuid().ToString() + ext;
        //            string fileName = Path.GetFileNameWithoutExtension(Profile.FileName) + "_" + user.FullName + ext;
        //            Profile.SaveAs(Path.Combine(fpath, fileName));
        //            user.Photo = "~/Images/ProfilePic/" + fileName;
        //        }
        //    }
        //    // save changes to database
        //    _context.SaveChanges();

        //    if (User.IsInRole("Student"))
        //    {
        //        return RedirectToAction("MyProfile", "Students");
        //    }

        //    return RedirectToAction("Index", "Admin");

        //}
        //[Authorize(Roles = "Admin,Super Admin,Employee,Instructor,Student")]
        //public ActionResult ChangePassword()
        //{
        //    string uid = User.Identity.GetUserId();
        //    var r = userManager.GetRoles(uid);
        //    if (r.Contains("Student"))
        //    {
        //        return View("ChangePassword", "_StudentLayout");
        //    }
        //    return View("ChangePassword", "_AdminLayout1");
        //}
        //public ActionResult ResetPassword(ResetPasswordViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }
        //    //var user = await UserManager.Fin_contextyNameAsync(model.Email);
        //    var user = userManager.Fin_contextyEmail(model.Email);
        //    if (user == null)
        //    {
        //        // Don't reveal that the user does not exist
        //        // return RedirectToAction("Change", "Account");
        //        return View();
        //    }
        //    var provider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("PowersoftWeb");
        //    userManager.UserTokenProvider = new Microsoft.AspNet.Identity.Owin.DataProtectorTokenProvider<ApplicationUser>(provider.Create("EmailConfirmation"));

        //    string resetToken = userManager.GeneratePasswordResetToken(user.Id);
        //    var result = userManager.ResetPassword(user.Id, resetToken, model.Password);
        //    if (result.Succeeded)
        //    {
        //        return RedirectToAction("ResetPasswordConfirmation", "UserInfos");
        //    }
        //    //AddErrors(result);
        //    return View();
        //}
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }
    }
}
