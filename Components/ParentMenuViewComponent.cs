using Microsoft.AspNetCore.Mvc;
using USBDProperty.Models;

namespace USBDProperty.Components
{
    public class ParentMenuViewComponent:ViewComponent
    {
        private readonly ApplicationDbContext _context;
        

        public ParentMenuViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = _context.PropertyTypes.Where(m => m.ParentPropertyTypeId == 0).ToList();
            
            return View(data);
        }
    }
}
