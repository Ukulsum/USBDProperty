using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace USBDProperty.DTO
{
    public class BaseDTO
    {
        [ValidateNever]
        public DateTime CreatedDate { get; set; } = DateTime.Now.Date;
        [ValidateNever]
        public string? CreatedBy { get; set; }
        [ValidateNever]
        public DateTime UpdateDate { get; set; }
        [ValidateNever]
        public string? UpdateBy { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
