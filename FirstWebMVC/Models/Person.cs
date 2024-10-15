using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FirstWebMVC.Models
{

    public class Person
    {
       [Key]
       public string? PersonID { get; set; }
       public string? HoTen { get; set; }
       public string? QueQuan { get; set; }

    }
}