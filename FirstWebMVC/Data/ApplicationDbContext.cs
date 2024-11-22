using Microsoft.EntityFrameworkCore;
using FirstWebMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FirstWebMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options) {}

    public DbSet<Person> Person { get; set; } = default!;
    public DbSet<Student> Student { get; set; } = default!;
    public DbSet<Employee> Employee { get; set; } = default!;
  } 
}


