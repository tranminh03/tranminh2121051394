using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstWebMVC.Models;

    // đặt tên cho bảng
    [Table("SinhVien")]
    public class Student
    {
    
        [Key]
        public string ?name{get;set;}
        public string? Address{get;set;}
    }


