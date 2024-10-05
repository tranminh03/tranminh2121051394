using Microsoft.EntityFrameworkCore;
using FirstWebMVC.Models;

namespace FirstWebMVC.Data
{
public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options) {}

    public DbSet<Person> Person {get;set;} = default!;
    public DbSet<Employee> Employee { get; set; } = default!;
    public DbSet<HeThongPhanPhoi> HeThongPhanPhoi { get; set; } = default!;
    public DbSet<Customer> Customer { get; set; } = default!;
  } 
}