using Microsoft.AspNetCore.Mvc;
using USBDProperty.Models;

namespace USBDProperty.Components
{
    public class DeveloperViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;


        public DeveloperViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = _context.DevelopersorAgent.OrderBy(d=>d.CompanyName).Where(c=>c.IsActive && c.Membership.Equals(Membership.Platinum)).ToList();
            return View(data);
        }
    }
}
