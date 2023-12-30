namespace USBDProperty.DTO
{
    public class BaseDTO
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now.Date;
        public string? CreatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
