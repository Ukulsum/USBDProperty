using Microsoft.AspNetCore.Identity;

namespace USBDProperty.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? ProfilePic { get; set; }
    }
}
