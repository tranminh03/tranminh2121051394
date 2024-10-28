using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FirstWebMVC.Models
{
    public class Employee : Person
    {
        public string? EmployeeID { get; set; }
        public required string Company { get; set; }
    }
    
}