using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstWebMVC.Models
{

    public class Customer
    {
       [Key]
       public string CustomerID { get; set; }
       [MinLength(3)]
       [Required(ErrorMessage ="Không được để trống")]
       public string FullName { get; set; }
       public string? Address { get; set; }
       [DataType(DataType.EmailAddress)]
       public string Email { get; set; }
    }
}