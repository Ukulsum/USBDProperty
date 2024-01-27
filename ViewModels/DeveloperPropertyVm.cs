using USBDProperty.Models;

namespace USBDProperty.ViewModels



{
    //public enum Membership
    //{
    //    Platinum = 1, Gold, Silver
    //}
    public class DeveloperPropertyVm
    {

        public int ID { get; set; }
        public string Logo { get; set; }
        public string Banner { get; set; }
        public int MembershipId { get; set; }
        public string CompanyName { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }//Owner Person Name / Contact Person Name
        public string Address { get; set; }
        public int AreaID { get; set; }
        public int PropertyID { get; set; }
        //public int ProjectsID { get; set; }
        public int PropertyForId { get; set; }
        public int PropertyTypeId { get; set; }
        public int ClientContactId { get; set; }


        public List<ClientVM> ClientVMs { get; set; }

        public List<DevelopersorAgent> developersorAgents { get; set; }
        public List<PropertyDetails> propertyDetails { get; set; }
        public List<PropertyType> propertyTypes { get; set; }
        //public List<ProjectsInfo> projectsInfos { get; set; }

       
    }
}
