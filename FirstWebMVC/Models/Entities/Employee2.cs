using System.ComponentModel.DataAnnotations;
namespace FirstWebMVC.Models.Entities
{
    public class Employee2
    {
        [Key]
        public int StudentID { get; set; }
        [Required]
        public string  FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? Address { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateofBirth { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
    }
}