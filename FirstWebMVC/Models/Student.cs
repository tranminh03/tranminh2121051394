using System.ComponentModel.DataAnnotations;
using FirstWebMVC.Models.Entities;

namespace FirstWebMVC.Models
{
    public class Student
    {
        [Key]
        public string? StudentID { get; set; }
        public string? FullName { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}