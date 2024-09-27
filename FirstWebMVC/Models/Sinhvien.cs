using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FirstWebMVC.Models;

[Table("Sinhvien")]
public class Sinhvien
{
   [Key]
    public string? nguoi{get;set;}
    public string? Hoten{get;set;}
    public string? diachi{get;set;}
}