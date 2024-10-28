using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FirstWebMVC.Models
{

    public class Person
    {
       [Key]
       public string? PersonID { get; set; }
       public required string HoTen { get; set; }
       public required string QueQuan { get; set; }  
    }
}