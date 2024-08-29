using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USBDProperty.Models
{
    public class ProjectImageGallery
    {
        public int Id { get; set; }
        [StringLength(40)]
        public string Name { get; set; }
        //[StringLength(100)]
        [ValidateNever]
        public string ImagePath { get; set; }
        [NotMapped]
        [ValidateNever]
        public IFormFile ImageFile { get; set; }
        [ForeignKey("ProjectsInfo")]
        public int ProjectID { get; set; }
        public ProjectsInfo ProjectsInfo { get; set; }
    }
}
