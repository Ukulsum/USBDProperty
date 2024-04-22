using System.ComponentModel;

namespace USBDProperty.ViewModels
{
    public class PropertyViewModel
    {
        public int AgentID { get; set; }

        [DisplayName("Company Name")]
        public string CompanyName { get; set; }
        public int ProjectId { get; set; }
        [DisplayName("Project Name")]
        public string ProjectName { get; set; }
        public int PropertyInfoId { get; set; }
        public string Title { get; set; }
    }
}
