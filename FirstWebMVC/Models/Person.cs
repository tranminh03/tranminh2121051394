using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FirstWebMVC.Models
{

    public class Person
    {
         [Key]
    [Required(ErrorMessage = "PersonID là bắt buộc.")]
    [StringLength(10, ErrorMessage = "PersonID không được dài quá 10 ký tự.")]
    public string? PersonID { get; set; }

    [Required(ErrorMessage = "HoTen là bắt buộc.")]
    [StringLength(50, ErrorMessage = "HoTen không được dài quá 50 ký tự.")]
    public string? HoTen { get; set; }

    [StringLength(100, ErrorMessage = "QueQuan không được dài quá 100 ký tự.")]
    public string? QueQuan { get; set; }
    }
}