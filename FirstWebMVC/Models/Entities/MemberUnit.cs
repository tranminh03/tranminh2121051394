
using System.ComponentModel.DataAnnotations;
namespace FirstWebMVC.Models.Entities
{
    public class MemberUnit
    {
        [Key]
        public int MemberUnitID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }

        public string? PhoneNumber { get; set; }

        public string? WebsiteUrl { get; set; }


    }
}
