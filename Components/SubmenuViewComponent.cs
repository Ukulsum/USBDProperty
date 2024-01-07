using Microsoft.AspNetCore.Mvc;
using USBDProperty.Models;

namespace USBDProperty.Components
{
    public class SubmenuViewComponent: ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public SubmenuViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int pid)
        {
            var data = _context.PropertyTypes.Where(m => m.ParentPropertyTypeId == pid).ToList();
            return View(data);
        }
    }
}
