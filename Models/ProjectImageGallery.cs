using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USBDProperty.Models
{
    public class ProjectImageGallery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [StringLength(100)]
        public string ImagePath { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [ForeignKey("ProjectsInfo")]
        public int ProjectID { get; set; }
        public ProjectsInfo ProjectsInfo { get; set; }
    }
}
