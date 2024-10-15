using System.ComponentModel.DataAnnotations;

namespace FirstWebMVC.Models
{
    public class Student
    {
        [Key]
        public string? StudentID { get; set; }
        public string? FullName { get; set; }
    }
}