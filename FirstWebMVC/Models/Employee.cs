using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstWebMVC.Models
{
[Table("Employees")]
    public class Employee
       {
      [Key]
      public required string EmployeeId { get; set; }
      public int Age { get; set; }
   }
}