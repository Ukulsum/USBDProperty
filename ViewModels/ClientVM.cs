namespace USBDProperty.ViewModels
{
    //public enum Interested
    //{
    //    ZoomInterested = 1,
    //    Buy = 2,
    //    Sale = 3
    //}
    public class ClientVM
    {
        public int ClientContactId { get; set; }
        public string ClientName { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public int PropertyID { get; set; }
        public int PropertyForId { get; set; }
        public string Message { get; set; }
        public int PropertyTypeId { get; set; }
        //public Interested Interested { get; set; }
    }
}
