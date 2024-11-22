using Microsoft.AspNetCore.Identity;

namespace FirstWebMVC.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string FullName { get; set; }
    }
}