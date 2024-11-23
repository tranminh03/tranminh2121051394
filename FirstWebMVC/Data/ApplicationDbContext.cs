using Microsoft.EntityFrameworkCore;
using FirstWebMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace FirstWebMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options) {}

    public DbSet<Person> Person { get; set; } = default!;
    public DbSet<Student> Student { get; set; } = default!;
    public DbSet<Employee> Employee { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)

        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("Users");

            builder.Entity<IdentityRole>().ToTable("Roles");

            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");

            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");

            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");

            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
        }
  } 
}


