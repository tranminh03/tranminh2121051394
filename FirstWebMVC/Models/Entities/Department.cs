namespace  FirstWebMVC.Models.Entities
{
  public class Department
 {
  public int DepartmentId { get; set; }
  public string name { get; set; }
  public ICollection<Student> Student { get; set; }

 }

}